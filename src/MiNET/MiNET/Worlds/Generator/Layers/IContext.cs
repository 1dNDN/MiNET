using System;
using System.Collections.Generic;
using System.Text;

namespace MiNET.Worlds.Generator.Layers
{
	interface IContext
	{
		int Random(int bound);

		ImprovedNoise GetNoiseGenerator();
	}
}
