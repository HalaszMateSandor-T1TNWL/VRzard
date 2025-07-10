using Godot;
using Godot.NativeInterop;
using Microsoft.VisualBasic;
using System;
using System.Runtime.CompilerServices;

public partial class BookWatcher : RayCast3D
{
	[Signal]
	public delegate void EnabledStateEventHandler(bool value);

	private Node3D _book;
	private GDScript _controllerScript;
	private GodotObject _controllerScriptNode;
	private XRController3D _leftController;

	public override void _Ready()
	{
		_controllerScript = GD.Load<GDScript>("res://addons/godot-xr-tools/misc/xr_helpers.gd");
		_controllerScriptNode = (GodotObject)_controllerScript.New();

		_leftController = (XRController3D)_controllerScriptNode.Call("get_left_controller", this);
	}


	public override void _Process(double delta)
	{
		if (_leftController.IsButtonPressed("trigger_click"))
		{
			this.Enabled = false;
			EmitSignal(SignalName.EnabledState, false);
		}
		else
		{
			this.Enabled = true;
			EmitSignal(SignalName.EnabledState, true);
		}
	}

	
	public override void _PhysicsProcess(double delta)
	{
		_book = GetNode<Node3D>($"../Spellbook");
		_book.SetVisible(false);
		
		if (IsColliding())
		{
			var target = GetCollider() as Node;
			if (target != null && target.Name == "HeadArea")
			{
				_book.SetVisible(true);
			}
		}
	}
}
