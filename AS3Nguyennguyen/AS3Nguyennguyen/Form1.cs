/**
 * Nguyen Nguyen	300298479
 * Hong Le			300299969
 * **/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AS3Nguyennguyen
{
	public partial class Form1 : Form
	{
		const string EMPTY_STRING = "";
		private string[][] customerData;
		private string[][] printOutData;

		//Todo: move this to c:\temp
		const string customerDataFilePath = @"C:\temp\AS3customers.csv";
		const string dataFilePath = @"C:\temp\AS3data.csv";
		int length = 0;
		public Form1()
		{
			InitializeComponent();
		}

		/**
		 * Method to load customer names and Ids based on the file
		 * **/
		public void loadCustomer()
		{
			length = File.ReadAllLines(customerDataFilePath).Length;
			//Read file Customer
			StreamReader reader = File.OpenText(customerDataFilePath);
			int i = 0;
			//Initialize 2D array
			customerData = new string[length][];
			while (!reader.EndOfStream)
			{
				//Header should be ignored
				string[] line = reader.ReadLine().Split(',');
				customerData[i] = new string[line.Length];
				customerData[i][0] = line[0];
				customerData[i][1] = line[1];
				i++;
			}
			reader.Close();
		}

		/**
		 * Method to search for customer name with Id
		 * 
		 * Return customer name
		 * 
		 * **/
		public string getCustomer(string id)
		{
			for (int i = 0; i < customerData.Length; i++)
			{
				string nameStr = EMPTY_STRING;
				var data = from row in customerData[i]
						   let idCust = customerData[i][1]
						   let name = customerData[i][0]
						   where (idCust.Equals(id))
						   select new { name };

				foreach (var s in data)
				{
					nameStr = s.name;
					return nameStr;
				}
			}
			return EMPTY_STRING;
		}

		private void btnProcess_Click(object sender, EventArgs e)
		{
			loadCustomer();

			lstResult.Items.Clear();

			//Read and merge 2 files to 1 table of 8 columns
			printOutData = new string[File.ReadAllLines(dataFilePath).Length][];
			StreamReader reader = File.OpenText(dataFilePath);
			int count = 0;
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] data = line.Split(',');
				string name = getCustomer(data[0]);

				printOutData[count] = new string[data.Length + 2];

				//Update the rental values based on input data from csv
				Rental rental = new Rental(data[3], data[4], data[5], double.Parse(data[6]));

				//Assign data to customerData to later populate in List Box view
				printOutData[count][0] = data[0]; // ID
				printOutData[count][1] = name;	
				printOutData[count][2] = data[1]; // Rent date
				printOutData[count][3] = data[2];
				printOutData[count][4] = rental.getType();
				printOutData[count][5] = rental.getAcc();
				printOutData[count][6] = rental.getInsurance();
				printOutData[count][7] = data[6];
				printOutData[count][8] = rental.getTotalCharges().ToString();
				count++;
			}
			//End merging
			reader.Close();

			//Use Linq to sort data
			var result = from row in printOutData
						 orderby DateTime.Parse(row[3])
						 orderby int.Parse(row[0]) 
						   select row;

			//Render and Order data here
			string individualFormat = "{0,-20}{1,10}{2,15}{3,20}{4,35}{5,10}{6,10:0.00}{7,10:C}";
			lstResult.Items.Add(string.Format(individualFormat, "Customer ID & Name", "Inv #", "Rental Date", "Bike Type", "Accessories", "Insured", "Hrs", "Charge"));
			lstResult.Items.Add("");

			string id = "-1";
			double subTotal = 0;
			double grandTotal = 0;
			foreach (var item in result)
			{
				if(item[0] != id)
				{
					if(id != "-1")
					{
						lstResult.Items.Add(string.Format("{0,130}", "---------"));
						lstResult.Items.Add(string.Format("{0,-20}{1,110:c}", "Sub-Total", subTotal));
						lstResult.Items.Add("");

						grandTotal += subTotal;
						subTotal = 0;
					}
					lstResult.Items.Add(string.Format(individualFormat, item[0] + " " + item[1], item[2], item[3], item[4], item[5], item[6], double.Parse(item[7]), double.Parse(item[8])));
					id = item[0];
				}
				else
				{
					lstResult.Items.Add(string.Format(individualFormat, "", item[2], item[3], item[4], item[5], item[6], double.Parse(item[7]), double.Parse(item[8])));
				}

				subTotal += double.Parse(item[8]);
			}

			lstResult.Items.Add(string.Format("{0,130}", "---------"));
			lstResult.Items.Add(string.Format("{0,-20}{1,110:c}", "Sub-Total", subTotal));
			lstResult.Items.Add("");
			grandTotal += subTotal;

			lstResult.Items.Add("");
			lstResult.Items.Add(string.Format("{0,-20}{1,110:c}", "Grand-Total", grandTotal));
			lstResult.Items.Add("Program coded by Hong Le, Nguyen Nguyen");
		}
	}
}
