using MiNET.Utils;

﻿namespace MiNET.Blocks
{
	internal class Bedrock : Block
	{
		public Bedrock() : base(7)
		{
			Hardness = 60000;
		}

     
		public override ItemStack GetDrops()
		{
			return null; //Drop nothing
		}
	}
}