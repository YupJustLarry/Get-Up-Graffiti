using Sandbox.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

public class Hud : RootPanel
{
	public static Hud Current;

	public Hud()
	{
		if(Current != null)
		{
			Current?.Delete();
			Current = null;
		}

		AddChild<ChatBox>();

		Current = this;
	}
}

