namespace MiNET.Worlds.Generator
{
	class BlockPos:Vec3i
	{
		public static BlockPos Origin = new BlockPos(0, 0, 0);
		private static int NumXBits = 1 + MathHelper.log2(MathHelper.smallestEncompassingPowerOfTwo(30000000));
		private static int NumZBits = NumXBits;
		private static int NumYBits = 64 - NumXBits - NumZBits;
		private static int YShift = 0 + NumZBits;
		private static int XShift = YShift + NumYBits;
		private static long XMask = (1L << NumXBits) - 1L;
		private static long YMask = (1L << NumYBits) - 1L;
		private static long ZMask = (1L << NumZBits) - 1L;

		public BlockPos(int x, int y, int z) : base(x, y, z) { }

		public BlockPos(double x, double y, double z) : base(x, y, z) { }
	}
}
