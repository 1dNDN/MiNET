using JetBrains.Annotations;

using MiNET.Worlds.Generator;

namespace MiNET.Worlds.NBiomes
{
	public class NBiome
	{
		public NBiome.Category Category;
		public float Depth;
		public float Downfall;
		public PerlinNoise InfoNoise = new PerlinNoise(new LongRandom(2345L), 1);
		[CanBeNull] public string Parent;
		public NBiome.RainType Precipitation;
		public float Scale;
		public float Temperature;
		public PerlinNoise TemperatureNoise = new PerlinNoise(new LongRandom(1234L), 1);
		[CanBeNull] public string TranslationKey;
		public int WaterColor;
		public int WaterFogColor;
	}
}