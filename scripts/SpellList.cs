using Godot;
using System;
using System.Reflection.Metadata;

public partial class SpellList : Node
{
	public SpellList Instance { get; private set; }
	
	public enum Spells : int
	{
		Ignite,
		Teleport,
		Freeze,
		Wind,
		Earth
	}

	
	
	public override void _Ready()
	{
		Instance = this;
	}
}
