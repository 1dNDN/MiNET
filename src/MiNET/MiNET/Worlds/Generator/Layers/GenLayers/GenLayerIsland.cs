using System;
using System.Collections.Generic;
using System.Text;

using MiNET.Worlds.Generator.Area;

namespace MiNET.Worlds.Generator.Layers.GenLayers
{
	static class GenLayerIsland
	{
		public static int Apply(IContext context, AreaDimension areaDimensionIn, int x, int z)
		{
			if (x == -areaDimensionIn.GetStartX() && z == -areaDimensionIn.GetStartZ() && areaDimensionIn.GetStartX() > -areaDimensionIn.GetXSize() && areaDimensionIn.GetStartX() <= 0 && areaDimensionIn.GetStartZ() > -areaDimensionIn.GetZSize() && areaDimensionIn.GetStartZ() <= 0)
			{
				return 1;
			}
			else
			{
				return context.Random(10) == 0 ? 1 : LayerUtil.OCEAN;
			}
		}
	}
}
