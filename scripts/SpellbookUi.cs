using Godot;
using System;

public partial class SpellbookUi : CanvasLayer
{
	[Signal]
	public delegate void RegisterNameEventHandler(int spell);
	[Signal]
	public delegate void RegisterShapeEventHandler(int spell);
	
	[Signal]
	public delegate void UnRegisterNameEventHandler(int spell);
	[Signal]
	public delegate void UnRegisterShapeEventHandler(int spell);
	
	[Signal]
	public delegate void CanvasWakeUpRequestEventHandler(int spell);
	[Signal]
	public delegate void CanvasSleepRequestEventHandler(int spell);
	
	private void OnSpellSelected(int spell)
	{
		EmitSignal(SignalName.RegisterName, spell);
		EmitSignal(SignalName.RegisterShape, spell);
	}
	
	private void OnSpellDeSelected(int spell)
	{
		GD.Print("Sending Signal to unregister name");
		EmitSignal(SignalName.UnRegisterName, spell);
		GD.Print("Sending Signal to unregister shape");
		EmitSignal(SignalName.UnRegisterShape, spell);
	}
	
	private void OnCanvasWakeUpRequest(int spell)
	{
		EmitSignal(SignalName.CanvasWakeUpRequest, spell);
	}
	
	private void OnSleepCanvasRequest(int spell)
	{
		EmitSignal(SignalName.CanvasSleepRequest, spell);
	}
	
	private void OnShowGlyphRequest(int spell)
	{
		
	}
}
