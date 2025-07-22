using Godot;
using System;
using System.Collections.Generic;
using System.Dynamic;

public partial class UIHandler : VBoxContainer
{

	[Signal]
	public delegate void WakeUpCanvasEventHandler(int spell);

	private List<Button> _buttons = [];

	public override void _Ready()
	{
		_buttons.Add(GetNode<Button>($"Spell#4"));
		_buttons.Add(GetNode<Button>($"Spell#3"));
		_buttons.Add(GetNode<Button>($"Spell#2"));
		_buttons.Add(GetNode<Button>($"Spell#1"));
	}

	private void OnRegisterNameRequest(int spell)
	{
		switch (spell)
		{
			case (int)SpellList.Spells.Ignite:
				if (GetFreeButton() < 0) GD.PrintErr("Index was out of range, something went wrong");
				else _buttons[GetFreeButton()].Text = "Ignite";
				break;
			case (int)SpellList.Spells.Teleport:
				if (GetFreeButton() < 0) GD.PrintErr("Index was out of range, something went wrong");
				else _buttons[GetFreeButton()].Text = "Teleport";
				break;
			case (int)SpellList.Spells.Wind:
				if (GetFreeButton() < 0) GD.PrintErr("Index was out of range, something went wrong");
				else _buttons[GetFreeButton()].Text = "Wind";
				break;
			case (int)SpellList.Spells.Freeze:
				if (GetFreeButton() < 0) GD.PrintErr("Index was out of range, something went wrong");
				else _buttons[GetFreeButton()].Text = "Freeze";
				break;
			case (int)SpellList.Spells.Earth:
				if (GetFreeButton() < 0) GD.PrintErr("Index was out of range, something went wrong");
				else _buttons[GetFreeButton()].Text = "Earth";
				break;
			default:
				break;
		}
	}

	private void OnRegisterShapeRequest(int spell)
	{
		EmitSignal(SignalName.WakeUpCanvas, spell);
	}

	private void OnUnRegisterNameRequest(int spell)
	{
		switch (spell)
		{
			case (int)SpellList.Spells.Ignite:
				if (GetButton("Ignite") < 0) GD.PrintErr("Index out of range, something went wrong");
				else _buttons[GetButton("Ignite")].Text = string.Empty;
				break;
			case (int)SpellList.Spells.Teleport:
				if (GetButton("Teleport") < 0) GD.PrintErr("Index out of range, something went wrong");
				else _buttons[GetButton("Teleport")].Text = string.Empty;
				break;
			case (int)SpellList.Spells.Wind:
				if (GetButton("Wind") < 0) GD.PrintErr("Index out of range, something went wrong");
				else _buttons[GetButton("Wind")].Text = string.Empty;
				break;
			case (int)SpellList.Spells.Freeze:
				if (GetButton("Freeze") < 0) GD.PrintErr("Index out of range, something went wrong");
				else _buttons[GetButton("Freeze")].Text = string.Empty;
				break;
			case (int)SpellList.Spells.Earth:
				if (GetButton("Earth") < 0) GD.PrintErr("Index out of range, something went wrong");
				else _buttons[GetButton("Earth")].Text = string.Empty;
				break;
			default:
				GD.PrintErr("Uhhh, this shouldn't be called...");
				break;
		}
	}

	private int GetButton(string spellName)
	{
		int button = -1;

		for (int i = 0; i < _buttons.Count; i++)
		{
			if (_buttons[i].Text.Equals(spellName)) button = i;
		}

		return button;
	}

	private int GetFreeButton()
	{
		int freeButtonIndex = -1;

		for (int i = 0; i < _buttons.Count; i++)
		{
			if (_buttons[i].Text == string.Empty)
			{
				freeButtonIndex = i;
			}
		}

		return freeButtonIndex;
	} 

}
