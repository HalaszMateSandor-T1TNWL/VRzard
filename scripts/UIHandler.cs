using Godot;
using System;
using System.Collections.Generic;
using System.Dynamic;

public partial class UIHandler : VBoxContainer
{
	private List<Button> _buttons = [];

	public override void _Ready()
	{
		_buttons.Add(GetNode<Button>($"Spell#1"));
		_buttons.Add(GetNode<Button>($"Spell#2"));
		_buttons.Add(GetNode<Button>($"Spell#3"));
		_buttons.Add(GetNode<Button>($"Spell#4"));
	}

	private void OnRegisterNameRequest(int spell)
	{
		switch (spell)
		{
			case (int)SpellList.Spells.Ignite:
				_buttons[1].Text = "Ignite";
				break;
			case (int)SpellList.Spells.Teleport:
				_buttons[2].Text = "Teleport";
				break;
			case (int)SpellList.Spells.Wind:
				_buttons[3].Text = "Wind";
				break;
			case (int)SpellList.Spells.Earth:
				_buttons[4].Text = "Earth";
				break;
			default:
				break;
		}
	}

	private void OnRegisterShapeRequest(int spell)
	{
		GD.Print("To be done....");
	}

	private List<Button> GetFreeButtons()
	{
		List<Button> freeButtons = [];

		return freeButtons;
	} 

}
