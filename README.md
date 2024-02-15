# MVCapplicationDemo
Before Starting Coding for this MVC architectural pattern application using DAL layer for accessing Database , First You have to Create a database , Table and Stored Procedure are as follows :-
--------------------------------------------------------
<--- CREATE DATABASE [MVC_DB] first --->
Create Database MVC_DB
Use MVC_DB
<--- CREATE TABLE [Customer] -->
CREATE TABLE [dbo].[Customer]  
(  
[CustomerID] [int] NOT NULL Primary key identity(1,1),  
[Name] [varchar](100) NULL,  
[Address] [varchar](300) NULL,  
[Mobileno] [varchar](15) NULL,  
[Birthdate] [datetime] NULL,  
[EmailID] [varchar](300) NULL  
)   
<--- CREATE SINGLE STORED PROCEDURE FOR CRUD OPERATIONS --->
GO  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE PROCEDURE [dbo].[Usp_InsertUpdateDelete_Customer]  
@CustomerID INT = NULL  
,@Name NVARCHAR(100) = NULL  
,@Mobileno NVARCHAR(15) = NULL  
,@Address NVARCHAR(300) = 0  
,@Birthdate DATETIME = NULL  
,@EmailID NVARCHAR(15) = NULL  
,@Query INT  
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  

INSERT INTO Customer
(  
NAME,
Address,
Mobileno,
Birthdate,
EmailID  
)  
VALUES 
(  
@Name  
,@Address  
,@Mobileno  
,@Birthdate  
,@EmailID  
)  
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END  
IF (@Query = 2)  
BEGIN  
UPDATE Customer  
SET NAME = @Name  
,Address = @Address  
,Mobileno = @Mobileno  
,Birthdate = @Birthdate  
,EmailID = @EmailID  
WHERE Customer.CustomerID = @CustomerID  
SELECT 'Update'  
END  
IF (@Query = 3)  
BEGIN  
DELETE  
FROM Customer  
WHERE Customer.CustomerID = @CustomerID  
SELECT 'Deleted'  
END  
IF (@Query = 4)  
BEGIN  
SELECT *  
FROM Customer  
END  
END  
IF (@Query = 5)  
BEGIN  
SELECT *  
FROM Customer  
WHERE Customer.CustomerID = @CustomerID  
END   

