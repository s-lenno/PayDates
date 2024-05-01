using System;
/*Payslip code
 * Sean Lennon (https://github.com/s-lenno/)
 * This basic program is used to output each of my paydays in respect to the yearly calendar in my current job. 
 * It generates week numbers with corresponding dates, simulating a pay schedule starting from a specified week number and date. 
 * The pay schedule initally starts at 9 becasue I had joined the company in February.
 * The WeekNumberGenerator class is responsible for calculating and printing the week numbers along with their respective dates and line numbers. 

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
    Week 1 = 02 January 2025 = Payslip 1
*/

public class PayWeeks
{
    public void GenerateWeekNumbers()
    {

        DateTime startDate = new DateTime(2024, 2, 29); // Thursday 29th February 2024 - First pay date
        DateTime endDate = new DateTime(2025, 4, 1); // 

        int startWeekNumber = 9;
        int lineNumber = 1;

        while (startDate < endDate)
        {
            int currentWeekNumber = startWeekNumber + ((lineNumber - 1) * 4);
            int adjustedWeekNumber = (currentWeekNumber) % 52;

            Console.WriteLine($"Week {adjustedWeekNumber} = {startDate:dd MMMM yyyy} = Payslip {lineNumber}"); 
            startDate = startDate.AddDays(28); // Increment by exactly 4 weeks at a time 
            lineNumber++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PayWeeks generator = new PayWeeks();
        generator.GenerateWeekNumbers();
    }
}