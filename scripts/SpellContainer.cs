using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class SpellContainer : Godot.GridContainer
{
	[Signal]
	public delegate void SpellSelectedEventHandler(int spell);
	[Signal]
	public delegate void SpellDeSelectedEventHandler(int spell);
	
	private int _spellsChosen = 0;
	private CheckBox _ignite;
	private CheckBox _teleport;
	private CheckBox _freeze;
	private CheckBox _wind;
	private CheckBox _earth;

	public override void _Ready()
	{
		_ignite = GetNode<CheckBox>($"VBoxContainer/Ignite");
		_teleport = GetNode<CheckBox>($"VBoxContainer/Teleport");
		_freeze = GetNode<CheckBox>($"VBoxContainer/Freeze");
		_wind = GetNode<CheckBox>($"VBoxContainer/Wind");
		_earth = GetNode<CheckBox>($"VBoxContainer/Earth");
	}

	private void OnIgniteToggled(bool toggledOn)
	{
		if (toggledOn) HandleSpellSelection((int)SpellList.Spells.Ignite);
		else HandleSpellDeSelection((int)SpellList.Spells.Ignite);
	}
	private void OnTeleportToggled(bool toggledOn)
	{
		if (toggledOn) HandleSpellSelection((int)SpellList.Spells.Teleport);
		else HandleSpellDeSelection((int)SpellList.Spells.Teleport);
	}
	private void OnFreezeToggled(bool toggledOn)
	{
		if (toggledOn) HandleSpellSelection((int)SpellList.Spells.Freeze);
		else HandleSpellDeSelection((int)SpellList.Spells.Freeze);
	}
	private void OnWindToggled(bool toggledOn)
	{
		if (toggledOn) HandleSpellSelection((int)SpellList.Spells.Wind);
		else HandleSpellDeSelection((int)SpellList.Spells.Wind);
	}
	private void OnEarthToggled(bool toggledOn)
	{
		if (toggledOn) HandleSpellSelection((int)SpellList.Spells.Earth);
		else HandleSpellDeSelection((int)SpellList.Spells.Earth);
	}

	private void HandleSpellSelection(int spell)
	{
		if (_spellsChosen < 4)
		{
			switch (spell)
			{
				case (int)SpellList.Spells.Ignite:
					GD.Print("Ignite added to the list of spells.");
					EmitSignal(SignalName.SpellSelected, (int)SpellList.Spells.Ignite);
					_spellsChosen++;
					break;
				case (int)SpellList.Spells.Teleport:
					GD.Print("Teleport added to the list of spells.");
					EmitSignal(SignalName.SpellSelected, (int)SpellList.Spells.Teleport);
					_spellsChosen++;
					break;
				case (int)SpellList.Spells.Freeze:
					GD.Print("Freeze added to the list of spells.");
					EmitSignal(SignalName.SpellSelected, (int)SpellList.Spells.Freeze);
					_spellsChosen++;
					break;
				case (int)SpellList.Spells.Wind:
					GD.Print("Wind added to the list of spells.");
					EmitSignal(SignalName.SpellSelected, (int)SpellList.Spells.Wind);
					_spellsChosen++;
					break;
				case (int)SpellList.Spells.Earth:
					GD.Print("Earth added to spell list");
					EmitSignal(SignalName.SpellSelected, (int)SpellList.Spells.Earth);
					_spellsChosen++;
					break;
				default:
					GD.PrintErr("Unkown button pressed...how did it get here???");
					break;
			}
		}
		else
		{
			_spellsChosen++;
			GD.PrintErr("Only 4 spells can be chosen at the same time, please unselect one to have this one selected.");
			HandleSpellOverflow(spell);
		}
	}

	private void HandleSpellDeSelection(int spell)
	{
		if (_spellsChosen >= 0)
		{
			switch (spell)
			{
				case (int)SpellList.Spells.Ignite:
					GD.Print("Ignite removed from the list of spells.");
					EmitSignal(SignalName.SpellDeSelected, (int)SpellList.Spells.Ignite);
					_spellsChosen--;
					break;
				case (int)SpellList.Spells.Teleport:
					GD.Print("Teleport removed from the list of spells.");
					EmitSignal(SignalName.SpellDeSelected, (int)SpellList.Spells.Teleport);
					_spellsChosen--;
					break;
				case (int)SpellList.Spells.Freeze:
					GD.Print("Freeze removed from the list of spells.");
					EmitSignal(SignalName.SpellDeSelected, (int)SpellList.Spells.Freeze);
					_spellsChosen--;
					break;
				case (int)SpellList.Spells.Wind:
					GD.Print("Wind removed from the list of spells.");
					EmitSignal(SignalName.SpellDeSelected, (int)SpellList.Spells.Wind);
					_spellsChosen--;
					break;
				case (int)SpellList.Spells.Earth:
					GD.Print("Earth removed from the list of spells.");
					EmitSignal(SignalName.SpellDeSelected, (int)SpellList.Spells.Earth);
					_spellsChosen--;
					break;
				default:
					GD.PrintErr("Unkown button pressed...how did it get here???");
					break;
			}
		}
		else GD.PrintErr("What?? This shouldn't happen...");
	}
	
	private void HandleSpellOverflow(int spell)
	{
		switch(spell)
		{
			case (int)SpellList.Spells.Ignite:
				_ignite.ButtonPressed = false;
				break;
			case (int)SpellList.Spells.Teleport:
				_teleport.ButtonPressed = false;
				break;
			case (int)SpellList.Spells.Freeze:
				_freeze.ButtonPressed = false;
				break;
			case (int)SpellList.Spells.Wind:
				_wind.ButtonPressed = false;
				break;
			case (int)SpellList.Spells.Earth:
				_earth.ButtonPressed = false;
				break;
			default:
				GD.PrintErr("Uhh, this button isn't supposed to be here");
				break;
		}
	}

}
