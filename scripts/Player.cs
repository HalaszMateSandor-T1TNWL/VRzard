using Godot;
using System;
using System.Collections.Generic;

public partial class Player : Node3D
{
	[Signal]
	public delegate void GlyphWakeUpEventHandler(int spellLetter);
	[Signal]
	public delegate void SpellSelectedEventHandler(int spell);
	[Signal]
	public delegate void SpellDeSelectedEventHandler(int spell);

	private Node3D _canvas;
	private Error _error;
    public override void _Ready()
	{

        _canvas = GetNode<Node3D>($"XROrigin3D/CastingCanvas");
		Node currentScene = GetTree().CurrentScene;

        if (IsMultiplayerAuthority())
        {
            _error = currentScene.GetNode($"Viewport2Din3D/Viewport/SetupPanel").Connect("SpellDeSelected", new Callable(this, nameof(OnSpellDeSelected)));
            if (_error != Error.Ok) GD.PrintErr("Done messed up");
            else GD.Print("SpellDeselected connected successfully");

            _error = currentScene.GetNode($"Viewport2Din3D/Viewport/SetupPanel").Connect("SpellSelected", new Callable(this, nameof(OnSpellSelected)));
            if (_error != Error.Ok) GD.PrintErr("Done messed up");
            else GD.Print("SpellSelected connected successfully");

            GetNode<Node3D>("XROrigin3D").SetProcess(true);
            GetNode<MeshInstance3D>("PlayerModel").Visible = false;
        }
        else
        {
            GetNode<Node3D>("XROrigin3D").SetProcess(false);
            GetNode<MeshInstance3D>("PlayerModel").Visible = true;
        }
    }

    private void OnSpellDeSelected(int spell)
    {
        if (IsMultiplayerAuthority())
            EmitSignal(SignalName.SpellDeSelected, spell);
    }

    private void OnSpellSelected(int spell)
    {
        if (IsMultiplayerAuthority())
            EmitSignal(SignalName.SpellSelected, spell);
    }

    private void OnCanvasWakeUpRequest(int spell)
    {
        if (!IsMultiplayerAuthority())
            return;

        if (_canvas.Visible)
            EmitSignal(SignalName.GlyphWakeUp, spell);
        else
        {
            _canvas.Visible = true;
            EmitSignal(SignalName.GlyphWakeUp, spell);
        }
    }

}
