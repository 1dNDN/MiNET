using MiNET.Blocks;
using MiNET.Worlds.Generator.GenUtils;

namespace MiNET.Worlds.Generator
{
	public class Heightmap
	{
		private BitArray data = new BitArray(9, 256);
		private IBlockMatcherReaderAware<Block> BlockMatcher;
		private ChunkColumn chunk;

		public Heightmap(ChunkColumn chunk, Type type)
		{
			this.chunk = chunk;
		}

		public void Generate()
		{
			int i = chunk.GetTopFilledSegment() + 16;

			BlockPos blockPos = new BlockPos(0, 0, 0);

			for (int j = 0; j < 16; ++j)
			for (int k = 0; k < 16; ++k)
				Set(j, k, GenerateColumn(blockPos, j, k, BlockMatcher, i));
		}

		private int GenerateColumn(
			BlockPos blockPos,
			int x,
			int z,
			IBlockMatcherReaderAware<Block> blockMatcher,
			int topFilledY)
		{
			for (int i = topFilledY - 1; i >= 0; --i)
			{
				blockPos.SetPos(x, i, z);
				Block iblock = BlockFactory.GetBlockById(chunk.GetBlock(blockPos.GetX(), blockPos.GetY(), blockPos.GetZ()));

				if (blockMatcher.Test(iblock, chunk, blockPos)) return i + 1;
			}

			return 0;
		}

		private void Set(int x, int z, int value)
		{
			data.SetAt(GetDataArrayIndex(x, z), value);
		}

		private static int GetDataArrayIndex(int x, int z)
		{
			return x + z * 16;
		}

		public class Type
		{
			private IBlockMatcherReaderAware<Block>[] BlockMatcher;
			private string Id;
			private Usage Usage;

			public Type(string id, Usage usage, IBlockMatcherReaderAware<Block>[] blockMatcher)
			{
				Id = id;
				BlockMatcher = blockMatcher;
				Usage = usage;
			}

			public IBlockMatcherReaderAware<Block>[] GetBlockMatcher()
			{
				return BlockMatcher;
			}

			public string GetId()
			{
				return Id;
			}

			public Usage GetUsage()
			{
				return Usage;
			}
		}

		//public static class Types
		//{
		//	public static Type WORLD_SURFACE_WG = new Type("WORLD_SURFACE_WG", Usage.WorldGen, BlockMatcherReaderAware.ForBlock(new Air()));

		//	public static Type OCEAN_FLOOR_WG = new Type("OCEAN_FLOOR_WG", Usage.WorldGen, new
		//	{
		//		BlockMatcherReaderAware.ForBlock(new Air()),
		//		LiquidBlockMatcher.getInstance()
		//	});

		//	public static Type LIGHT_BLOCKING = new Type("LIGHT_BLOCKING", Usage.WorldGen, new
		//	{
		//		BlockMatcherReaderAware.forBlock(new Air()),
		//		LightEmittingMatcher.getInstance()
		//	});

		//	public static Type MOTION_BLOCKING = new Type("MOTION_BLOCKING", Usage.WorldGen, new
		//	{
		//		BlockMatcherReaderAware.forBlock(new Air()),
		//		AllowsMovementAndSolidMatcher.getInstance()
		//	});

		//	public static Type MOTION_BLOCKING_NO_LEAVES = new Type("MOTION_BLOCKING_NO_LEAVES", Usage.LiveWorld, new
		//	{
		//		BlockMatcherReaderAware.forBlock(new Air()),
		//		BlockTagMatcher.forTag(BlockTags.LEAVES),
		//		AllowsMovementAndSolidMatcher.getInstance()
		//	});

		//	public static Type OCEAN_FLOOR = new Type("OCEAN_FLOOR", Usage.WorldGen, new
		//	{
		//		BlockMatcherReaderAware.forBlock(new Air()),
		//		AllowsMovementMatcher.getInstance()
		//	});

		//	public static Type WORLD_SURFACE = new Type("WORLD_SURFACE", Usage.LiveWorld, BlockMatcherReaderAware.forBlock(new Air()));
		//}

		public enum Usage
		{
			WorldGen,
			LiveWorld
		}
	}
}