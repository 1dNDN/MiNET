using MiNET.Blocks;

namespace MiNET.Worlds.Generator
{
	public class OverWorldGenSettings
	{
		protected int villageDistance = 32;
		protected int villageSeparation = 8;
		protected int oceanMonumentSpacing = 32;
		protected int oceanMonumentSeparation = 5;
		protected int strongholdDistance = 32;
		protected int strongholdCount = 128;
		protected int strongholdSpread = 3;
		protected int biomeFeatureDistance = 32;
		protected int biomeFeatureSeparation = 8;
		protected int field_204027_h = 16;
		protected int field_211734_k = 8;
		protected int endCityDistance = 20;
		protected int endCitySeparation = 11;
		protected int field_204749_j = 16;
		protected int field_211736_o = 8;
		protected int mansionDistance = 80;
		protected int field_211737_q = 20;
		protected Block defaultBlock = new Stone();
		protected Block defaultFluid = new Water();
		private int field_202212_j = 4;
		private int field_202213_k = 4;
		private int field_202214_l = -1;
		private int field_202215_m = 63;
		private double field_202216_n = 200.0D;
		private double field_202217_o = 200.0D;
		private double field_202218_p = 0.5D;
		private float field_202219_q = 684.412F;
		private float field_202220_r = 684.412F;
		private float field_202221_s = 80.0F;
		private float field_202222_t = 160.0F;
		private float field_202223_u = 80.0F;
		private float field_202224_v = 0.0F;
		private float field_202225_w = 1.0F;
		private float field_202226_x = 0.0F;
		private float field_202227_y = 1.0F;
		private double field_202228_z = 8.5D;
		private double field_202209_A = 12.0D;
		private double field_202210_B = 512.0D;
		private double field_202211_C = 512.0D;

		public int GetVillageDistance()
		{
			return villageDistance;
		}

		public int GetVillageSeparation()
		{
			return villageSeparation;
		}

		public int GetOceanMonumentSpacing()
		{
			return oceanMonumentSpacing;
		}

		public int GetOceanMonumentSeparation()
		{
			return oceanMonumentSeparation;
		}

		public int GetStrongholdDistance()
		{
			return strongholdDistance;
		}

		public int GetStrongholdCount()
		{
			return strongholdCount;
		}

		public int GetStrongholdSpread()
		{
			return strongholdSpread;
		}

		public int GetBiomeFeatureDistance()
		{
			return biomeFeatureDistance;
		}

		public int GetBiomeFeatureSeparation()
		{
			return biomeFeatureSeparation;
		}

		public int func_204748_h()
		{
			return field_204749_j;
		}

		public int func_211730_k()
		{
			return field_211736_o;
		}

		public int func_204026_h()
		{
			return field_204027_h;
		}

		public int func_211727_m()
		{
			return field_211734_k;
		}

		public int GetEndCityDistance()
		{
			return endCityDistance;
		}

		public int GetEndCitySeparation()
		{
			return endCitySeparation;
		}

		public int GetMansionDistance()
		{
			return mansionDistance;
		}

		public int GetMansionSeparation()
		{
			return field_211737_q;
		}

		public Block GetDefaultBlock()
		{
			return defaultBlock;
		}

		public Block GetDefaultFluid()
		{
			return defaultFluid;
		}

		public void SetDefautBlock(Block block)
		{
			defaultBlock = block;
		}

		public void SetDefaultFluid(Block state)
		{
			defaultFluid = state;
		}

		public int GetBiomeSize()
		{
			return 4;
		}

		public int GetRiverSize()
		{
			return 4;
		}

		public int func_202199_l()
		{
			return -1;
		}

		public int GetSeaLevel()
		{
			return 63;
		}

		public double GetDepthNoiseScaleX()
		{
			return 200.0D;
		}

		public double GetDepthNoiseScaleZ()
		{
			return 200.0D;
		}

		public double GetDepthNoiseScaleExponent()
		{
			return 0.5D;
		}

		public float GetCoordinateScale()
		{
			return 684.412F;
		}

		public float GetHeightScale()
		{
			return 684.412F;
		}

		public float GetMainNoiseScaleX()
		{
			return 80.0F;
		}

		public float GetMainNoiseScaleY()
		{
			return 160.0F;
		}

		public float GetMainNoiseScaleZ()
		{
			return 80.0F;
		}

		public float func_202203_v()
		{
			return 0.0F;
		}

		public float func_202202_w()
		{
			return 1.0F;
		}

		public float func_202204_x()
		{
			return 0.0F;
		}

		public float func_202205_y()
		{
			return 1.0F;
		}

		public double func_202201_z()
		{
			return 8.5D;
		}

		public double func_202206_A()
		{
			return 12.0D;
		}

		public double GetLowerLimitScale()
		{
			return 512.0D;
		}

		public double GetUpperLimitScale()
		{
			return 512.0D;
		}
	}
}