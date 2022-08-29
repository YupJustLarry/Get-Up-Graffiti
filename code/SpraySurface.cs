using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using static Sandbox.ModelBuilder;

public static partial class SpraySurface
{
	public static Particles DoSpraySurface( this Surface self, TraceResult tr, string colorType )
	{
		//
		// No effects on resimulate
		//
		if ( !Prediction.FirstTime )
			return null;

		//
		// Drop a decal
		//
		var decalPath = $"materials/spray_{colorType}.decal";

		if ( ResourceLibrary.TryGet<DecalDefinition>( decalPath, out var decal ) )
			Decal.Place( decal, tr );

		return default;
	}
}
