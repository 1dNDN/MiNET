using MiNET.Blocks;

namespace MiNET.Worlds.Generator.SurfaceBuilders
{
	public class SurfaceBuilderConfig
	{
		private Block Top;
		private Block Middle;
		private Block Bottom;

		public SurfaceBuilderConfig(Block top, Block middle, Block bottom)
		{
			Top = top;
			Middle = middle;
			Bottom = bottom;
		}
	}
}
