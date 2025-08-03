using Godot;
using System;
using System.Collections.Generic;

public partial class Player : Node3D
{
	[Signal]
	public delegate void SpellSelectedEventHandler(int spell);
	[Signal]
	public delegate void SpellDeSelectedEventHandler(int spell);

	private Node3D _canvas;
	private Error _error;

	public override void _Ready()
	{
		_canvas = GetNode<Node3D>($"XROrigin3D/CastingCanvas");
		_canvas.Visible = false;
		Node currentScene = GetTree().CurrentScene;

		_error = currentScene.GetNode($"Viewport2Din3D/Viewport/SetupPanel").Connect("SpellDeSelected", new Callable(this, nameof(OnSpellDeSelected)));
		if (_error != Error.Ok) GD.PrintErr("Done messed up");
		else GD.Print("SpellDeselected connected successfully");

		_error = currentScene.GetNode($"Viewport2Din3D/Viewport/SetupPanel").Connect("SpellSelected", new Callable(this, nameof(OnSpellSelected)));
		if (_error != Error.Ok) GD.PrintErr("Done messed up");
		else GD.Print("SpellSelected connected successfully");
	}

	private void OnSpellDeSelected(int spell)
	{
		EmitSignal(SignalName.SpellDeSelected, spell);
	}

	private void OnSpellSelected(int spell)
	{
		EmitSignal(SignalName.SpellSelected, spell);
	}

	private void OnCanvasWakeUpRequest()
	{
		if (_canvas.Visible == false)
		{
			_canvas.Visible = true;
		}
	}
}
