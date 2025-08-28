using Godot;
using System;

public partial class PlayerModel : MeshInstance3D
{
    private PlayerCamera Camera;

    public override void _Ready()
    {
        Camera = GetParent().GetNode<PlayerCamera>("XROrigin3D/XRCamera3D");
    }

    public override void _Process(double delta)
    {
        if (Camera == null) return;

        GlobalPosition = Camera.GlobalPosition;
        float yaw = Camera.GlobalRotation.Y;
        Rotation = new Vector3(0, yaw, 0);
    }
}
