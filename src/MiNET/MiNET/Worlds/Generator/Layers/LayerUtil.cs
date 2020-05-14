using System;

using JetBrains.Annotations;

namespace MiNET.Worlds.Generator.Area
{
	static class LayerUtil
	{

		public static GenLayer[] BuildOverworldProcedure<T>([CanBeNull] OverWorldGenSettings overWorldGenSettings, long seed) where T:IArea
		{
			Func<long, LazyAreaLayerContext> func = context => new LazyAreaLayerContext(seed, context);
			IAreaFactory<T> irAreaFactory = 
		}
	}
}
