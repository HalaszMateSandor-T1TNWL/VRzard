using Godot;
using System;
using System.Linq;

public partial class Main : Node3D
{

    public override void _Ready()
    {
        string[] args = OS.GetCmdlineArgs();
        bool useXR = args.Contains("--xr-false");

        if (useXR)
        {
            GD.Print("Starting in non-XR mode.");
            StartNonXRMode();
        }
        else
        {
            GD.Print("Starting in XR mode.");
            StartXRMode();
        }
    }

    void StartXRMode()
    {
        // Enable XR interface
        var xrInterface = XRServer.FindInterface("OpenXR");
        if (xrInterface != null && xrInterface.IsInitialized())
        {
            XRServer.PrimaryInterface = xrInterface;
            GD.Print("OpenXR initialized.");
        }
        else
        {
            GD.PrintErr("OpenXR failed to initialize.");
        }

        // Instantiate your XR player scene
        var xrPlayerScene = GD.Load<PackedScene>("res://scenes/xr_camera.tscn");
        AddChild(xrPlayerScene.Instantiate());
    }

    void StartNonXRMode()
    {
        // Instantiate your normal camera + movement player
        var simPlayerScene = GD.Load<PackedScene>("res://scenes/TestPlayer.tscn");
        AddChild(simPlayerScene.Instantiate());
    }
}
