using System;
using System.Collections.Generic;
using System.Text;

using MiNET.Blocks;
using MiNET.Worlds.Generator.GenUtils;
using MiNET.Worlds.NBiomes;

namespace MiNET.Worlds.Generator.SurfaceBuilders
{
	class DefaultSurfaceBuilder : ISurfaceBuilder
	{
		public void BuildSurface(LongRandom random, ref ChunkColumn chunk, NBiome biome, int x, int z, int startHeight, double noise, Block defaultBlock, Block defaultFluid, int seaLevel, long seed, SurfaceBuilderConfig config)
		{
			BuildSurface(random, ref chunk, biome, x, z, startHeight, noise, defaultBlock, defaultFluid, config.GetTop(), config.GetMiddle(), config.GetBottom(), seaLevel);
		}

		protected void BuildSurface(LongRandom random, ref ChunkColumn chunk, NBiome biome, int x, int z, int startHeight, double noise, Block defaultBlock, Block defaultFluid, Block top, Block middle, Block bottom, int sealevel)
		{
			Block iblockstate = top;
			Block iblockstate1 = middle;
			BlockPos blockPos;
			int i = -1;
			int j = (int) (noise / 3.0D + 3.0D + random.NextDouble() * 0.25D);
			int k = x & 15;
			int l = z & 15;

			for (int i1 = startHeight; i1 >= 0; --i1)
			{
				blockPos = new BlockPos(k, i1, l);
				Block iblockstate2 = BlockFactory.GetBlockById(chunk.GetBlock(blockPos.GetX(), blockPos.GetY(), blockPos.GetZ()));
				if (iblockstate2 is Air)
				{
					i = -1;
				}
				else if (iblockstate2 == defaultBlock)
				{
					if (i == -1)
					{
						if (j <= 0)
						{
							iblockstate = new Air();
							iblockstate1 = defaultBlock;
						}
						else if (i1 >= sealevel - 4 && i1 <= sealevel + 1)
						{
							iblockstate = top;
							iblockstate1 = middle;
						}

						if (i1 < sealevel && (iblockstate == null || iblockstate is Air))
						{
							if (biome.GetTemperature(blockPos.SetPos(x, i1, z)) < 0.15F)
							{
								iblockstate = new Ice();
							}
							else
							{
								iblockstate = defaultFluid;
							}

							blockPos.SetPos(k, i1, l);
						}

						i = j;
						if (i1 >= sealevel - 1)
						{
							chunk.SetBlock(blockPos, iblockstate.Id);
						}
						else if (i1 < sealevel - 7 - j)
						{
							iblockstate = new Air();
							iblockstate1 = defaultBlock;
							chunk.SetBlock(blockPos, bottom.Id);
						}
						else
						{
							chunk.SetBlock(blockPos, iblockstate1.Id);
						}
					}
					else if (i > 0)
					{
						--i;
						chunk.SetBlock(blockPos, iblockstate1.Id);
						if (i == 0 && iblockstate1 is Sand && j > 1)
						{
							i = random.NextInt(4) + Math.Max(0, i1 - 63);
							iblockstate1 = new Sandstone();
						}
					}
				}
			}

		}

		public void SetSeed(long seed)
		{

		}
	}
}
