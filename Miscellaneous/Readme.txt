Date: 25/02/2016
Merchant's Guide to the Galaxy
Author: Angel Hernandez (me@angelhernandezm.com)

Overview
********
Development was based on interfaces, intended to be used along with a DI/IoC container which is not implemented
Classes implement these interfaces accordingly. The solution was broken down into smaller pieces of functionality
that go from the entities, parsers, solvers and processors. A basic logger was implemented also. The UI is provided by
a Windows Form application. The scope of work is defined as a transaction that contains the shared and common functionality of the solution.

The input file used is in Miscellaneous folder. 

Usage
*****

1-. Start application
2-. Select a compliant file (as per assumption 1), this will display OpenFile dialog and if a file is selected is shown in textbox. Click on button with "..."
3-. Click on "Process File" button. Information is displayed in list 


Assumptions
***********
  1-. It's assumed that the input text file will contain a similar structure to the one referred to in the problem
  2-. It's assumed that the text file will be as plain text and not in a specialized format (e.g.: XML)   
  3-. Code doesn't do anything in parallel
  4-. Basic validation is done and exceptions are logged to a text file using "DDMMYYY_log.txt"  convention
  5-. There can be multiple instances of the application in execution
  6-. UI notification is done using events/eventhandlers
  7-. C# 6 features are used when possible (e.g.: null-conditional operator and string interpolation)
  8-. Exceptions are logged 