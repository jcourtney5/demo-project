## Demo Project

Paycheck calculator demo project

## Decisions and Why

---
**Decision**: Didn't update to .NET 8/9 or minimal APIs<br>
**Why**: Out of scope and would take too long, kept it .NET 6 

**Decision**: Didn't build crud operations to add/edit employees and dependents<br>
**Why**: Wasn't sure if it was in scope or needed, would take a lot of extra time to build and handle validations and edge cases

**Decision**: Didn't build a UI to view/edit employees, dependents and paychecks<br>
**Why**: Wasn't sure if it was in scope or needed, would take a lot of extra time to build

**Decision**: Put test data in EmployeeData wrapper class to separate from controllers<br>
**Why**: Abstracts data from api controllers so can be modified in the future for a real database or external services

**Decision**: Paycheck calculator is pretty simple right now and returns a "sample" paycheck, not even with a date range yet<br>
**Why**: Focused on deductions and the basic salary calculation, there are a ton of features still to add to make it fully functional

**Decision**: AgeDeductionRule doesn't take any date range into account in case age changes during the year from one paycheck to the next<br>
**Why**: Paycheck and PaycheckCalculator didn't support proper date ranges yet so couldn't account for this

## Things to improve and discuss

---
Add interface for EmployeeData and either 
1) connect to a real database with EF core or 
2) Connect to third party services with APIs

Add global API exception handler that returns ApiResponse with list of errors<br>

Add CRUD operations for employees and dependents besides GET calls

Employee and Dependent controllers need paging, filters or ranges in Get API calls since can't return all employees once dataset is large

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
