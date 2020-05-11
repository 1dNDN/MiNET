using System;

using MiNET.Worlds.Generator;

namespace MiNET.Worlds.NBiomes
{
	class OverworldBiomeProvider : NBiomeProvider
	{
		private GenLayer genBiomes;
		private GenLayer biomeFactoryLayer;

		public OverworldBiomeProvider()
		{
			//GenLayer[] agenlayer = LayerUtil.buildOverworldProcedure(worldinfo.getSeed(), worldinfo.getTerrainType(), overworldgensettings);
			this.genBiomes = agenlayer[0];
			this.biomeFactoryLayer = agenlayer[1];
		}
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

			biomeFactoryLayer.GenerateBiomes(x, z, width, length, biome);
		}
	}
}