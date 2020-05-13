using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

using JetBrains.Annotations;

namespace MiNET.Worlds.Generator.Area
{
	static class LayerUtil
	{

		public static ImmutableList<IAreaFactory<T>> BuildOverworldProcedure<T>([CanBeNull] OverWorldGenSettings overWorldGenSettings, long seed) where T:IArea
		{

		}
	}
}
