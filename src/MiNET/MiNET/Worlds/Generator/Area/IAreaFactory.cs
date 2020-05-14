namespace MiNET.Worlds.Generator.Area
{
	interface IAreaFactory<A> where A : IArea
	{
		A Make(AreaDimension dimension);
	}
}