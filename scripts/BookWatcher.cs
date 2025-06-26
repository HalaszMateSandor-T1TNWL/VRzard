using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class BookWatcher : RayCast3D
{
	private Node3D _book;

	public override void _PhysicsProcess(double delta)
	{
		_book = GetNode<Node3D>($"../Spellbook");
		_book.SetVisible(false);
		
		if (IsColliding())
		{
			var target = GetCollider() as Node;
			if (target != null && target.Name == "HeadArea")
			{
				_book.SetVisible(true);
			}
		}
	}
}
