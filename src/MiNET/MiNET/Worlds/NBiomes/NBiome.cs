using System;
using System.Collections.Generic;
using System.Text;

using JetBrains.Annotations;

using MiNET.Worlds.Generator;

namespace MiNET.Worlds.NBiomes
{
	public class NBiome
	{
		public PerlinNoise TemperatureNoise = new PerlinNoise(new LongRandom(1234L), 1);
		public PerlinNoise InfoNoise = new PerlinNoise(new LongRandom(2345L), 1);
		[CanBeNull] public string TranslationKey;
		public float Depth;
		public float Scale;
		public float Temperature;
		public float Downfall;
		public int WaterColor;
		public int WaterFogColor;
		[CanBeNull] public string Parent;

		public NBiome.Category Category;
		public NBiome.RainType Precipitation;

	}
}
