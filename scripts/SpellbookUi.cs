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
	
	private void OnSpellSelected(int spell)
	{
		EmitSignal(SignalName.RegisterName, spell);
		EmitSignal(SignalName.RegisterShape, spell);
	}
	
	private void OnSpellDeSelected(int spell)
	{
		EmitSignal(SignalName.UnRegisterName, spell);
		EmitSignal(SignalName.UnRegisterShape, spell);
	}
	
	private void OnCanvasWakeUpRequest(int spell)
	{
		EmitSignal(SignalName.CanvasWakeUpRequest, spell);
	}
}
