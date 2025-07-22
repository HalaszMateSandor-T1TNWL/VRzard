using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public partial class Glyphs : Node3D
{
	private List<Node3D> _glyphs = [];
	private Node3D _igniteGlyph;
	private Node3D _teleportGlyph;
	private Node3D _windGlyph;
	private Node3D _freezeGlyph;
	private Node3D _earthGlyph;
	private int _glyphsShown = 0;

	public override void _Ready()
	{
		_glyphs.Add(_igniteGlyph = GetNode<Node3D>("I"));
		_glyphs.Add(_teleportGlyph = GetNode<Node3D>("T"));
		_glyphs.Add(_windGlyph = GetNode<Node3D>("P"));
		_glyphs.Add(_freezeGlyph);
		_glyphs.Add(_earthGlyph);
	}

	private void OnGlyphWakeUpRequest(int spellLetter)
	{
		switch (spellLetter)
		{
			case (int)SpellList.Spells.Ignite:
				_igniteGlyph.Visible = true;
				_glyphsShown++;
				break;
			case (int)SpellList.Spells.Teleport:
				_teleportGlyph.Visible = true;
				_glyphsShown++;
				break;
			case (int)SpellList.Spells.Wind:
				_windGlyph.Visible = true;
				_glyphsShown++;
				break;
			case (int)SpellList.Spells.Freeze:
				_freezeGlyph.Visible = true;
				_glyphsShown++;
				break;
			case (int)SpellList.Spells.Earth:
				_earthGlyph.Visible = true;
				_glyphsShown++;
				break;
			default:
				break;
		}
	}
}
