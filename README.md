## Demo Project

Paycheck calculator demo project

## Decisions and Why

**Decision**: Didn't update to .NET 8/9 or minimal APIs<br>
**Why**: Kept it .NET 6 so there are less 

**Decision**: Didn't build crud operations to add/edit employees and dependents<br>
**Why**: Wasn't sure if it was needed, would take a lot of extra time to build

**Decision**: Didn't build a UI to view/edit employees, dependents and paychecks<br>
**Why**: Wasn't sure if it was needed, would take a lot of extra time to build

**Decision**: Put data into EmployeeData wrapper class<br>
**Why**: Abstracts away getting data from this service/api, data could come from a database or external services with API calls

**Decision**: Paycheck calculator is pretty simple, there is a significant amount of features that would need to be added to it<br>
**Why**: Only added the functionality from the requirements

**Decision**: AgeDeductionRule doesn't handle edge case is flawed since it doesn't adjust in case age changes based on paycheck date<br>
**Why**:


## Future tasks and discussion points
* Add high level exception handler that returns ApiResult with list of errors
* Add CRUD operations for employees and dependents besides GET calls
* Employee and Dependent controllers need paging, filters or ranges in Get API calls since can't return all employees once dataset is large
* DeductionRule classes should take Employee in directly, maybe there should be some sort of abstraction or interface
* Need a lot more validations and error checking everywhere
  * Ex: Don't allow negative deductions or pay values
* Deduction rules should be data driven, possibly loaded from database tables, config files, or both
* Paycheck controller needs better REST API url and parameters
  * Ex: Get paycheck(s) for specific time period
  * Ex: Get year-end pay aggregate information
* Paycheck calculator needs **lots** of more features to be fully functional
  * Support different modes like biweekly, monthly, hourly
  * Return paychecks with date ranges on each one
  * Return a date range for each paycheck and use the date range to correctly calculate deductions 
    * Ex: what if they turn 50 half way through the year, deductions need to change from paycheck to paycheck
  * Support tax calculations and deductions
  * Support hire date and salary changes throughout the year
  * Support bonuses, stock awards, vacation days, etc...