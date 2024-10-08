Materials List Estimation Application
Overview
This C# GUI app helps a construction company estimate materials needed for building homes. Users can input item descriptions, quantities, and unit prices. The app calculates the cost for each item and shows a grand total.
Features
•	User Input: Enter item description, quantity, and unit price.
•	Cost Calculation: Calculates cost for each item.
•	Total Estimation: Shows total cost at the bottom.
•	GUI Interface: Easy-to-use graphical interface.
•	Excel Export: Save the materials list to an Excel file.
•	Table Management: Clear the table and reset forms.
•	External Links: Quick access to home improvement stores.
Requirements
•	.NET Framework: Version 4.7.2 or higher
•	Development Environment: Visual Studio 2019 or later
•	Libraries:
o	System.Windows.Forms
o	System.Drawing
o	OfficeOpenXml (for Excel export)
Usage
1.	Run the app by pressing F5 in Visual Studio or executing the .exe file.
2.	Click “Open Materials List.”
3.	Enter item description, quantity, and unit price.
4.	Click “Add Item” to add the item to the list.
5.	The app shows the cost for each item and the total cost at the bottom.
6.	Click “Save Table” to export the list to an Excel file.
7.	Click “Clear Table” to clear the list.
Code Structure
•	MainForm.cs: Main GUI logic and event handlers.
•	TableForm.cs: Manages the materials list table.
•	Item.cs: Defines the Item class.
•	Program.cs: Entry point of the app.
MainForm.cs
•	Responsibilities:
o	Initialize the main form and text boxes.
o	Open the TableForm.
o	Update text boxes with costs.
o	Save the materials list to an Excel file.
o	Clear the materials list and reset text boxes.
•	Key Methods:
o	OpenMaterialsListTableButton_Click
o	UpdateCategories
o	SaveTableButton_Click
o	ClearTableButton_Click
o	InitializeTextBoxes
o	ResetForms
•	Layout:
o	Buttons: “Open Materials List Table,” “Save Table,” “Clear Table.”
o	Categories: Floor, Walls, Openings, Roof, Total Cost.
TableForm.cs
•	Responsibilities:
o	Manage the materials list table.
o	Add items to the table.
o	Export the table to an Excel file.
o	Handle external links.
•	Key Methods:
o	AddButton_Click
o	ExportToExcel
o	ClearTable
o	UpdateButton_Click_1
o	linkLabel1_LinkClicked, linkLabel2_LinkClicked, linkLabel3_LinkClicked
o	TableForm_FormClosing
•	Layout:
o	Input Fields: Category, Item, Material, Description, Quantity, Unit Cost.
o	Action Buttons: Add, Update, Delete.
o	Tabs: Vendor 1, Vendor 2, Vendor 3.
o	Data Grid: Displays the materials list.
o	Total Cost Field: Shows the total cost.
Example
1.	MainForm Input:
o	Click “Open Materials List Table.”
2.	TableForm Input:
o	Category: “Floors”
o	Item: “Bricks”
o	Material: “Clay”
o	Description: “Red Clay Bricks”
o	Quantity: 1000
o	Unit Cost: $0.50
3.	TableForm Output:
o	Estimated Cost: $500.00
o	Total Estimated Cost: $500.00
Contact
For questions or suggestions, contact Nate Huizar, Logan Metcalfe, and Naylan Swarens.
