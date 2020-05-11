using System;
using System.Collections.Concurrent;
using System.Numerics;

using MiNET.Blocks;
using MiNET.Utils;
using MiNET.Worlds.Generator;
using MiNET.Worlds.NBiomes;

namespace MiNET.Worlds
{
	class NewWorldProvider : IWorldProvider
	{
		private readonly ConcurrentDictionary<ChunkCoordinates, ChunkColumn> chunkCache = new ConcurrentDictionary<ChunkCoordinates, ChunkColumn>();

		public NBiomeProvider BiomeProvider;
		private float[] biomeWeight;
		private OctavesNoise depthNoise;
		private OctavesNoise mainPerlinNoise;
		private OctavesNoise maxLimitPerlinNoise;

		private OctavesNoise minLimitPerlinNoise;
		private OctavesNoise scaleNoise;
		private PerlinNoise surfaceNoise;

		public long Seed { get; set; }

		public bool IsCaching { get; private set; }

		public void Initialize()
		{
			IsCaching = true;
			Seed = Config.GetProperty("Seed", "1234").ToLower().Trim().GetHashCode();
			var sharedSeedRandom = new SharedSeedRandom(Seed);
			minLimitPerlinNoise = new OctavesNoise(sharedSeedRandom, 16);
			maxLimitPerlinNoise = new OctavesNoise(sharedSeedRandom, 16);
			mainPerlinNoise = new OctavesNoise(sharedSeedRandom, 8);
			surfaceNoise = new PerlinNoise(sharedSeedRandom, 4);
			scaleNoise = new OctavesNoise(sharedSeedRandom, 10);
			depthNoise = new OctavesNoise(sharedSeedRandom, 16);
			biomeWeight = new float[25];
			BiomeProvider = new OverworldBiomeProvider();

			for (int i = -2; i <= 2; ++i)
			for (int j = -2; j <= 2; ++j)
			{
				float f = 10.0F / (float) Math.Sqrt(i * i + j * j + 0.2F);
				biomeWeight[i + 2 + (j + 2) * 5] = f;
			}
		}

		public ChunkColumn GenerateChunkColumn(ChunkCoordinates chunkCoordinates, bool cacheOnly = false)
		{
			ChunkColumn cachedChunk;

			if (chunkCache.TryGetValue(chunkCoordinates, out cachedChunk)) return cachedChunk;

			var chunk = new ChunkColumn();
			chunk.x = chunkCoordinates.X;
			chunk.z = chunkCoordinates.Z;

			PopulateChunk(chunk);

			chunkCache[chunkCoordinates] = chunk;

			return chunk;
		}

		public Vector3 GetSpawnPoint()
		{
			return new Vector3(0, 100, 0);
		}

		public string GetName()
		{
			return "New";
		}

		public long GetTime()
		{
			return 0;
		}

		public long GetDayTime()
		{
			return 0;
		}

		public int SaveChunks()
		{
			return 0;
		}

		public bool HaveNether()
		{
			return false;
		}

		public bool HaveTheEnd()
		{
			return false;
		}

		private void PopulateChunk(ChunkColumn chunk)
		{
			var sharedSeedRandom = new SharedSeedRandom();
			sharedSeedRandom.SetBaseChunkSeed(chunk.x, chunk.z);
			NBiome[] abiome = BiomeProvider.GetBiomeBlock(chunk.x * 16, chunk.z * 16, 16, 16);
			chunk.SetNBiomes(abiome);
			SetBlocksInChunk(chunk.x, chunk.z, chunk);
		}

		private void SetBlocksInChunk(int chunkX, int chunkZ, ChunkColumn chunk)
		{
			var adouble = new double[825];
			GenerateHeightMap(chunk.x * 4, 0, chunk.z * 4, adouble);

			for (int i = 0; i < 4; ++i)
			{
				int j = i * 5;
				int k = (i + 1) * 5;

				for (int l = 0; l < 4; ++l)
				{
					int i1 = (j + l) * 33;
					int j1 = (j + l + 1) * 33;
					int k1 = (k + l) * 33;
					int l1 = (k + l + 1) * 33;

					for (int i2 = 0; i2 < 32; ++i2)
					{
						double d0 = 0.125D;
						double d1 = adouble[i1 + i2];
						double d2 = adouble[j1 + i2];
						double d3 = adouble[k1 + i2];
						double d4 = adouble[l1 + i2];
						double d5 = (adouble[i1 + i2 + 1] - d1) * 0.125D;
						double d6 = (adouble[j1 + i2 + 1] - d2) * 0.125D;
						double d7 = (adouble[k1 + i2 + 1] - d3) * 0.125D;
						double d8 = (adouble[l1 + i2 + 1] - d4) * 0.125D;

						for (int j2 = 0; j2 < 8; ++j2)
						{
							double d9 = 0.25D;
							double d10 = d1;
							double d11 = d2;
							double d12 = (d3 - d1) * 0.25D;
							double d13 = (d4 - d2) * 0.25D;

							for (int k2 = 0; k2 < 4; ++k2)
							{
								double d14 = 0.25D;
								double d16 = (d11 - d10) * 0.25D;
								double d17 = d10 - d16;

								for (int l2 = 0; l2 < 4; ++l2)
								{
									int x = i * 4 + k2;
									int y = i2 * 8 + j2;
									int z = l * 4 + l2;
									Block block = new Air();

									if ((d17 += d16) > 0.0D)
										block = new Stone();
									else if (i2 * 8 + j2 < 63) block = new Water();
									chunk.SetBlock(x, y, z, block.Id);
								}

								d10 += d12;
								d11 += d13;
							}

							d1 += d5;
							d2 += d6;
							d3 += d7;
							d4 += d8;
						}
					}
				}
			}
		}

		private void GenerateHeightMap(
			int x,
			int y,
			int z,
			double[] p_202108_5_)
		{
			double[] adouble = depthNoise.Add(x, z, 5, 5, 200.0D, 200.0D, 0.5D);
			float coordinateScale = 684.412F;
			float heightScale = 684.412F;

			double[] adouble1 = mainPerlinNoise.Add(x, y, z, 5, 33, 5,
				coordinateScale / 80.0F, heightScale / 160.0F, coordinateScale / 80.0F);
			double[] adouble2 = minLimitPerlinNoise.Add(x, y, z, 5, 33, 5, coordinateScale, heightScale, coordinateScale);
			double[] adouble3 = maxLimitPerlinNoise.Add(x, y, z, 5, 33, 5, coordinateScale, heightScale, coordinateScale);
			int i = 0;
			int j = 0;

			for (int k = 0; k < 5; ++k)
			for (int l = 0; l < 5; ++l)
			{
				float f2 = 0.0F;
				float f3 = 0.0F;
				float f4 = 0.0F;
				int i1 = 2;

				for (int j1 = -2; j1 <= 2; ++j1)
				for (int k1 = -2; k1 <= 2; ++k1)
				{
					float f5 = 0.0F + 0.45F * 1.0F;
					float f6 = 0.0F + 0.3F * 1.0F;

					float f7 = biomeWeight[j1 + 2 + (k1 + 2) * 5] / (f5 + 2.0F);

					f2 += f6 * f7;
					f3 += f5 * f7;
					f4 += f7;
				}

				f2 = f2 / f4;
				f3 = f3 / f4;
				f2 = f2 * 0.9F + 0.1F;
				f3 = (f3 * 4.0F - 1.0F) / 8.0F;
				double d7 = adouble[j] / 8000.0D;
				if (d7 < 0.0D) d7 = -d7 * 0.3D;

				d7 = d7 * 3.0D - 2.0D;

				if (d7 < 0.0D)
				{
					d7 = d7 / 2.0D;
					if (d7 < -1.0D) d7 = -1.0D;

					d7 = d7 / 1.4D;
					d7 = d7 / 2.0D;
				}
				else
				{
					if (d7 > 1.0D) d7 = 1.0D;

					d7 = d7 / 8.0D;
				}

				++j;
				double d8 = f3;
				double d9 = f2;
				d8 = d8 + d7 * 0.2D;
				d8 = d8 * 8.5D / 8.0D;
				double d0 = 8.5D + d8 * 4.0D;

				for (int l1 = 0; l1 < 33; ++l1)
				{
					double d1 = (l1 - d0) * 12.0D * 128.0D / 256.0D / d9;
					if (d1 < 0.0D) d1 *= 4.0D;

					double d2 = adouble2[i] / 512.0D;
					double d3 = adouble3[i] / 512.0D;
					double d4 = (adouble1[i] / 10.0D + 1.0D) / 2.0D;
					double d5 = MathHelper.ClampedLerp(d2, d3, d4) - d1;

					if (l1 > 29)
					{
						double d6 = (l1 - 29) / 3.0F;
						d5 = d5 * (1.0D - d6) - 10.0D * d6;
					}

					p_202108_5_[i] = d5;
					++i;
				}
			}
		}

		public void BuildSurface(
			ChunkColumn chunk,
			NBiome[] biomes,
			SharedSeedRandom random,
			int seaLevel)
		{
			double d0 = 0.03125D;
			var chunkpos = new ChunkPos(chunk);
			int i = chunkpos.GetXStart();
			int j = chunkpos.GetZStart();
			double[] adouble = GenerateNoiseRegion(chunkpos.X, chunkpos.Z);

			for (int k = 0; k < 16; ++k)
			for (int l = 0; l < 16; ++l)
			{
				int i1 = i + k;
				int j1 = j + l;
				int k1 = chunk.GetTopBlockY(k, l) + 1;
				biomes[l * 16 + k].BuildSurface(random, chunk, i1, j1, k1, adouble[l * 16 + k], new Stone(), new Water(), seaLevel, Seed);
			}
		}

		private double[] GenerateNoiseRegion(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}