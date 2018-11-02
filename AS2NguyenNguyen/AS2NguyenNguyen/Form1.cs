using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

			//Print values to output listBox
			if (myVehicle.hasValidInput() && !myVehicle.isGreaterThan20())
			{
				string format = "{0, -15}{1,0}{2, 40}";
				string formatCurr = "{0, -15}{1,0}{2, 40:c}";
				OutputListBox.Items.Add(string.Format(format, "Vehicle Age:", " ", myVehicle.VehicleAge));
				OutputListBox.Items.Add(string.Format(formatCurr, "Vehicle Value:", "", myVehicle.VehicleValue));
				OutputListBox.Items.Add(string.Format(formatCurr, "Basic Insurance:", "", myVehicle.getBasicInsurance()));
				OutputListBox.Items.Add(string.Format(formatCurr, "Vehicle Type Surcharge:", "", myVehicle.getVehicleTypeSurcharge()));
				OutputListBox.Items.Add(string.Format(formatCurr, "Discount:", "", "(" + myVehicle.Discount + ")"));
				OutputListBox.Items.Add(string.Format(formatCurr, "Owner Age surcharge:", "", myVehicle.DriverAgeSurcharge));
				OutputListBox.Items.Add("");
				OutputListBox.Items.Add(string.Format(formatCurr, "Net Amount: ", "", myVehicle.GetInsuranceNetAmt()));
				OutputListBox.Items.Add("");
				OutputListBox.Items.Add("Designed by NguyenNguyen and HongLe");
			} else if (myVehicle.isGreaterThan20()) {
				string format = "{0, -15}";
				OutputListBox.Items.Add(string.Format(format, "No insurance for this vehicle"));
			} else
			{
				string format = "{0, -15}";
				OutputListBox.Items.Add(string.Format(format, "Invalid inputs"));
			} 


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
			int doubleVal = -1;
			if (int.TryParse(value, out doubleVal))
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
