using Godot;
using System;
using System.Drawing;

public partial class Picker : RayCast3D
{
	[Signal]
	public delegate void LabelPressedEventHandler();
	[Signal]
	public delegate void DrawingEventHandler(Godot.Vector3 poi);
	
	private Node3D _label;
	private Node3D _canvas;
	private Vector3 _pointOfImpact;
	
	public override void _PhysicsProcess(double delta)
	{
		var importedGDScript = GD.Load<GDScript>("res://addons/godot-xr-tools/misc/xr_helpers.gd");
		var importedGDScriptNode = (GodotObject)importedGDScript.New();

		XRController3D controller = (XRController3D)importedGDScriptNode.Call("get_xr_controller", this);

		//_label = GetNode<Node3D>($"../../LeftController/Spellbook/Spell");
		//_canvas = GetNode<Node3D>($"../../Canvas/CanvasArea");

		if (IsColliding())
		{
			var target = GetCollider() as Node3D;
			if (target != null && target == _label && controller.IsButtonPressed("trigger_click"))
			{
				EmitSignal(SignalName.LabelPressed);
			}
			/*if (target != null && target == _canvas)
			{
				if (controller.IsButtonPressed("trigger_click"))
				{
					GD.Print("Interacting with canvas...");
					_pointOfImpact = TargetPosition;
					EmitSignal(SignalName.Drawing, _pointOfImpact);
				}
			}*/
		}

	}

}
