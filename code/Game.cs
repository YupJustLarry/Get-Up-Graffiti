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
