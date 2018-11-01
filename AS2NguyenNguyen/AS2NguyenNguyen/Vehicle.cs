using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Nguyen Nguyen 300298479
// Hong Le

namespace AS2NguyenNguyen
{
	public class Vehicle
	{
		public int VehicleAge = -1;
		public double DriverAgeSurcharge = -1;
		private double _VehicleTypeSurchargePercentage = -1;
		private double _Discount = -1;

		private int _VehicleYear;
		public int VehicleYear
		{
			get
			{
				return _VehicleYear;
			}
			set
			{
				_VehicleYear = value;

				if (_VehicleYear == 2019) VehicleAge = 0;
				else VehicleAge = 2018 - _VehicleYear;
			}
		}

		private int _VehicleValue;
		public int VehicleValue
		{
			get
			{
				return _VehicleValue;
			}
			set
			{
				_VehicleValue = value;
			}
		}

		private VehicleTypeEnum _VehicleType;
		public VehicleTypeEnum VehicleType
		{
			get
			{
				return _VehicleType;
			}
			set
			{
				_VehicleType = value;
				switch(_VehicleType)
				{
					case VehicleTypeEnum.Sedan:
						_VehicleTypeSurchargePercentage = 0;
						break;
					case VehicleTypeEnum.Sport:
						_VehicleTypeSurchargePercentage = 0.01;
						break;
					case VehicleTypeEnum.SUV:
						_VehicleTypeSurchargePercentage = 0.05;
						break;
					case VehicleTypeEnum.Truck:
						_VehicleTypeSurchargePercentage = 0.02;
						break;
				}
			}
		}

		private string _DiscountType;
		public string DiscountType
		{
			get
			{
				return _DiscountType;
			}
			set
			{
				_DiscountType = value;
				if(_DiscountType.Length == 3)
				{
					_Discount = 0.25;
					return;
				}
				
				if(_DiscountType.Contains('B'))
				{
					_Discount += 0.1;
				}

				if (_DiscountType.Contains('D'))
				{
					_Discount += 0.05;
				}

				if (_DiscountType.Contains('P'))
				{
					_Discount += 0.12;
				}
			}
		}

		private int _DriverAge;
		public int DriverAge
		{
			get
			{
				return _DriverAge;
			}
			set
			{
				_DriverAge = value;
				switch(_DriverAge)
				{
					case var age when _DriverAge < 20:
						DriverAgeSurcharge = 500;
						break;
					case var age when _DriverAge > 35:
						DriverAgeSurcharge = 0;
						break;
					default:
						DriverAgeSurcharge = 250;
						break;
				}
			}
		}

		public double BasicInsurance
		{
			get
			{
				return _VehicleValue * 0.01 * (20 - VehicleAge);
			}
		}

		public double VehicleTypeSurcharge
		{
			get
			{
				return _VehicleTypeSurchargePercentage * BasicInsurance;
			}
		}

		public double Discount
		{
			get
			{
				return BasicInsurance * Discount;
			}
		}

		public double GetInsuranceNetAmt()
		{
			if (VehicleAge == -1 || _VehicleValue == -1 || _VehicleTypeSurchargePercentage == -1 || DriverAgeSurcharge == -1) return -1;
			return 0;
		}
	}

	public enum VehicleTypeEnum
	{
		Sedan = 1,
		SUV = 2,
		Sport = 3,
		Truck = 4
	}
}
