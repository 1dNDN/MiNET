using System;

namespace MiNET.Worlds.Generator
{
	class BlockPos:Vec3i
	{
		public static BlockPos Origin = new BlockPos(0, 0, 0);
		private static int NumXBits = 1 + MathHelper.Log2(MathHelper.SmallestEncompassingPowerOfTwo(30000000));
		private static int NumZBits = NumXBits;
		private static int NumYBits = 64 - NumXBits - NumZBits;
		private static int YShift = 0 + NumZBits;
		private static int XShift = YShift + NumYBits;
		private static long XMask = (1L << NumXBits) - 1L;
		private static long YMask = (1L << NumYBits) - 1L;
		private static long ZMask = (1L << NumZBits) - 1L;

		public BlockPos(int x, int y, int z) : base(x, y, z) { }

		public BlockPos(double x, double y, double z) : base(x, y, z) { }

		public BlockPos(Vec3i source) : this(source.GetX(), source.GetY(), source.GetZ()) { }

		public BlockPos Add(double x, double y, double z)
		{
			return x == 0.0D && y == 0.0D && z == 0.0D ? this : new BlockPos(GetX() + x, GetY() + y, GetZ() + z);
		}

		public BlockPos Add(int x, int y, int z)
		{
			return x == 0 && y == 0 && z == 0 ? this : new BlockPos(GetX() + x, GetY() + y, GetZ() + z);
		}

		public BlockPos Add(Vec3i vec)
		{
			return Add(vec.GetX(), vec.GetY(), vec.GetZ());
		}

		public BlockPos Subtract(Vec3i vec)
		{
			return Add(-vec.GetX(), -vec.GetY(), -vec.GetZ());
		}

	}
}
