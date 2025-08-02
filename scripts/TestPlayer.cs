using Godot;
using System;

public partial class TestPlayer : CharacterBody3D
{
    [Export] public float Speed = 5.0f;
    [Export] public float JumpVelocity = 4.5f;
    [Export] public float MouseSensitivity = 0.002f;

    private Node3D _head;
    private Camera3D _camera;
    private Button JoinServerButton;
    private float _verticalRotation = 0f;

    public override void _Ready()
    {
        _head = GetNode<Node3D>("Neck");
        _camera = _head.GetNode<Camera3D>("Camera3D");
        JoinServerButton = GetNode<Button>("/root/Node3D/Lobby/Viewport/Lobby/MarginContainer/VBoxContainer/JoinServer");

        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent1 && keyEvent1.Pressed && keyEvent1.Keycode == Key.Escape)
        {
            Input.MouseMode = Input.MouseModeEnum.Visible;
        }

        if (@event is InputEventKey keyEvent2 && keyEvent2.Pressed && keyEvent2.Keycode == Key.F1)
        {
            JoinServerButton.EmitSignal("pressed");

        }
        if (@event is InputEventMouseMotion mouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
        {
            // Horizontal rotation (yaw)
            RotateY(-mouseMotion.Relative.X * MouseSensitivity);

            // Vertical rotation (pitch), clamped
            _verticalRotation = Mathf.Clamp(_verticalRotation - mouseMotion.Relative.Y * MouseSensitivity, -Mathf.Pi / 2, Mathf.Pi / 2);
            _head.Rotation = new Vector3(_verticalRotation, 0, 0);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector3 velocity = Velocity;

        // Input direction (WASD)
        Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;
        }
        else
        {
            velocity.X = 0;
            velocity.Z = 0;
        }

        // Jump
        if (IsOnFloor() && Input.IsActionJustPressed("ui_accept"))
            velocity.Y = JumpVelocity;

        // Gravity
        if (!IsOnFloor())
            velocity.Y -= 9.8f * (float)delta;

        Velocity = velocity;
        MoveAndSlide();
    }
}
