using System;

using MiNET.Worlds.Generator;

namespace MiNET.Worlds.NBiomes
{
	class OverworldBiomeProvider : NBiomeProvider
	{
		public override NBiome GetBiome(BlockPos pos, NBiome defaultBiome)
		{
			return defaultBiome;
		}

		public override NBiome[] GetBiomes(
			int startX,
			int startZ,
			int xSize,
			int zSize)
		{
			throw new NotImplementedException();
		}

		public override NBiome[] GetBiomes(
			int x,
			int z,
			int width,
			int length,
			bool catheFlag)
		{
			var biome = new NBiome(); //todo:add biome
			biomeFactoryLayer.GenerateBiomes(x, z, width, length, biome);
		}
	}
}