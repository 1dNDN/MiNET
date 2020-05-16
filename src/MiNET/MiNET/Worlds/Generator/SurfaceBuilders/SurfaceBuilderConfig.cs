using MiNET.Blocks;

namespace MiNET.Worlds.Generator.SurfaceBuilders
{
	public class SurfaceBuilderConfig
	{
		private Block Bottom;
		private Block Middle;
		private Block Top;

		public SurfaceBuilderConfig(Block top, Block middle, Block bottom)
		{
			Top = top;
			Middle = middle;
			Bottom = bottom;
		}

		public Block GetTop()
		{
			return Top;
		}

		public Block GetMiddle()
		{
			return Middle;
		}

		public Block GetBottom()
		{
			return Bottom;
		}
	}
}