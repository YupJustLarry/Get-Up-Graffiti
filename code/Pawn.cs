using Sandbox;
using System;
using System.Linq;


partial class Pawn : Player
{
	ClothingContainer clothing = new();
	string sprayColor;
	int sprayIndex;

	public Pawn()
	{

	}

	public Pawn( Client cl ) : this()
	{
		clothing.LoadFromClient( cl );
	}

	public override void Spawn()
	{
		CreateHull();
		Tags.Add( "gplayer" );

		var spawnpoints = All.OfType<SpawnPoint>().OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( spawnpoints != null )
			Transform = spawnpoints.Transform;

		SetModel( "models/citizen/citizen.vmdl" );
		clothing.DressEntity( this );

		CameraMode = new FirstPersonCamera();
		Animator = new StandardPlayerAnimator();
		Controller = new WalkController();

		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		sprayColor = "white";
		sprayIndex = 1;
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );

		if( IsServer )
		{
			//Spray
			if(Input.Down(InputButton.PrimaryAttack) )
				Spray();

			if (Input.Pressed(InputButton.SecondaryAttack) )
				SwitchSpray();
		}
	}

	public void SwitchSpray()
	{
		sprayIndex++;
		if ( sprayIndex > 3 ) sprayIndex = 0;

		switch(sprayIndex)
		{
			case 0:
				sprayColor = "red";
				break;
			case 1:
				sprayColor = "green";
				break;
			case 2:
				sprayColor = "blue";
				break;
			case 3:
				sprayColor = "white";
				break;
		}

	}

	public void Spray()
	{
		//Trace ray
		//Ignores this pawn and other players
		var tr = Trace.Ray( EyePosition, EyePosition + EyeRotation.Forward * 150 )
			.Ignore( this )
			.WithoutTags( "gplayer" )
			.Run();

		if(tr.Hit)
		{
			if ( !Prediction.FirstTime )
				return;

			tr.Surface.DoSpraySurface( tr, sprayColor );
		}
	}

	public override void FrameSimulate( Client cl )
	{
		base.FrameSimulate( cl );
	}
}
