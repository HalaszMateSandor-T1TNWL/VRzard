using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerCamera : Node3D
{
	[Signal]
	public delegate void FocusLostEventHandler();

	[Signal]
	public delegate void FocusGainedEventHandler();

	[Signal]
	public delegate void PoseRecenteredEventHandler();

	[Export]
	public int maximumRefreshRate { get; set; } = 90;

	private OpenXRInterface _xrInterface;
	private bool _xrIsFocused;

	public override void _Ready()
	{
		_xrInterface = (OpenXRInterface)XRServer.FindInterface("OpenXR");

		if (_xrInterface != null && _xrInterface.IsInitialized())
		{
			GD.Print("OpenXR successfully initialized!");

			var viewPort = GetViewport();
			viewPort.UseXR = true;

			DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);

			if (RenderingServer.GetRenderingDevice() != null)
			{
				viewPort.VrsMode = Viewport.VrsModeEnum.XR;
			}
			else if ((int)ProjectSettings.GetSetting("xr/openxr/foveation_level") == 0)
			{
				GD.PushWarning("OpenXR: Recommended setting Foveation level too High in Project setting!");
			}

			_xrInterface.SessionBegun += OnOpenXRSessionBegun;
			_xrInterface.SessionVisible += OnOpenXRVisibleState;
			_xrInterface.SessionFocussed += OnOpenXRFocusedState;
			_xrInterface.SessionStopping += OnOpenXRStopping;
			_xrInterface.PoseRecentered += OnOpenXRPoseRecentered;
		}
		else
		{
			GD.Print("OpenXR failed to initialize, make sure your headset is plugged in properly and the necessary programs are running.");
			GetTree().Quit();
		}
	}

	private void OnOpenXRSessionBegun()
	{
		var currentRefreshRate = _xrInterface.DisplayRefreshRate;
		GD.Print(currentRefreshRate > 0.0f
			? $"OpenXR: Refresh Rate reported as {currentRefreshRate}"
			: "OpenXR: No Refresh Rates given by XR runtime");

		var newRefreshRate = currentRefreshRate;
		var availableRefreshRates = _xrInterface.GetAvailableDisplayRefreshRates();
		if (availableRefreshRates.Count == 0)
		{
			GD.Print("OpenXR: Target does not support refresh rate extension.");
		}
		else if (availableRefreshRates.Count == 1)
		{
			newRefreshRate = (float)availableRefreshRates[0];
		}
		else
		{
			GD.Print("OpenXR: Available Refresh Rates: ", availableRefreshRates);
			foreach (float rate in availableRefreshRates)
			{
				if (rate > newRefreshRate && rate <= maximumRefreshRate)
				{
					newRefreshRate = rate;
				}
			}
		}

		if (currentRefreshRate != newRefreshRate)
		{
			GD.Print($"Setting new Refresh Rate to {newRefreshRate}");
			_xrInterface.DisplayRefreshRate = newRefreshRate;
			currentRefreshRate = newRefreshRate;
		}

		Engine.PhysicsTicksPerSecond = (int)currentRefreshRate;
	}

	private void OnOpenXRVisibleState()
	{
		if (_xrIsFocused)
		{
			GD.Print("OpenXR lost focus");

			_xrIsFocused = false;

			GetTree().Paused = true;

			EmitSignal(SignalName.FocusLost);
		}
	}

	private void OnOpenXRFocusedState()
	{
		GD.Print("OpenXR gained focus");

		_xrIsFocused = true;

		GetTree().Paused = false;

		EmitSignal(SignalName.FocusGained);
	}
		private void OnOpenXRStopping()
	{
		GD.Print("OpenXR: Session ending");
	}

	private void OnOpenXRPoseRecentered()
	{
		EmitSignal(SignalName.PoseRecentered);
	}
}
