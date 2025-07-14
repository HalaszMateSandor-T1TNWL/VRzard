using Godot;
using System;

public partial class SetupPanel : Control
{
	[Signal]
	private delegate void SpellSelectedEventHandler(int spell);
	
	[Signal]
	private delegate void SpellDeSelectedEventHandler(int spell);
	
	private void OnSpellSelected(int spell)
	{
		EmitSignal(SignalName.SpellSelected, spell);
	}
	
	private void OnSpellDeSelected(int spell)
	{
		EmitSignal(SignalName.SpellDeSelected, spell);
	}
}
