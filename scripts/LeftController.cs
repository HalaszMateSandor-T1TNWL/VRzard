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
		_viewport2Din3DScript = GD.Load<GDScript>($"res://addons/godot-xr-tools/objects/viewport_2d_in_3d.gd");
		_viewport2Din3DNode = (GodotObject)_viewport2Din3DScript.New();
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
