//2020 1dndn

using System;

namespace MiNET.Worlds.Generator
{
	public class SimplexNoise
	{
		private static int[][] Grad3 =
		{
			new[]
			{
				1,
				1,
				0
			},
			new[]
			{
				-1,
				1,
				0
			},
			new[]
			{
				1,
				-1,
				0
			},
			new[]
			{
				-1,
				-1,
				0
			},
			new[]
			{
				1,
				0,
				1
			},
			new[]
			{
				-1,
				0,
				1
			},
			new[]
			{
				1,
				0,
				-1
			},
			new[]
			{
				-1,
				0,
				-1
			},
			new[]
			{
				0,
				1,
				1
			},
			new[]
			{
				0,
				-1,
				1
			},
			new[]
			{
				0,
				1,
				-1
			},
			new[]
			{
				0,
				-1,
				-1
			}
		};

		public static readonly double Sqrt3 = Math.Sqrt(3.0D);
		private static readonly double F2 = 0.5D * (Sqrt3 - 1.0D); //угловое смещение 
		private static readonly double G2 = (3.0D - Sqrt3) / 6.0D; // тоже смещение
		private int[] p = new int[512]; // половина массива занята от нуля до 256
		public double xCoord;
		public double yCoord;
		public double zCoord;

		public SimplexNoise(LongRandom seed)
		{
			xCoord = seed.NextDouble() * 256.0D; //создаем х сид
			yCoord = seed.NextDouble() * 256.0D; //создаем y сид
			zCoord = seed.NextDouble() * 256.0D; //создаем z сид

			for (int i = 0; i < 256; p[i] = i++) ; // заполняем половину массива

			for (int iterator = 0; iterator < 256; ++iterator)
			{
				// рандомизируем массив
				int randomInt = seed.NextInt(256 - iterator) + iterator;
				int k = p[iterator];
				p[iterator] = p[randomInt];
				p[randomInt] = k;
				p[iterator + 256] = p[iterator];
			}
		}

		private static int FastFloor(double value) // округляем одним if-else
		{
			// return value > 0.0D ? (int) value : (int) value - 1;

			if (value > 0.0D) return (int) value;

			return (int) value - 1;
		}

		private static double Dot(int[] u, double vX, double vY)
		{
			return u[0] * vX + u[1] * vY;
		}

		public double GetValue(double x, double y)
		{
			double d3 = 0.5D * (Sqrt3 - 1.0D);
			double d4 = (x + y) * d3;
			int i = FastFloor(x + d4);
			int j = FastFloor(y + d4);
			double d5 = (3.0D - Sqrt3) / 6.0D;
			double d6 = (i + j) * d5;
			double d7 = i - d6;
			double d8 = j - d6;
			double d9 = x - d7;
			double d10 = y - d8;
			int k;
			int l;

			if (d9 > d10)
			{
				k = 1;
				l = 0;
			}
			else
			{
				k = 0;
				l = 1;
			}

			double d11 = d9 - k + d5;
			double d12 = d10 - l + d5;
			double d13 = d9 - 1.0D + 2.0D * d5;
			double d14 = d10 - 1.0D + 2.0D * d5;
			int i1 = i & 255;
			int j1 = j & 255;
			int k1 = p[i1 + p[j1]] % 12;
			int l1 = p[i1 + k + p[j1 + l]] % 12;
			int i2 = p[i1 + 1 + p[j1 + 1]] % 12;
			double d15 = 0.5D - d9 * d9 - d10 * d10;
			double d0;

			if (d15 < 0.0D)
				d0 = 0.0D;
			else
			{
				d15 = d15 * d15;
				d0 = d15 * d15 * Dot(Grad3[k1], d9, d10);
			}

			double d16 = 0.5D - d11 * d11 - d12 * d12;
			double d1;

			if (d16 < 0.0D)
				d1 = 0.0D;
			else
			{
				d16 = d16 * d16;
				d1 = d16 * d16 * Dot(Grad3[l1], d11, d12);
			}

			double d17 = 0.5D - d13 * d13 - d14 * d14;
			double d2;

			if (d17 < 0.0D)
				d2 = 0.0D;
			else
			{
				d17 = d17 * d17;
				d2 = d17 * d17 * Dot(Grad3[i2], d13, d14);
			}

			return 70.0D * (d0 + d1 + d2);
		}

		public void Add(
			double[] targetArray,
			double startX,
			double startY,
			int xSize,
			int ySize,
			double xScale,
			double yScale,
			double noiseScale)
		{
			int i = 0;

			for (int j = 0; j < ySize; ++j)
			{
				double d0 = (startY + j) * yScale + yCoord;

				for (int k = 0; k < xSize; ++k)
				{
					double d1 = (startX + k) * xScale + xCoord;
					double d5 = (d1 + d0) * F2;
					int l = FastFloor(d1 + d5);
					int i1 = FastFloor(d0 + d5);
					double d6 = (l + i1) * G2;
					double d7 = l - d6;
					double d8 = i1 - d6;
					double d9 = d1 - d7;
					double d10 = d0 - d8;
					int j1;
					int k1;

					if (d9 > d10)
					{
						j1 = 1;
						k1 = 0;
					}
					else
					{
						j1 = 0;
						k1 = 1;
					}

					double d11 = d9 - j1 + G2;
					double d12 = d10 - k1 + G2;
					double d13 = d9 - 1.0D + 2.0D * G2;
					double d14 = d10 - 1.0D + 2.0D * G2;
					int l1 = l & 255;
					int i2 = i1 & 255;
					int j2 = p[l1 + p[i2]] % 12;
					int k2 = p[l1 + j1 + p[i2 + k1]] % 12;
					int l2 = p[l1 + 1 + p[i2 + 1]] % 12;
					double d15 = 0.5D - d9 * d9 - d10 * d10;
					double d2;

					if (d15 < 0.0D)
						d2 = 0.0D;
					else
					{
						d15 = d15 * d15;
						d2 = d15 * d15 * Dot(Grad3[j2], d9, d10);
					}

					double d16 = 0.5D - d11 * d11 - d12 * d12;
					double d3;

					if (d16 < 0.0D)
						d3 = 0.0D;
					else
					{
						d16 = d16 * d16;
						d3 = d16 * d16 * Dot(Grad3[k2], d11, d12);
					}

					double d17 = 0.5D - d13 * d13 - d14 * d14;
					double d4;

					if (d17 < 0.0D)
						d4 = 0.0D;
					else
					{
						d17 = d17 * d17;
						d4 = d17 * d17 * Dot(Grad3[l2], d13, d14);
					}

					int i3 = i++;
					targetArray[i3] += 70.0D * (d2 + d3 + d4) * noiseScale;
				}
			}
		}
	}
}