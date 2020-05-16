using MiNET.Worlds.Generator.Area;

namespace MiNET.Worlds.Generator.Layers
{
	interface IContextExtended<A> : IContext where A : IArea
	{
		void SetPosition(long x, long z);

		//A MakeArea(AreaDimension dimensionIn, IPixelTransformer transformer);

		//A MakeArea(AreaDimension dimensionIn, IPixelTransformer transformer, A context);

		//A MakeArea(
		//	AreaDimension dimensionIn,
		//	IPixelTransformer transformer,
		//	A p_201488_3_,
		//	A p_201488_4_);

		int SelectRandomly(int[] choices);
	}
}