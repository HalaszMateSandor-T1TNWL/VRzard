using Godot;
using System;

public partial class Draw : Node2D
{
	[Export]
	private Color _color;
	[Export]
	private float _width;
	[Export]
	private bool _antialiased;

	private Node2D _lines;
	private bool _pressed;
	private Line2D _currentLine;

	public override void _Ready()
	{
		_lines = GetNode<Node2D>($"Line2D");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton)
		{
			if ((@event as InputEventMouseButton).ButtonIndex == MouseButton.Left)
			{
				_pressed = @event.IsPressed();
				if (_pressed)
				{
					_currentLine = new Line2D
					{
						DefaultColor = _color,
						Width = _width,
						Antialiased = _antialiased
					};
					_lines.AddChild(_currentLine);
					_currentLine.AddPoint((@event as InputEventMouse).GlobalPosition);
				}
			}
		}
		else if (@event is InputEventMouseMotion && _pressed)
		{
			_currentLine.AddPoint((@event as InputEventMouse).GlobalPosition);
		}
	}
}
