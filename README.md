# PayDates
by  Sean Lennon (https://github.com/s-lenno/)

 * This basic program is used to output each of my paydays in respect to the yearly calendar in my current job. 
 * It generates week numbers with corresponding dates, simulating a pay schedule starting from a specified week number and date. 
 * The pay schedule initally starts at 9 because I had joined the company in February.
 * The Generate() method is responsible for calculating and printing the week numbers along with their respective dates and line numbers.
 * **UPDATE** v 2.02 - Code added to process salary
 * **UPDATE** v 2.42 - Additional comments added & redundant code chopped to optimise performance.

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

