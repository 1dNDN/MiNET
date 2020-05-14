using System;

using JetBrains.Annotations;

using MiNET.Blocks;
using MiNET.Worlds.Generator;
using MiNET.Worlds.Generator.SurfaceBuilders;

namespace MiNET.Worlds.NBiomes
{
	public class NBiome
	{
		public enum Categories
		{
			None,
			Taiga,
			ExtremeHills,
			Jungle,
			Mesa,
			Plains,
			Savanna,
			Icy,
			Theend,
			Beach,
			Forest,
			Ocean,
			Desert,
			River,
			Swamp,
			Mushroom,
			Nether
		}

		public enum RainType
		{
			None,
			Rain,
			Snow
		}

		public enum TempCategory
		{
			Ocean,
			Cold,
			Medium,
			Warm
		}

		public static SurfaceBuilderConfig AIR_SURFACE = new SurfaceBuilderConfig(new Air(), new Air(), new Air());
		public Categories Category;
		public float Depth;
		public float Downfall;
		public PerlinNoise InfoNoise = new PerlinNoise(new LongRandom(2345L), 1);
		[CanBeNull] public string Parent;
		public RainType Precipitation;
		public float Scale;
		public CompositeSurfaceBuilder SurfaceBuilder;
		public float Temperature;
		public PerlinNoise TemperatureNoise = new PerlinNoise(new LongRandom(1234L), 1);
		[CanBeNull] public string TranslationKey;
		public int WaterColor;
		public int WaterFogColor;

		private NBiome(BiomeBuilder biomeBuilder)
		{
			if (biomeBuilder.SurfaceBuilder != null && biomeBuilder.Precipitation != null && biomeBuilder.Category != null && biomeBuilder.Depth != null && biomeBuilder.Scale != null && biomeBuilder.Temperature != null && biomeBuilder.Downfall != null && biomeBuilder.WaterColor != null && biomeBuilder.WaterFogColor != null)
			{
				SurfaceBuilder = biomeBuilder.SurfaceBuilder;
				Precipitation = (RainType) biomeBuilder.Precipitation;
				Category = (Categories) biomeBuilder.Category;
				Depth = (float) biomeBuilder.Depth;
				Scale = (float) biomeBuilder.Scale;
				Temperature = (float) biomeBuilder.Temperature;
				Downfall = (float) biomeBuilder.Downfall;
				WaterColor = (int) biomeBuilder.WaterColor;
				WaterFogColor = (int) biomeBuilder.WaterFogColor;
				Parent = biomeBuilder.Parent;
			}
			else
				throw new ArgumentNullException();
		}

		public bool IsMutation()
		{
			return Parent != null;
		}

		public void BuildSurface(
			LongRandom random,
			ChunkColumn chunk,
			int x,
			int z,
			int startHeight,
			double noise,
			Block defaultBlock,
			Block defaultFluid,
			int seaLevel,
			long seed)
		{
			SurfaceBuilder.SetSeed(seed);
			SurfaceBuilder.BuildSurface(random, chunk, this, x, z, startHeight, noise, defaultBlock, defaultFluid, seaLevel, seed, AIR_SURFACE);
		}

		public class BiomeBuilder
		{
			public Categories? Category;

			public float? Depth;

			public float? Downfall;

			[CanBeNull] public string Parent;

			public RainType? Precipitation;

			public float? Scale;
			public CompositeSurfaceBuilder? SurfaceBuilder;

			public float? Temperature;

			public int? WaterColor;

			public int? WaterFogColor;

			public BiomeBuilder SetSurfaceBuilder(CompositeSurfaceBuilder surfaceBuilder)
			{
				SurfaceBuilder = surfaceBuilder;

				return this;
			}

			public BiomeBuilder SetPrecipitation(RainType rainType)
			{
				Precipitation = rainType;

				return this;
			}

			public BiomeBuilder SetCategory(Categories category)
			{
				Category = category;

				return this;
			}

			public BiomeBuilder SetDepth(float depth)
			{
				Depth = depth;

				return this;
			}

			public BiomeBuilder SetScale(float scale)
			{
				Scale = scale;

				return this;
			}

			public BiomeBuilder SetTemperature(float temperature)
			{
				Temperature = temperature;

				return this;
			}

			public BiomeBuilder SetDownfall(float downfall)
			{
				Downfall = downfall;

				return this;
			}

			public BiomeBuilder SetWaterColor(int waterColor)
			{
				WaterColor = waterColor;

				return this;
			}

			public BiomeBuilder SetWaterFogColor(int waterFogColor)
			{
				WaterFogColor = waterFogColor;

				return this;
			}

			public BiomeBuilder SetParent(string parent)
			{
				Parent = parent;

				return this;
			}

			public new string ToString()
			{
				return "BiomeBuilder{" +
						"\nSurfaceBuilder=" + SurfaceBuilder + "," +
						"\nPrecipitation=" + Precipitation + "," +
						"\nBiomeCategory=" + Category + "," +
						"\nDepth=" + Depth + "," +
						"\nScale=" + Scale + "," +
						"\nTemperature=" + Temperature + "," +
						"\nDownfall=" + Downfall + "," +
						"\nWaterColor=" + WaterColor + "," +
						"\nWaterFogColor=" + WaterFogColor + "," +
						"\nParent='" + Parent + '\'' + "" +
						"\n" + '}';
			}
		}
	}
}