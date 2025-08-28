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
	public delegate void CanvasWakeUpRequestEventHandler();
	[Signal]
	public delegate void CanvasSleepRequestEventHandler();

	[Signal]
	public delegate void ShowGlyphEventHandler(int spell);

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
	
	private void OnCanvasWakeUpRequest()
	{
		EmitSignal(SignalName.CanvasWakeUpRequest);
	}
	
	private void OnSleepCanvasRequest()
	{
		EmitSignal(SignalName.CanvasSleepRequest);
	}
	
	private void OnShowGlyphRequest(int spell)
	{
		EmitSignal(SignalName.ShowGlyph, spell);
	}
	
}
