using Godot;
using System;

public partial class XrCamera : Node3D
{
	private XRInterface _xrInterface;
	public override void _Ready()
	{
		_xrInterface = XRServer.FindInterface("OpenXR");
		if (_xrInterface != null && _xrInterface.IsInitialized())
		{
			GD.Print("OpenXR successfully initialised");

			DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);

			GetViewport().UseXR = true;
		}
		else
		{
			GD.Print("Failed to initialise OpenXR instance, please make sure your headset is properly connected to your PC");
		}
	}
}
