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
		//Todo: move this to c:\temp
		const string customerDataFilePath = @"C:\Users\Steven\Desktop\AS3 data files\AS3customers.csv";
		const string dataFilePath = @"C:\Users\Steven\Desktop\AS3 data files\AS3data.csv";
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
			string[][] customerData = new string[File.ReadAllLines(dataFilePath).Length][];
			StreamReader reader = File.OpenText(dataFilePath);
			int count = 0;
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] data = line.Split(',');
				string name = getCustomer(data[0]);

				customerData[count] = new string[data.Length + 1];

				//Update the rental values based on input data from csv
				Rental rental = new Rental(data[3], data[4], data[5], double.Parse(data[6]));

				//Assign data to customerData to later populate in List Box view
				customerData[count][0] = data[0];
				customerData[count][1] = name;
				customerData[count][2] = data[1];
				customerData[count][3] = data[2];
				customerData[count][4] = rental.getType();
				customerData[count][5] = rental.getAcc();
				customerData[count][6] = rental.getInsurance();
				customerData[count][7] = rental.getTotalCharges().ToString();
				count++;
			}
			//End merging
			reader.Close();

			//TODO:
			//Render and Order data here

			lstResult.Items.Add(string.Format(getCustomer("111")));
		}

		private void ShowResult()
		{
			string individualFormat = "{0:15}{1:25}{2:35}{3:50}{4:80}{5:90}{6:100}{7:110}";

			lstResult.Items.Add(string.Format(individualFormat, "Customer ID & Name", "Inv #", "Rental Date", "Bike Type", "Accessories", "Insured", "Hrs", "Charge"));

		}
	}
}
