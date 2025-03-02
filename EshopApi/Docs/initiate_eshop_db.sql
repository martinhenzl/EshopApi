-- Create the product database
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'EshopDB')
	BEGIN
		CREATE DATABASE EshopDB;
	END
GO

-- Use the database
USE EshopDB;
GO

-- Create the Products table
IF OBJECT_ID(N'Products', N'U') IS NULL
	BEGIN
		CREATE TABLE Products (
			Id INT IDENTITY(1,1) PRIMARY KEY,
			Name NVARCHAR(255) NOT NULL,
			ImgUri NVARCHAR(512) NOT NULL,
			Price DECIMAL(18,2) NOT NULL,
			Description NVARCHAR(MAX) NULL
		);
	END	
GO

-- Insert initial seed data
INSERT INTO Products (Name, ImgUri, Price, Description) VALUES
	('Laptop', 'laptop.jpg', 999.99, 'High-performance laptop'),
	('Smartphone', 'smartphone.jpg', 699.99, 'Latest model smartphone'),
	('Tablet', 'tablet.jpg', 499.99, 'Lightweight and powerful tablet'),
	('Smartwatch', 'smartwatch.jpg', 199.99, 'Feature-rich smartwatch with fitness tracking'),
	('Wireless Earbuds', 'earbuds.jpg', 149.99, 'Noise-canceling wireless earbuds'),
	('Gaming Console', 'console.jpg', 499.99, 'Next-gen gaming console'),
	('Mechanical Keyboard', 'keyboard.jpg', 129.99, 'RGB mechanical keyboard with customizable keys'),
	('Wireless Mouse', 'mouse.jpg', 59.99, 'Ergonomic wireless mouse with high precision'),
	('External Hard Drive', 'harddrive.jpg', 89.99, '2TB external hard drive for extra storage'),
	('4K Monitor', 'monitor.jpg', 349.99, '27-inch 4K UHD monitor with HDR support'),
	('Bluetooth Speaker', 'speaker.jpg', 79.99, 'Portable Bluetooth speaker with deep bass'),
	('Gaming Headset', 'headset.jpg', 129.99, 'Surround sound gaming headset with noise-canceling mic'),
	('Smart TV', 'smart_tv.jpg', 599.99, '55-inch 4K Smart TV with HDR and streaming apps'),
	('VR Headset', 'vr_headset.jpg', 399.99, 'Immersive virtual reality headset'),
	('Portable Power Bank', 'powerbank.jpg', 49.99, '10,000mAh power bank for charging on the go');
GO

-- Create the mock database
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'MOCKEshopDB')
	BEGIN
		CREATE DATABASE MOCKEshopDB;
	END
GO

-- Use the database
USE MOCKEshopDB;
GO

-- Create the Products table
IF OBJECT_ID(N'Products', N'U') IS NULL
	BEGIN
		CREATE TABLE Products (
			Id INT IDENTITY(1,1) PRIMARY KEY,
			Name NVARCHAR(255) NOT NULL,
			ImgUri NVARCHAR(512) NOT NULL,
			Price DECIMAL(18,2) NOT NULL,
			Description NVARCHAR(MAX) NULL
		);
	END	
GO

-- Insert initial seed data
INSERT INTO Products (Name, ImgUri, Price, Description) VALUES
	('Laptop', 'laptop.jpg', 999.99, 'High-performance laptop'),
	('Smartphone', 'smartphone.jpg', 699.99, 'Latest model smartphone'),
	('Tablet', 'tablet.jpg', 499.99, 'Lightweight and powerful tablet'),
	('Smartwatch', 'smartwatch.jpg', 199.99, 'Feature-rich smartwatch with fitness tracking'),
	('Wireless Earbuds', 'earbuds.jpg', 149.99, 'Noise-canceling wireless earbuds'),
	('Gaming Console', 'console.jpg', 499.99, 'Next-gen gaming console'),
	('Mechanical Keyboard', 'keyboard.jpg', 129.99, 'RGB mechanical keyboard with customizable keys'),
	('Wireless Mouse', 'mouse.jpg', 59.99, 'Ergonomic wireless mouse with high precision'),
	('External Hard Drive', 'harddrive.jpg', 89.99, '2TB external hard drive for extra storage'),
	('4K Monitor', 'monitor.jpg', 349.99, '27-inch 4K UHD monitor with HDR support'),
	('Bluetooth Speaker', 'speaker.jpg', 79.99, 'Portable Bluetooth speaker with deep bass'),
	('Gaming Headset', 'headset.jpg', 129.99, 'Surround sound gaming headset with noise-canceling mic'),
	('Smart TV', 'smart_tv.jpg', 599.99, '55-inch 4K Smart TV with HDR and streaming apps'),
	('VR Headset', 'vr_headset.jpg', 399.99, 'Immersive virtual reality headset'),
	('Portable Power Bank', 'powerbank.jpg', 49.99, '10,000mAh power bank for charging on the go');
GO
