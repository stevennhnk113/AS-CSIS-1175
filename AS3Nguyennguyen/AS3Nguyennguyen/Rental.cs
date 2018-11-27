using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS3Nguyennguyen
{
	class Rental
	{
		string _type;
		string _acc;
		string _insurance;
		double _hrs;
		public double charges = 0;
		const string EMPTY_STRING = "";

		public Rental(string type, string acc, string insurance, double hrs)
		{
			_type = type;
			_acc = acc;
			_insurance = insurance;
			_hrs = hrs;
		}

		public string getType()
		{
			double rate = 0;
			if (_type != EMPTY_STRING && _type != null)
			{
				switch (_type)
				{
					case "1":
						if (_hrs > 3)
						{
							rate = 13; 
						} else
						{
							rate = 10;
						}
						charges += rate * _hrs;
						return "Single-speed";
					case "2":
						if (_hrs > 3)
						{
							rate = 10;
						}
						else
						{
							rate = 12;
						}
						charges += rate * _hrs;
						return "Seven-speed";
					case "3":
						if (_hrs > 3)
						{
							rate = 15;
						}
						else
						{
							rate = 20;
						}
						charges += rate * _hrs;
						return "Tandem";
					default:
						charges += 25 * _hrs;
						return "Mountain";
				}
			}

			return EMPTY_STRING;
		}

		public string getAcc()
		{
			string accessoriesStr = EMPTY_STRING;
			if (_acc != null && _acc != EMPTY_STRING)
			{
				if (_acc.Contains("N"))
				{
					charges += 0;
					accessoriesStr = "None requested";
					return accessoriesStr;
				}

				if (_acc.Contains("L"))
				{
					accessoriesStr += "Bike Lock, ";
				}

				if (_acc.Contains("C"))
				{
					accessoriesStr += "Child Seat, ";
				}

				if (_acc.Contains("R"))
				{
					accessoriesStr += "Rack, ";
				}
				accessoriesStr = accessoriesStr.Remove(accessoriesStr.Length - 2);
			}
			return accessoriesStr;
		}

		public string getInsurance()
		{
			if (_insurance != null && _insurance != EMPTY_STRING)
			{
				switch (_insurance)
				{
					case "Y":
						charges += 5;
						return "Yes";
					default:
						charges += 0;
						return "No";
				}
			}

			return EMPTY_STRING;
		}

		public double getTotalCharges()
		{
			return charges;
		}
	}
}
