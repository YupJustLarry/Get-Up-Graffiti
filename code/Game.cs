using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public partial class GraffitiGame : Sandbox.Game
{
	public GraffitiGame()
	{
		if ( IsClient )
			_ = new Hud();
	}

	[Event.Hotload]
	public void Hotload()
	{
		if ( IsClient )
			_ = new Hud();
	}

	public override void DoPlayerSuicide( Client cl )
	{
		//Don't allow suiciding
	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var pawn = new Pawn(client);
		pawn.Spawn();
		client.Pawn = pawn;
	}
}
