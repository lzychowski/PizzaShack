-- Run these statements to create tables that will work with the Models/Pizza.edmx model
-- Not all columns are used

CREATE TABLE [dbo].[statustypes]
(
	[statustypeid] INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(50) NOT NULL
)
​
INSERT INTO [dbo].[statustypes] VALUES ('Pending'), ('Baking'), ('Completed'), ('Closed')
​​
CREATE TABLE [dbo].[ingredients]
(
	[ingredientid] INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(50) NOT NULL,
	[price] DECIMAL(5,2) NOT NULL
)
​
INSERT INTO [dbo].[ingredients] VALUES ('Cheese', 2.00), ('Sauce', 2.00), ('Sausage', 3.00), ('Onion', 1.00)
​
CREATE TABLE [dbo].[orders]
(
	[orderid] INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(50),
	[phonenumber] VARCHAR(50) NOT NULL,
	[password] VARCHAR(50) NOT NULL,
	[pickupdatetime] DATETIME NOT NULL,
	[startdatetime] DATETIME NULL,
	[enddatetime] DATETIME NULL,
	[statustype] INT NOT NULL FOREIGN KEY REFERENCES statustypes(statustypeid)
)
​
CREATE TABLE [dbo].[orderingredients]
(
	[orderid] INT NOT NULL FOREIGN KEY REFERENCES orders(orderid),
	[ingredientid] INT NOT NULL FOREIGN KEY REFERENCES ingredients(ingredientid),
	[quantity] INT NOT NULL
)