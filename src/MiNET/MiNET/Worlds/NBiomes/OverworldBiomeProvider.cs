﻿using System;

using MiNET.Utils;
using MiNET.Worlds.Generator;
using MiNET.Worlds.Generator.Area;
using MiNET.Worlds.Generator.GenUtils;

namespace MiNET.Worlds.NBiomes
{
	class OverworldBiomeProvider : NBiomeProvider
	{
		private GenLayer biomeFactoryLayer;
		private GenLayer genBiomes;

		public OverworldBiomeProvider()
		{
			var overWorldGenSettings = new OverWorldGenSettings();
			int seed = Config.GetProperty("Seed", "1234").ToLower().Trim().GetHashCode(); //todo: 64 bit hash
			//GenLayer[] agenlayer = LayerUtil.BuildOverworldProcedure<LazyArea>(overWorldGenSettings, seed);
			genBiomes = new GenLayer(); /*agenlayer[0];*/
			biomeFactoryLayer = new GenLayer(); /*agenlayer[1];*/
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
			return GetBiomes(startX, startZ, xSize, zSize, true);
		}

		public override NBiome[] GetBiomes(
			int x,
			int z,
			int width,
			int length,
			bool catheFlag)
		{
			return biomeFactoryLayer.GenerateBiomes(x, z, width, length, new DesertBiome());
		}
	}
}