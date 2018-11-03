using System.Linq;

// Nguyen Nguyen	300298479
// Hong Le			300299969

namespace AS2NguyenNguyen
{
	public class Vehicle
	{
		public int VehicleAge = -1;
		public double DriverAgeSurcharge = -1;
		private double _VehicleTypeSurchargePercentage = -1;
		private double _Discount = -1;

		private int vehicleMaxAge = 20;

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

		private double _VehicleValue;
		public double VehicleValue
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


		/**
		 *Define Vehicle type percentage
			**/
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
					case VehicleTypeEnum.SUV:
						_VehicleTypeSurchargePercentage = 0.01;
						break;
					case VehicleTypeEnum.Sport:
						_VehicleTypeSurchargePercentage = 0.05;
						break;
					case VehicleTypeEnum.Truck:
						_VehicleTypeSurchargePercentage = 0.02;
						break;
				}
			}
		}

		/**
		 * Define discount percentage by selected discount type. 
		 **/
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
				_Discount = 0;
				if (_DiscountType.Contains('B'))
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

		/**
		 * Define driver age surcharge by driver age
		 * **/
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


		/**
		 * Calculate Basic insurance by vehicle value and age
		 * **/
		private double _BasicInsurance;
		public double getBasicInsurance()
		{
			setBasicInsurance();
			return _BasicInsurance;
		}

		public void setBasicInsurance()
		{
			_BasicInsurance = (VehicleValue * 0.01 * (vehicleMaxAge - VehicleAge));
		}

		/**
		 * Calculate Vehicle type surchage by vehicle surcharge percentage and basic insurance
		 * **/
		private double _VehicleTypeSurcharge;
		public double getVehicleTypeSurcharge()
		{
			_VehicleTypeSurcharge = _VehicleTypeSurchargePercentage * _BasicInsurance;
			return _VehicleTypeSurcharge;
		}

		public double Discount
		{
			get
			{
				return _BasicInsurance * _Discount;
			}
		}


		/**
		 * Calculate Net amount based on given input
		 * **/
		public double GetInsuranceNetAmt()
		{
			if (VehicleAge < 0 || VehicleValue < 0 || _VehicleTypeSurchargePercentage == -1 || DriverAgeSurcharge == -1)
			{
				return -1;
			}
			return (_BasicInsurance + _VehicleTypeSurcharge + DriverAgeSurcharge) - Discount ;
		}

		/**
		 * Checking if user's input is valid for further calculation
		 * **/
		public bool hasValidInput()
		{
			if (VehicleYear > -1 && VehicleValue > -1 && DriverAge > -1 
				&& VehicleType != VehicleTypeEnum.None)
			{
				return true;
			}
			return false;
		}

		public bool isGreaterThan20()
		{
			if (VehicleAge >= 20)
			{
				return true;
			}
			return false;
		}
	}

	public enum VehicleTypeEnum
	{
		Sedan = 1,
		SUV = 2,
		Sport = 3,
		Truck = 4,
		None = -1
	}
}
