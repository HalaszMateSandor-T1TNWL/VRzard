using Godot;
using System;
using System.Collections.Generic;

public partial class Glyphs : Node3D
{
	private List<Node3D> _glyphs = [];
	private Node3D _igniteGlyph;
	private Node3D _teleportGlyph;
	private Node3D _windGlyph;
	private Node3D _freezeGlyph;
	private Node3D _earthGlyph;
	private bool _isGlyphShown = false;

	public override void _Ready()
	{
		_glyphs.Add(_igniteGlyph = GetNode<Node3D>("I"));
		_glyphs.Add(_teleportGlyph = GetNode<Node3D>("T"));
		_glyphs.Add(_windGlyph = GetNode<Node3D>("P"));
		_glyphs.Add(_freezeGlyph);
		_glyphs.Add(_earthGlyph);
		
		GlyphSetup();
	}

	private void OnGlyphWakeUpRequest(int spellLetter)
	{
		if (_isGlyphShown == false)
		{
			switch (spellLetter)
			{
				case (int)SpellList.Spells.Ignite:
					_igniteGlyph.Visible = true;
					_isGlyphShown = true;
					break;
				case (int)SpellList.Spells.Teleport:
					_teleportGlyph.Visible = true;
					_isGlyphShown = true;
					break;
				case (int)SpellList.Spells.Wind:
					_windGlyph.Visible = true;
					_isGlyphShown = true;
					break;
				case (int)SpellList.Spells.Freeze:
					_freezeGlyph.Visible = true;
					_isGlyphShown = true;
					break;
				case (int)SpellList.Spells.Earth:
					_earthGlyph.Visible = true;
					_isGlyphShown = true;
					break;
				default:
					break;
			}
		}
	}

	private void OnGlyphSleepRequest(int spellLetter)
	{
		if (_isGlyphShown)
		{
			switch (spellLetter)
			{
				case (int)SpellList.Spells.Ignite:
					_igniteGlyph.Visible = false;
					_isGlyphShown = false;
					break;
				case (int)SpellList.Spells.Teleport:
					_teleportGlyph.Visible = false;
					_isGlyphShown = false;
					break;
				case (int)SpellList.Spells.Wind:
					_windGlyph.Visible = false;
					_isGlyphShown = false;
					break;
				case (int)SpellList.Spells.Freeze:
					_freezeGlyph.Visible = false;
					_isGlyphShown = false;
					break;
				case (int)SpellList.Spells.Earth:
					_earthGlyph.Visible = false;
					_isGlyphShown = false;
					break;
				default:
					break;
			}
		}
	}
	
	private void GlyphSetup()
	{
		foreach (Node3D glyph in _glyphs)
		{
			if (glyph.Visible == true)
			{
				glyph.Visible = false;
			}
		}
	}
	
}
