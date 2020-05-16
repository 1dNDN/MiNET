using System;
using System.Collections.Generic;
using System.Text;

using MiNET.Blocks;
using MiNET.Worlds.Generator.SurfaceBuilders;

namespace MiNET.Worlds.NBiomes
{
	class DesertBiome:NBiome
	{
		public DesertBiome():base(new NBiome.BiomeBuilder()
			.SetSurfaceBuilder(new CompositeSurfaceBuilder(new DefaultSurfaceBuilder(), new SurfaceBuilderConfig(new Sand(), new Sand(), new Gravel())))
			.SetPrecipitation(NBiome.RainType.None)
			.SetCategory(NBiome.Categories.Desert)
			.SetDepth(0.125F)
			.SetScale(0.05F)
			.SetTemperature(2.0F)
			.SetDownfall(0.0F)
			.SetWaterColor(4159204)
			.SetWaterFogColor(329011)
			.SetParent((String) null))
		{
			
		}
	}
}
