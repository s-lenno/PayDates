/*Version 1.1
Delete comments & program.cs to utilise.

using System;
using System.Globalization;

public class PayWeeksGenerator
{
    private DateTime startDate;
    private DateTime endDate;
    private int weekIncrement;

    public PayWeeksGenerator(DateTime startDate, DateTime endDate, int weekIncrement)
    {
        this.startDate = startDate;
        this.endDate = endDate;
        this.weekIncrement = weekIncrement;
    }

    public void GeneratePayWeeks()
    {
        DateTime currentDate = startDate;
        int weekNumber = 9;
        int lineNumber = 1;

        while (currentDate <= endDate)
        {
            Console.WriteLine("Week " + $"{weekNumber} = {startDate.ToString("dd MMMM yyyy")}" + " = Payslip " + lineNumber);
            currentDate = currentDate.AddDays(7 * weekIncrement);
            weekNumber = (weekNumber % 52) + 1; // Revert to 1 if exceeds 52
            lineNumber++;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Example usage:
        DateTime startDate = new DateTime(2024, 2, 29); // Thursday, 29th February 2024
        DateTime endDate = new DateTime(2025, 4, 30); // April 30, 2025
        int weekIncrement = 4; // Increment by 4 weeks

        PayWeeksGenerator generator = new PayWeeksGenerator(startDate, endDate, weekIncrement);
        generator.GeneratePayWeeks();
    }
}

*/
