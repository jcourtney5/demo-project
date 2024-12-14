## Demo Project

Paycheck calculator demo project

## Decisions and Why

---
**Decision**: Didn't update to .NET 8/9 or minimal APIs<br>
**Why**: Out of scope and would take too long, kept it .NET 6 

**Decision**: Didn't build crud operations to add/edit employees and their dependents<br>
**Why**: Wasn't sure if it was in scope or needed, would take a lot of extra time to build all this and handle all the validations and edge cases

**Decision**: Didn't build a UI to view/edit employees, dependents and paychecks<br>
**Why**: Wasn't sure if it was in scope or needed, would take a lot of extra time to build

**Decision**: Put test data in EmployeeData wrapper class to separate from controllers<br>
**Why**: Abstracts data from api controllers so can be modified in the future for a real database or external services depending on the design

**Decision**: Built separate utility classes for the core paycheck calculations (paycheck calculator, deductions calculator and rules)
**Why**: Wanted to be able to develop and test each part in isolation and make it expandable for the future since there is a lot more functionality that needs to be added here

**Decision**: Added unit tests project to test paycheck and deduction classes<br>
**Why**: The calculations are complex and hard to test all combinations and edge cases together at the API level so added unit tests to make sure the logic for each piece is correct

**Decision**: Added PaycheckCalculatorBuilder to manually build and assemble the Paycheck and Deductions Calculator classes with the given rules from the requirement<br>
**Why**: Used the rules and values from the requirements but in production this would need to be data driven and support more rules and configuration

**Decision**: Paycheck and deductions classes directly depend on Employee entity right now<br>
**Why**: For simplicity in this project, ideally would come up with a better design and everything would be passed as an interface or the needed parameters

**Decision**: Paycheck calculator is pretty simple right now and returns a "sample" paycheck, doesn't even calculate with or return a date range yet<br>
**Why**: Focused on deductions and the basic salary calculation from the requirements, there are still a ton of features to add to make it fully functional

**Decision**: Didn't change the port in the Integration Tests which was one of the tasks<br>
**Why**: Ran out of time but would have liked to look into loading url and port from something like a config file so it can be changed in different environments

**Decision**: AgeDeductionRule doesn't take any date range into account in case age changes during the year from one paycheck to the next<br>
**Why**: Couldn't account for this yet since Paycheck and PaycheckCalculator don't support proper date ranges

## Things to improve and discuss

---
Add interface for EmployeeData and either 
1) connect to a real database with EF core or 
2) Connect to third party services with APIs

Add global API exception handler that returns ApiResponse with list of errors<br>

Add CRUD operations for employees and dependents besides GET calls

Employee and Dependent controllers need paging, filters or ranges in Get API calls since can't return all employees once dataset is large

Unit test names are a bit long, would like to maybe improve them or use a different naming convention

DeductionRule classes maybe should take in an Employee interface or abstraction instead of taking Employee directly

Need a lot more validations and error checking in many places to avoid null exceptions and negative values

Deduction rules should be data driven, possibly loaded from database tables, config files, or both
Need to figure out best rounding strategy in PayCheckCalculator
* It currently rounds salary "down" to nearest cent and rounds deductions normally before subtracting
* Some data might be lost in these calculations and needs to be improved
* Maybe shouldn't round to nearest cent at all, only when displaying in UI or depositing money in third party systems?

Paycheck doesn't calculate with proper date ranges yet

Would be nice to return a list of deductions with descriptions in Paycheck Dto (would help with testing too)
 
Paycheck controller needs better REST API design and parameters
* Ex: Better url and params like paychecks?employeeId=1&from=2024-05-01&to=2024-06-20
* Ex: Get multiple paycheck(s) for specific time period
* Ex: Ability to get current year to date or year-end pay aggregate data
 
Paycheck calculator needs **a lot** more features to be fully functional
* Support different modes like biweekly, monthly, hourly
* Return paychecks with date ranges on each one and use the date range to correctly calculate deductions 
* Ex: what if they turn 50 half way through the year, deductions need to change from paycheck to paycheck
* Support tax calculations and deductions
* Support hire date and salary changes throughout the year
* Support bonuses, stock awards, vacation days, etc...
