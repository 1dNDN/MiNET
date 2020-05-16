using MiNET.Blocks;
using MiNET.Worlds.NBiomes;

namespace MiNET.Worlds.Generator.SurfaceBuilders
{
	public class CompositeSurfaceBuilder : ISurfaceBuilder
	{
		private SurfaceBuilderConfig Config;
		private ISurfaceBuilder SurfaceBuilder;

		public CompositeSurfaceBuilder(ISurfaceBuilder surfaceBuilder, SurfaceBuilderConfig config)
		{
			SurfaceBuilder = surfaceBuilder;
			Config = config;
		}

		public void BuildSurface(
			LongRandom random,
			ChunkColumn chunk,
			NBiome biome,
			int x,
			int z,
			int startHeight,
			double noise,
			Block defaultBlock,
			Block defaultFluid,
			int seaLevel,
			long seed,
			SurfaceBuilderConfig config)
		{
			SurfaceBuilder.BuildSurface(random, chunk, biome, x, z, startHeight, noise, defaultBlock, defaultFluid, seaLevel, seed, config);
		}

		public void SetSeed(long seed)
		{
			SurfaceBuilder.SetSeed(seed);
		}

		public SurfaceBuilderConfig GetConfig()
		{
			return Config;
		}
	}
}