using Godot;
using System;

public partial class Picker : RayCast3D
{
	[Signal]
	public delegate void LabelPressedEventHandler();
	private Node3D _label;
	public override void _PhysicsProcess(double delta)
	{
		var importedGDScript = GD.Load<GDScript>("res://addons/godot-xr-tools/misc/xr_helpers.gd");
		var importedGDScriptNode = (GodotObject)importedGDScript.New();

		XRController3D controller = (XRController3D)importedGDScriptNode.Call("get_xr_controller", this);

		_label = GetNode<Node3D>($"../../LeftController/Spellbook/PissNPooDOn");

		if (IsColliding())
		{
			var target = GetCollider() as Node3D;
			if (target != null && target == _label && controller.IsButtonPressed("trigger_click"))
			{
				GD.Print("Emmiting signal///");
				EmitSignal(SignalName.LabelPressed);
			}
		}

	}

}
