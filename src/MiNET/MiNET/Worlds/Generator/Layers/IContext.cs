namespace MiNET.Worlds.Generator.Layers
{
	interface IContext
	{
		int Random(int bound);

		ImprovedNoise GetNoiseGenerator();
	}
}