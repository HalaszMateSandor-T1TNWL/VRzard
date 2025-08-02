using Godot;
using System;

public partial class SetupPanel : Control
{
	/*
	* 					TO AVOID CONFUSION: 
	* 		These are connected to the player node via code, 
	* 		you won't be able to see it in Godot's Signal page
	*/
	
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
