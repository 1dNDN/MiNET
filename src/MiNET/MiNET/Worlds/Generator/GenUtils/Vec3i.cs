using System;

namespace MiNET.Worlds.Generator.GenUtils
{
	public class Vec3i : IComparable<Vec3i>
	{
		public static Vec3i NullVector = new Vec3i(0, 0, 0);
		protected int X;
		protected int Y;
		protected int Z;

		public Vec3i(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Vec3i(double x, double y, double z) : this((int) Math.Floor(x), (int) Math.Floor(y), (int) Math.Floor(z)) { }

		public int CompareTo(Vec3i other)
		{
			if (GetY() == other.GetY()) return GetZ() == other.GetZ() ? GetX() - other.GetX() : GetZ() - other.GetZ();

			return GetY() - other.GetY();
		}

		public int GetX()
		{
			return X;
		}

		public int GetY()
		{
			return Y;
		}

		public int GetZ()
		{
			return Z;
		}

		public new bool Equals(object other)
		{
			if (this == other) return true;

			if (!(other is Vec3i)) return false;
			var vec3i = (Vec3i) other;

			if (GetX() != vec3i.GetX()) return false;

			if (GetY() != vec3i.GetY()) return false;

			return GetZ() == vec3i.GetZ();
		}

		public new int GetHashCode()
		{
			return (GetY() + GetZ() * 31) * 31 + GetX();
		}

		public Vec3i CrossProduct(Vec3i vec)
		{
			return new Vec3i(GetY() * vec.GetZ() - GetZ() * vec.GetY(), GetZ() * vec.GetX() - GetX() * vec.GetZ(), GetX() * vec.GetY() - GetY() * vec.GetX());
		}

		public double GetDistance(int xIn, int yIn, int zIn)
		{
			double d0 = GetX() - xIn;
			double d1 = GetY() - yIn;
			double d2 = GetZ() - zIn;

			return Math.Sqrt(d0 * d0 + d1 * d1 + d2 * d2);
		}

		public double GetDistance(Vec3i other)
		{
			return GetDistance(other.GetX(), other.GetY(), other.GetZ());
		}

		public double DistanceSq(double toX, double toY, double toZ)
		{
			double d0 = GetX() - toX;
			double d1 = GetY() - toY;
			double d2 = GetZ() - toZ;

			return d0 * d0 + d1 * d1 + d2 * d2;
		}

		public double DistanceSqToCenter(double xIn, double yIn, double zIn)
		{
			double d0 = GetX() + 0.5D - xIn;
			double d1 = GetY() + 0.5D - yIn;
			double d2 = GetZ() + 0.5D - zIn;

			return d0 * d0 + d1 * d1 + d2 * d2;
		}

		public double DistanceSq(Vec3i to)
		{
			return DistanceSq(to.GetX(), to.GetY(), to.GetZ());
		}

		public new String ToString()
		{
			return $"Vec3i [X={X}, Y={Y}, Z={Z}]";
		}
	}
}