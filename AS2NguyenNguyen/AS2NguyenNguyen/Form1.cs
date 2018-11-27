using System;
using System.Text;
using System.Windows.Forms;

// Nguyen Nguyen	300298479
// Hong Le			300299969

namespace AS2NguyenNguyen
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void CalcButton_Click(object sender, EventArgs e)
		{
			OutputListBox.Items.Clear();

			//Assign values to Vehicle class
			Vehicle myVehicle = new Vehicle();

			myVehicle.VehicleYear = parseInt(VehilceYearTB.Text);
			myVehicle.VehicleValue = parseDouble(VehicleValueTB.Text);
			myVehicle.DriverAge = parseInt(DriverAgeTB.Text);
			myVehicle.VehicleType = getVehicleType();
			myVehicle.DiscountType = getDiscountType();

			//Check if data is valid
			if(!myVehicle.hasValidInput())
			{
				string format = "{0, -15}";
				OutputListBox.Items.Add(string.Format(format, "Invalid or not enough data, please try again!"));
				return;
			}

			//Print values to output listBox
			if (!myVehicle.isGreaterThan20())
			{
				string format = "{0, -25}{1, 40}";
				string formatCurr = "{0, -25}{1, 40:c}";
				OutputListBox.Items.Add(string.Format(format, "Vehicle Age:", myVehicle.VehicleAge));
				OutputListBox.Items.Add(string.Format(formatCurr, "Vehicle Value:", myVehicle.VehicleValue));
				OutputListBox.Items.Add(string.Format(formatCurr, "Basic Insurance:", myVehicle.getBasicInsurance()));
				OutputListBox.Items.Add(string.Format(formatCurr, "Vehicle Type Surcharge:", myVehicle.getVehicleTypeSurcharge()));
				//Special formating for this line
				OutputListBox.Items.Add(string.Format(format, "Discount:", "(" + string.Format("{0, 0:c}", myVehicle.Discount) + ")"));
				OutputListBox.Items.Add(string.Format(formatCurr, "Owner Age surcharge:", myVehicle.DriverAgeSurcharge));
				OutputListBox.Items.Add("");
				OutputListBox.Items.Add(string.Format(formatCurr, "Net Amount: ", myVehicle.GetInsuranceNetAmt()));
			}
			else if (myVehicle.isGreaterThan20())
			{
				string format = "{0, -15}";
				OutputListBox.Items.Add(string.Format(format, "Vehicle is too old to be insured"));
			}

			OutputListBox.Items.Add("");
			OutputListBox.Items.Add("Designed by NguyenNguyen and HongLe");
		}

		//Method to parse int value.
		//return -1 if parsing fail
		private int parseInt(string value)
		{
			int intVal = -1;
			if (int.TryParse(value, out intVal))
			{
				return intVal;
			}
			return -1;
		}

		//Method to parse double value.
		//return -1 if parsing fail
		private double parseDouble(string value)
		{
			double doubleVal = -1;
			if (double.TryParse(value, out doubleVal))
			{
				return doubleVal;
			}
			return -1;
		}

		//Method to convert vehicle type to enum
		private VehicleTypeEnum getVehicleType()
		{
			if (SedanRB.Checked)
			{
				return VehicleTypeEnum.Sedan;
			}
			if (SuvRB.Checked)
			{
				return VehicleTypeEnum.SUV;
			}
			if (SportRB.Checked)
			{
				return VehicleTypeEnum.Sport;
			}
			if (TruckRB.Checked)
			{
				return VehicleTypeEnum.Truck;
			}
			return VehicleTypeEnum.None;
		}

		//Method to convert discount type to string of its letters
		private string getDiscountType()
		{
			StringBuilder strBld = new StringBuilder();
			char bcaaOpt = 'B';
			char dougOpt = 'D';
			char pcOpt = 'P';
			if (BcaaCB.Checked)
			{
				strBld.Append(bcaaOpt);
			}
			if (DouglasClubCB.Checked)
			{
				strBld.Append(dougOpt);
			}
			if (PcOptimumCB.Checked)
			{
				strBld.Append(pcOpt);
			}

			return strBld.ToString();
		}
	}
}
