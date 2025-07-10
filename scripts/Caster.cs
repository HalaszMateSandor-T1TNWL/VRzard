using Godot;
using System;

public partial class Caster : RayCast3D
{
	private void OnBookWatcherEnabledState(bool value)
	{
		if (value == false)
		{
			this.Enabled = true;
		}
		else if (value == true)
		{
			this.Enabled = false;
		}
	}

}
