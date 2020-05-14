namespace MiNET.Worlds.Generator.Area
{
	public class LazyArea : IArea
	{
		private IPixelTransformer PixelTransformer;

		public LazyArea(AreaDimension dimension, IPixelTransformer pixelTransformer)
		{
			PixelTransformer = pixelTransformer;
		}

		public int GetValue(int x, int z)
		{
			long i = GetCacheKey(x, z);
			int k = PixelTransformer.Apply(x, z);

			return k;
		}

		private long GetCacheKey(int x, int z)
		{
			long i = 1L;
			i = i << 26;
			i = i | x + 0 & 67108863L;
			i = i << 26;
			i = i | z + 0 & 67108863L;

			return i;
		}
	}
}