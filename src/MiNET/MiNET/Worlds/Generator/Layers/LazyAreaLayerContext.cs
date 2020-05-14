namespace MiNET.Worlds.Generator.Area
{
	class LazyAreaLayerContext : LayerContext
	{
		public LazyAreaLayerContext(long seed, long p_i48647_5_) : base(p_i48647_5_)
		{
			SetSeed(seed);
		}

		public LazyArea MakeArea(AreaDimension dimensionIn, IPixelTransformer transformer)
		{
			return new LazyArea(dimensionIn, transformer);
		}

		public LazyArea MakeArea(AreaDimension dimensionIn, IPixelTransformer transformer, LazyArea p_201489_3_)
		{
			return new LazyArea(dimensionIn, transformer);
		}

		public LazyArea MakeArea(
			AreaDimension dimensionIn,
			IPixelTransformer transformer,
			LazyArea p_201488_3_,
			LazyArea p_201488_4_)
		{
			return new LazyArea(dimensionIn, transformer);
		}
	}
}