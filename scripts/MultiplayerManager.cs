using Godot;
using System;

public partial class MultiplayerManager : Node3D
{
    [Export] public string PlayerScenePath = "res://scenes/xr_camera.tscn";
    [Export] public NodePath PlayersNodePath = "Players";

    private Node3D playersContainer;

    public override void _Ready()
    {
        playersContainer = GetNode<Node3D>(PlayersNodePath);

        Multiplayer.PeerConnected += OnPeerConnected;
        Multiplayer.PeerDisconnected += OnPeerDisconnected;

        // Server should spawn all players (including itself)
        if (Multiplayer.IsServer())
        {
            GD.Print("I'm the server. Spawning local player...");
            SpawnPlayer(Multiplayer.GetUniqueId());
        }
        else
        {
            GD.Print("I'm a client. Waiting for server to spawn me...");
        }
    }

    private void OnPeerConnected(long id)
    {
        GD.Print($"Peer connected: {id}");

        if (Multiplayer.IsServer())
        {
            GD.Print($"Server is spawning player for peer {id}");
            SpawnPlayer(id);
        }
    }

    private void OnPeerDisconnected(long id)
    {
        GD.Print($"Peer disconnected: {id}");
    }

    private void SpawnPlayer(long peerId)
    {
        playersContainer.AddChild(GD.Load<PackedScene>(PlayerScenePath).Instantiate() as Node3D);
    }
}
