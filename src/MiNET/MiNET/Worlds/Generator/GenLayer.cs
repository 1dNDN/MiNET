using System;
using System.Collections.Generic;
using System.Text;

using JetBrains.Annotations;

using MiNET.Worlds.Generator.Area;
using MiNET.Worlds.NBiomes;

namespace MiNET.Worlds.Generator
{
	class GenLayer
	{
		private IAreaFactory<LazyArea> LazyAreaFactory;

		public GenLayer(IAreaFactory<LazyArea> lazyAreaFactory)
		{
			LazyAreaFactory = lazyAreaFactory;
		}

		public NBiome[] GenerateBiomes(
			int startX,
			int startZ,
			int xSize,
			int zSize,
			[CanBeNull] NBiome defaultBiome)
		{
			AreaDimension areadimension = new AreaDimension(startX, startZ, xSize, zSize);
			LazyArea lazyarea = LazyAreaFactory.Make(areadimension);
			NBiome[] abiome = new NBiome[xSize * zSize];
			for (int i = 0; i < zSize; ++i)
			{
				for (int j = 0; j < xSize; ++j)
				{
					abiome[j + i * xSize] = NBiome.GetBiome(lazyarea.GetValue(j, i), defaultBiome);
				}
			}

			return abiome;
		}
	}
}
