/* 
 * Payslip code
 * Sean Lennon (https://github.com/s-lenno/)
 * This basic program is used to output each of my paydays in respect to the yearly calendar in my current job. 
 * It generates week numbers with corresponding dates, simulating a pay schedule starting from a specified week number and date. 
 * The pay schedule initally starts at 9 because I had joined the company in February.
 * The Generate() method is responsible for calculating and printing the week numbers along with their respective dates and line numbers.
 * **UPDATE** v 2.02 - Code added to process salary
 * **UPDATE** v 2.42 - Additional comments added & redundant code chopped to optimise performance.
 * **UPDATE** v 2.43 - Fixed typos.

    How the program works:
    1. Define the start week number, start date (Thursday), and end date.
    2. Iterate through each week, incrementing by 4 weeks each time, until the end date is reached.
    3. Calculate the current week number based on the start week number and the number of increments.
    4. Adjust the calculated week number by using modulo arithmetic to revert back to week 1 if it ever exceeds 52.
    5. Print each line of output which will display the adjusted week number, the corresponding date, and a line number denoting which payslip it is.
    6. Program ends once the specified range of dates have been output.

   Output:
    Week 9 = 29 February 2024 = Payslip 1
    Week 17 = 25 April 2024 = Payslip 3
    Week 45 = 07 November 2024 = Payslip 10
    ...
    Week 9 = 27 February 2025 = Payslip 14 
    */

using System;

public class PayWeeks
{
    private const int StartWeekNumber = 9; // Week 9 was my first pay week, so program specified to begin here
    private const int WeeksInAPeriod = 4; // 4 weeks' work paid for
    private const int PaidHoursPerPeriod = 144; // 36 hours in  work week * 4  weeks = 144 hours pay per period
    private const double PayRate = 21.5306; //Hourly rate in £ sterling
    private const double PensionContributionRate = 0.92; // 100% Salary - 8% Contribution at source via salary sacrifice = 92% (0.92)
    private const double IncomeTaxDeduction = 376.80; // Monthly income tax deduction
    private const double NationalInsuranceDeduction = 150.83; // Monthly NI deduction
    private const double StudentLoanDeduction = 83.00;// Monthly SLC deduction
    private const double UniteDeduction = 14.68; // Monthly union fee
    private const int WeeksPerYear = 52; // Weeks in a year assigned as a constant for easy direct comparison with adjustedWeekNumber

    public void Generate()
    {
        DateTime startDate = new DateTime(2024, 2, 29); // Thursday 29th February 2024 - First specified pay date (Payslip 1)
        DateTime endDate = new DateTime(2025, 2, 28); // Thursday 27th February 2025 - Last specified pay date (Payslip 14)

        int lineNumber = 1;
        double totalBeforeTax = 0;
        double totalAfterTax = 0;

        while (startDate < endDate)
        {
            int currentWeekNumber = StartWeekNumber + ((lineNumber - 1) * WeeksInAPeriod);
            int adjustedWeekNumber = currentWeekNumber % WeeksPerYear; // If week number is over 52 (passed end of December), wrap back around to restart at week 1 ( inJanuary)

            double salaryBeforeTax = CalculateBeforeTaxSalary();
            double salaryAfterTax = CalculateAfterTaxSalary(salaryBeforeTax);

            if (adjustedWeekNumber <= WeeksPerYear)
            {
                totalBeforeTax += salaryBeforeTax;
                totalAfterTax += salaryAfterTax;
            }

            salaryBeforeTax = Math.Round(salaryBeforeTax, 2);
            salaryAfterTax = Math.Round(salaryAfterTax, 2);

            Console.WriteLine($"\nWeek {adjustedWeekNumber} = {startDate:dd MMMM yyyy} = Payslip {lineNumber} \n Before tax: £{salaryBeforeTax} \n After tax: £{salaryAfterTax}");
            startDate = startDate.AddDays(28); // Increment by exactly 28 days / 4 weeks at a time
            lineNumber++;
        }

        // Print totals
        Console.WriteLine($"\nTotal this year before tax: £{totalBeforeTax.ToString("N2")}");
        Console.WriteLine($"Total this year after tax: £{totalAfterTax.ToString("N2")}");
    }

    private double CalculateBeforeTaxSalary()
    {
        return (PayRate * PaidHoursPerPeriod) * PensionContributionRate;
    }

    private double CalculateAfterTaxSalary(double beforeTaxSalary)
    {
        return beforeTaxSalary - (NationalInsuranceDeduction + IncomeTaxDeduction + StudentLoanDeduction + UniteDeduction);
    }
}

class Program
{
    static void Main(string[] args)
    {
        PayWeeks generator = new PayWeeks();
        generator.Generate(); 
    }
}