using Godot;
using System;

public partial class GrabbableObject : Node3D
{
    [Export]
    public MultiplayerSynchronizer Sync;

    private bool _isHeld = false;

    public override void _Ready()
    {
        Sync ??= GetNode<MultiplayerSynchronizer>("MultiplayerSynchronizer");
    }

    public void Grab(long byPeerId)
    {
        SetMultiplayerAuthority((int)byPeerId);
        _isHeld = true;
    }

    public void Release()
    {
        _isHeld = false;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsMultiplayerAuthority())
            return;
    }
}
