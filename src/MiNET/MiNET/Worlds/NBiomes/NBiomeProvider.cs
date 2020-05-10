using JetBrains.Annotations;

using MiNET.Worlds.Generator;

namespace MiNET.Worlds.NBiomes
{
	abstract class NBiomeProvider
	{
		public void Tick() { }

		[CanBeNull]
		public abstract NBiome GetBiome(BlockPos pos, [CanBeNull] NBiome defaultBiome);

		public abstract NBiome[] GetBiomes(
			int startX,
			int startZ,
			int xSize,
			int zSize);

		public abstract NBiome[] GetBiomes(
			int x,
			int z,
			int width,
			int length,
			bool catheFlag);

		public NBiome[] GetBiomeBlock(
			int x,
			int z,
			int width,
			int length)
		{
			return GetBiomes(x, z, width, length, true);
		}
	}
}