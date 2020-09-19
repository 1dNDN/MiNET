using System;
using System.Collections.Generic;
using System.Text;

using MiNET.Worlds.Generator.GenUtils;

namespace MiNET.Worlds.Generator
{
	public interface IBlockMatcherReaderAware<T>
	{
		bool Test(T block, ChunkColumn chunk, BlockPos pos);
	}
}
