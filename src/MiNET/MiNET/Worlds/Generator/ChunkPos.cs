using System;

using MiNET.Entities;

namespace MiNET.Worlds.Generator
{
	class ChunkPos
	{
		public int X;
		public int Z;

		public ChunkPos(int x, int z)
		{
			X = x;
			Z = z;
		}

		public ChunkPos(BlockPos pos)
		{
			X = pos.GetX() >> 4;
			Z = pos.GetZ() >> 4;
		}

		public long AsLong()
		{
			return AsLong(X, Z);
		}

		public static long AsLong(int x, int z)
		{
			return x & 4294967295L | (z & 4294967295L) << 32;
		}

		public new int GetHashCode()
		{
			int i = 1664525 * X + 1013904223;
			int j = 1664525 * (Z ^ -559038737) + 1013904223;
			return i ^ j;
		}

		public new bool Equals(object other)
		{
			if (this == other)
			{
				return true;
			}
			else if (!(other is ChunkPos)) {
				return false;
			} else
			{
				ChunkPos chunkpos = (ChunkPos) other;
				return X == chunkpos.X && Z == chunkpos.Z;
			}
		}

		public int GetXStart()
		{
			return X << 4;
		}

		public int GetZStart()
		{
			return Z << 4;
		}

		public int GetXEnd()
		{
			return (X << 4) + 15;
		}

		public int GetZEnd()
		{
			return (X << 4) + 15;
		}

		public BlockPos GetBlock(int x, int y, int z)
		{
			return new BlockPos((X << 4) + x, y, (Z << 4) + z);
		}

		public new String ToString()
		{
			return "[" + X + ", " + Z + "]";
		}

		public BlockPos AsBlockPos()
		{
			return new BlockPos(X << 4, 0, Z << 4);
		}
	}
}
