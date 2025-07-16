using Godot;
using System;
using System.Collections.Generic;

public partial class Player : Node3D
{
	[Signal]
	public delegate void GlyphWakeUpEventHandler(int spellLetter);

	private Node3D _canvas;

	public override void _Ready()
	{
		_canvas = GetNode<Node3D>($"XROrigin3D/CastingCanvas");
	}

	private void OnCanvasWakeUpRequest(int spell)
	{
		_canvas.Visible = true;
		EmitSignal(SignalName.GlyphWakeUp, spell);
	}
	
}
