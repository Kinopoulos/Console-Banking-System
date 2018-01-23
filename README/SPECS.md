# Banking-System
Console Banking System for Coding Bootcamp.
You are required to build a Windows console application where you will be asked to read various inputs from the keyboard. These inputs will be used as login details and actions in order to control the internal banking system of a cooperative company. Each input will be used for directing the various subsystems of this private banking system. The output of the various subsystems will be displayed to the screen or it will be written to simple text files.

A. Logical Units of the application

Main application

Login Screen

Application’s menus

Database’s access

Files’ access

Internal Bank Accounts B. Description of the Logical Units of the application

The Main Application It holds all the class variables that will be consumed from the rest of the classes. It checks for proper database connectivity and displays via Logical Unit 2 the menus.

Login Screen You are required to build a class that will act as the login screen of the application. This login screen will be asking for the username / password of the user. The user should be able to login with the following credentials (username / password):

admin / admin, this is the super admin account
user1 / password1, this is a simple member’s account
user2 / password2, this is a simple member’s account The credentials should be checked for validity against the stored values in the database.
The Application’s menus are defined based on the level of the user. The super admin account should have the following menus:
View Cooperative’s (super admin) internal bank account
View Members’ bank accounts
Deposit to Member’s bank account
Withdraw from Member’s bank account
Send to the statement_admin_dd_mm_yyyy.txt file today’s transactions where dd_mm_yyyy are today’s day, month, year and Exit
Exit the application The simple member’s account should have the following menus:
View his bank account
Deposit to Cooperative’s internal bank account
Deposit to another Member’s bank account
Send to the statement_user_x_dd_mm_yyyy.txt file today’s transactions where dd_mm_yyyy are today’s day, month, year
Exit the application
The database should be created and initialized using the accompanied file: afdemp_csharp_1.sql The database must be a local SQL Server database running on the same machine with the application. From the Application’s menu each user should be able, depending on his level to:
View his account (all levels)
View all accounts (only super admin)
Deposit to Cooperative’s internal bank account (simple member)
Deposit to a Member’s bank account (all user levels)
Withdraw from Member’s bank account (only super admin)
Send today’s statement to a file (all user levels)
All user levels while they are logged in, must keep a memory buffer with all today’s transactions. When the user selects from the menu Send Today’s Statement to the file statement_user_x_dd_mm_yyyy.txt for the simple users or statement_admin_dd_mm_yyyy.txt for the super admin the application should write to the file all of the today’s transactions, then log out the user and terminate.

The Internal Bank Accounts are used for the following operations:

Display the user’s account balance (all user levels)
Display all of the users’ account balances (only super admin)
Deposit to a member’s account by using the member’s username and the desired amount (all user levels) from the current user’s bank account
Withdraw from a member’s bank account to the cooperative’s account using the member’s username and the desired amount (only super admin)
C. Deliverables You are requested to produce a C# console application that has the following:

Six (6) .cs files, the main application and one file per Logical Unit of the application as described above on A. [9 marks]
The Login Screen should be displayed first and it should let the user view the application’s main menu after correct input of the username / password combination which are checked against the values stored in the database table users [12 marks]
The application’s main menu should be changed depending the level of the user as described above on B.2. [4 marks]
The application should let the super admin to view all the accounts and deposit or withdraw from the simple users’ bank accounts while keeping all actions to memory and write to statement file via Send Today’s Statement [27 marks]
The application should let the simple users to deposit to the cooperative’s bank account an amount that is available to his bank account while keeping all actions to memory and write to statement file via Send Today’s Statement [25 marks]
Use the class BankAccounts as an intermediate storage for database’s data. Override the ToString() of the class BankAccount in order to show the user’s username, transaction date, amount. Format all currency data to be displayed and written to file with CultureInfo(“el-GR”). Format all dates to the form “yyyy-MM-dd HH:mm:ss.FFF”. [23 marks]
