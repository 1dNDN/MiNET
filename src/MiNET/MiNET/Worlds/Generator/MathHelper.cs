namespace MiNET.Worlds.Generator
{
	class MathHelper
	{
		public static double ClampedLerp(double lowerBnd, double upperBnd, double slide)
		{
			if (slide < 0.0D)
			{
				return lowerBnd;
			}

			return slide > 1.0D ? upperBnd : lowerBnd + (upperBnd - lowerBnd) * slide;
		}


	}
}
