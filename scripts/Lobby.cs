using Godot;
using System;

public partial class Lobby : Control
{
    private ENetMultiplayerPeer peer;

    [Export] private NodePath ipInputPath = "MarginContainer/VBoxContainer/IP";
    [Export] private NodePath portInputPath = "MarginContainer/VBoxContainer/Port";
    [Export] private NodePath statusLabelPath = "MarginContainer/VBoxContainer/Status";

    private LineEdit ipInput;
    private LineEdit portInput;
    private Label statusLabel;

    public override void _Ready()
    {
        ipInput = GetNode<LineEdit>(ipInputPath);
        portInput = GetNode<LineEdit>(portInputPath);
        statusLabel = GetNode<Label>(statusLabelPath);


        GetNode<Button>("MarginContainer/VBoxContainer/CreateServer").Pressed += OnHostPressed;
        GetNode<Button>("MarginContainer/VBoxContainer/JoinServer").Pressed += OnJoinPressed;

        Multiplayer.ConnectedToServer += OnConnected;
        Multiplayer.PeerConnected += OnPeerConnected;
        Multiplayer.PeerDisconnected += OnPeerDisconnected;
        Multiplayer.ConnectionFailed += OnConnectionFailed;
    }

    private void OnHostPressed()
    {
        int port = int.TryParse(portInput.Text, out var p) ? p : 8080;
        StartHost(port);
    }

    private void OnJoinPressed()
    {
        int port = int.TryParse(portInput.Text, out var p) ? p : 8080;
        string ip = ipInput.Text.Trim();
        JoinServer(ip, port);
    }

    private void StartHost(int port)
    {
        peer = new ENetMultiplayerPeer();
        var err = peer.CreateServer(port, 2);
        if (err != Error.Ok)
        {
            statusLabel.Text = $"Failed to host: {err}";
            return;
        }
        Multiplayer.MultiplayerPeer = peer;
        statusLabel.Text = $"Hosting on port {port}...";
        GD.Print(statusLabel.Text);
    }

    private void JoinServer(string ip, int port)
    {
        peer = new ENetMultiplayerPeer();
        var err = peer.CreateClient(ip, port);
        if (err != Error.Ok)
        {
            statusLabel.Text = $"Failed to connect: {err}";
            return;
        }
        Multiplayer.MultiplayerPeer = peer;
        statusLabel.Text = $"Connecting to {ip}:{port}...";
        GD.Print(statusLabel.Text);
    }

    private void OnConnected()
    {
        statusLabel.Text = "Connected to server!";
        GD.Print(statusLabel.Text);
        LoadGameScene();
    }

    private void OnPeerConnected(long id)
    {
        statusLabel.Text = $"Peer connected: {id}";
        GD.Print(statusLabel.Text);
        if (Multiplayer.IsServer())
        {
            LoadGameScene();
        }
    }

    private void OnPeerDisconnected(long id)
    {
        statusLabel.Text = $"Peer disconnected: {id}";
        GD.Print(statusLabel.Text);
    }

    private void OnConnectionFailed()
    {
        statusLabel.Text = "Connection failed!";
        GD.Print(statusLabel.Text);
    }

    private void LoadGameScene()
    {
        var scene = GD.Load<PackedScene>("res://scenes/main.tscn");
        GetTree().ChangeSceneToPacked(scene);
    }

}
