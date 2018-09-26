using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

// Team member:
// Nguyen Nguyen:		300298479
// Minh Hong Le:		300299929

namespace AS1NguyenNguyen
{
	class Program
	{
		static void Main(string[] args)
		{
			bool isFinished = false;
			double labFee = 0;
			double courseFee = 0;
			double dormFee = 0;
			double totalCost = 0;

			WriteLine();
			WriteLine("Welcome!!!");
			WriteLine("-------------------------------------------");

			while (!isFinished)
			{
				string programName;
				string courses;
				string dormType;

				labFee = GetProgram(out programName);
				courseFee = GetCourse(out courses);
				dormFee = GetDorm(out dormType);

				totalCost = labFee + courseFee + dormFee;

				WriteLine();
				WriteLine("Your are in the {0} program", programName);
				WriteLine("and the lab fee is {0:c}", labFee);

				WriteLine();
				WriteLine("Your courses are {0}", courses);
				WriteLine("The tuition fee amount is {0:c}", courseFee);

				WriteLine();
				WriteLine("Your dorm type are {0}", dormType);
				WriteLine("Your dorm fee is {0:c}", dormFee);

				WriteLine();
				WriteLine("The total amount of fee is {0:c}", totalCost);

				WriteLine();
				WriteLine("Would you like to try again? Enter Y (yes) or N (no)");
				isFinished = ReadLine().ToUpper() == "N";

				if (!isFinished) WriteLine("-------------------------------------------");
			}
		}

		static double GetProgram(out string programName)
		{
			programName = "";
			double labFee = -1;
			string programCode;

			const string BUSINESS = "busn";
			const string COMPUTINGSTUDIES = "csis";
			const string ECONOMICS = "econ";
			const string MARKETING = "mark";

			WriteLine();
			while (labFee == -1)
			{
				WriteLine("Which program do you belong to?");
				programCode = ReadLine();

				switch (programCode)
				{
					case BUSINESS:
						programName = "Business";
						labFee = 100.00;
						break;
					case COMPUTINGSTUDIES:
						programName = "Computing Studies";
						labFee = 150.00;
						break;
					case ECONOMICS:
						programName = "Economics";
						labFee = 0;
						break;
					case MARKETING:
						programName = "Marketing";
						labFee = 0;
						break;
					default:
						labFee = -1;
						break;
				}

			}
			return labFee;
		}

		static double GetCourse(out string courses)
		{
			courses = "";
			double totalCourseFee = 0;
			string[] courseList;
			bool isDone = false;

			WriteLine();
			while (!isDone)
			{
				courses = "";
				totalCourseFee = 0;

				WriteLine("Please enter up to 4 courses that you want to register:");
				courseList = ReadLine().Split(' ');
				if (courseList.Length > 4 || courseList.Length == 1 && string.IsNullOrEmpty(courseList[0]))
				{
					WriteLine("InValid input!!!");
					isDone = false;
				}
				else
				{
					bool isValid = true;
					int index = 0;
					while (isValid && index < courseList.Length)
					{
						//double totalCourseFee = 0;
						double courseFee = GetCourseFee(courseList[index]);
						if (courseFee == -1)
						{
							WriteLine("Invalid input!!!");
							isValid = false;
						}
						else
						{
							courses += " " + courseList[index];
							totalCourseFee += courseFee;
						}
						index++;
					}

					isDone = isValid;
				}

			}
			return totalCourseFee;
		}

		static double GetCourseFee(string courseCode)
		{
			int courseCodeInInt = -1;
			int.TryParse(courseCode, out courseCodeInInt);

			if (courseCodeInInt == -1) return -1;

			if (courseCodeInInt < 3000 && courseCodeInInt >= 1000)
			{
				return 650.00;
			}
			else if (courseCodeInInt < 5000 && courseCodeInInt >= 3000)
			{
				return 800.00;
			}
			else
			{
				return -1;
			}
		}

		static double GetDorm(out string dormType)
		{
			dormType = "";
			bool isValid = false;
			while (!isValid)
			{
				WriteLine("Dorm option: 0 no dorm; 1 single dorm; 2 double dorm");
				dormType = ReadLine();
				switch (dormType)
				{
					case "0":
						dormType = "no dorm";
						return 0;
					case "1":
						dormType = "single dorm";
						return 8000;
					case "2":
						dormType = "double dorm";
						return 4500;
					default:
						WriteLine("Invalid Input!");
						isValid = false;
						break;
				}

			}
			return 0;
		}
	}
}
