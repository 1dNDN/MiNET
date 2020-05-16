using MiNET.Blocks;
using MiNET.Worlds.NBiomes;

namespace MiNET.Worlds.Generator.SurfaceBuilders
{
	public interface ISurfaceBuilder
	{
		void BuildSurface(
			LongRandom random,
			ref ChunkColumn chunk,
			NBiome biome,
			int x,
			int z,
			int startHeight,
			double noise,
			Block defaultBlock,
			Block defaultFluid,
			int seaLevel,
			long seed,
			SurfaceBuilderConfig config);

		void SetSeed(long seed);
	}
}