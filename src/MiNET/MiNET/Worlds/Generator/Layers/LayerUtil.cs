using System;

using JetBrains.Annotations;

using MiNET.Worlds.Generator.Layers.GenLayers;

namespace MiNET.Worlds.Generator.Area
{
	public static class LayerUtil
	{
		public static int WARM_OCEAN = 44;
		public static int LUKEWARM_OCEAN = 45;
		public static int OCEAN = 0;
		public static int COLD_OCEAN = 46;
		public static int FROZEN_OCEAN = 10;
		public static int DEEP_WARM_OCEAN = 47;
		public static int DEEP_LUKEWARM_OCEAN = 48;
		public static int DEEP_OCEAN = 24;
		public static int DEEP_COLD_OCEAN = 49;
		public static int DEEP_FROZEN_OCEAN = 50;

		public static GenLayer[] BuildOverworldProcedure<T>([CanBeNull] OverWorldGenSettings overWorldGenSettings, long seed) where T : IArea
		{
			Func<long, LazyAreaLayerContext> func = context => new LazyAreaLayerContext(seed, context);
			IAreaFactory<T> iAreaFactory;
			iAreaFactory = GenLayerIsland.Apply(iAreaFactory, );
		}
	}
}