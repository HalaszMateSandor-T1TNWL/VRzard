using Godot;
using System;

public partial class LeftController : XRController3D
{
	private Node3D _viewport2Din3D;
	private GDScript _viewport2Din3DScript;
	private GodotObject _viewport2Din3DNode;

	public override void _Ready()
	{
		_viewport2Din3D = GetNode<Node3D>($"SpellbookUI");
	}

	private void OnBookWatcherEnabledState(bool value)
	{
		_viewport2Din3D.Visible = value;
	}
	private void OnBookVisibleChanged(bool value)
	{
		_viewport2Din3D.Visible = value;
	}
	
}
