/**
 * Nguyen Nguyen	300298479
 * Hong Le			300299969
 * **/

namespace AS3Nguyennguyen
{
	class Rental
	{
		string _type;
		string _acc;
		string _insurance;
		double _hrs;

		public double totalCharges = 0;
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
			string type = "";
			double before3Rate = 0;
			double after3Rate = 0;
			if (_type != EMPTY_STRING && _type != null)
			{
				switch (_type)
				{
					case "1":
						before3Rate = 10;
						after3Rate = 13;
						type =  "Single-speed";
						break;
					case "2":
						before3Rate = 12;
						after3Rate = 10;
						type = "Seven-speed";
						break;
					case "3":
						before3Rate = 20;
						after3Rate = 15;
						type = "Tandem";
						break;
					default:
						before3Rate = 25;
						after3Rate = 25;
						type = "Mountain";
						break;
				}

				if(_hrs > 3)
				{
					totalCharges = 3 * before3Rate + (_hrs - 3) * after3Rate;
				}
				else
				{
					totalCharges = _hrs * before3Rate;
				}
				return type;
			}
			else
			{
				return EMPTY_STRING;
			}
		}

		public string getAcc()
		{
			string accessoriesStr = EMPTY_STRING;
			if (_acc != null && _acc != EMPTY_STRING)
			{
				if (_acc.Contains("N"))
				{
					totalCharges += 0;
					accessoriesStr = "None requested";
					return accessoriesStr;
				}

				if (_acc.Contains("L"))
				{
					totalCharges += 10;
					accessoriesStr += "Bike Lock, ";
				}

				if (_acc.Contains("C"))
				{
					totalCharges += 10;
					accessoriesStr += "Child Seat, ";
				}

				if (_acc.Contains("R"))
				{
					totalCharges += 10;
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
						totalCharges += 5;
						return "Yes";
					default:
						totalCharges += 0;
						return "No";
				}
			}

			return EMPTY_STRING;
		}

		public double getTotalCharges()
		{
			return totalCharges;
		}
	}
}
