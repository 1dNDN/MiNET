namespace MiNET.Worlds.Generator.Area
{
	public class AreaDimension
	{
		private int startX;
		private int startZ;
		private int xSize;
		private int zSize;

		public AreaDimension(int startX, int startZ, int xSize, int zSize)
		{
			this.startX = startX;
			this.startZ = startZ;
			this.xSize = xSize;
			this.zSize = zSize;
		}

		public int GetStartX()
		{
			return startX;
		}

		public int GetStartZ()
		{
			return startZ;
		}

		public int GetXSize()
		{
			return xSize;
		}

		public int GetZSize()
		{
			return zSize;
		}
	}
}