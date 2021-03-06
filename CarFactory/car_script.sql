USE [Car_Dealer]
GO
/****** Object:  Table [dbo].[Suburbs]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suburbs](
	[IdSuburb] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [int] NULL,
 CONSTRAINT [PK_Suburbs] PRIMARY KEY CLUSTERED 
(
	[IdSuburb] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[IdStaff] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[IdStaff] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExtraProducts]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExtraProducts](
	[IdExtra] [int] IDENTITY(1,1) NOT NULL,
	[ExtraName] [varchar](50) NULL,
	[IdProduct] [int] NULL,
 CONSTRAINT [PK_ExtraProducts] PRIMARY KEY CLUSTERED 
(
	[IdExtra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Educations](
	[IdEducation] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[IdEducation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Occupations]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Occupations](
	[IdOccupation] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Occupations] PRIMARY KEY CLUSTERED 
(
	[IdOccupation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertStaff]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStaff]
@Firstname VARCHAR(50),
@Surname VARCHAR(50),
@DateCreated datetime

AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO dbo.Staff
            ( Firstname, Surname, DateCreated)
    VALUES( 
          @Firstname,
          @Surname,
          @DateCreated
       )
    
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProducts]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProducts]
@Name VARCHAR(50),
@Price MONEY
AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO dbo.Products
            ( Name, Price )
    VALUES  ( 
            @Name, @Price
             )
  
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProducts]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProducts]
@IdProduct INT,
@Name VARCHAR(50),
@Price MONEY
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE dbo.Products SET 
      Name = @Name,
      Price = @Price
   
   WHERE IdProduct = @IdProduct
    
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[IdCustomer] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[PostalCode] [int] NULL,
	[Phone] [varchar](50) NULL,
	[IdEducation] [int] NULL,
	[IdOccupation] [int] NULL,
	[IdSuburb] [int] NULL,
	[Occupation] [varchar](50) NULL,
	[Education] [varchar](50) NULL,
	[Suburb] [varchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetProductById]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductById]
@IdProduct INT 
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Products
	WHERE IdProduct = @IdProduct
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSuburbs]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSuburbs]
AS
BEGIN
 SET NOCOUNT ON;
  SELECT * FROM Suburbs NoLock
 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducts]

AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Products
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllOccupations]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllOccupations]
AS
BEGIN
 SET NOCOUNT ON;
  SELECT * FROM Occupations NoLock
 END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEducations]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllEducations]
AS
BEGIN
 SET NOCOUNT ON;
  SELECT * FROM Educations NoLock
 END
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 02/12/2019 19:14:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NULL,
	[IdProduct] [int] NULL,
	[Quantity] [int] NULL,
	[OrderDate] [datetime] NULL,
	[CustomerName] [varchar](50) NULL,
	[ProductName] [varchar](50) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomers]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCustomers]

AS

BEGIN

SET NOCOUNT ON;
	
    -- Insert statements for procedure here
    SELECT * FROM Customers
	--SELECT c.IdCustomer ,c.Name ,  c.[Address], c.PostalCode, c.Phone,
	--o.[Description] as JobTitle, e.Name as Qualification, s.Name as Suburb FROM dbo.Customers c
	--inner join Occupations o on o.IdOccupation = c.IdOccupation
	--inner join Suburbs s on s.IdSuburb = c.IdSuburb
	--inner join Educations e on e.IdEducation = c.IdEducation
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomer]
@Name VARCHAR(50),
@Address VARCHAR(50),
@PostalCode INT,
@Phone VARCHAR(50),
@IdOccupation INT,
@IdEducation INT,
@IdSuburb INT,
@Occupation VARCHAR(50),
@Suburb VARCHAR(50),
@Education VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO dbo.Customers
            ( Name, [Address], PostalCode, Phone, IdEducation,IdOccupation, IdSuburb,Occupation,Education,Suburb)
    VALUES( 
          @Name,
          @Address,
          @PostalCode,
          @Phone,
          @IdEducation,
          @IdOccupation,
          @IdSuburb,
          @Occupation,
          @Suburb,
          @Education
       )
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerById]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerById]
@IdCustomer INT 
AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Customers
	WHERE IdCustomer = @IdCustomer
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomers]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomers]
@IdCustomer INT,
@Name VARCHAR(50),
@Address VARCHAR(50),
@PostalCode INT,
@Phone VARCHAR(50),
@IdOccupation INT,
@IdEducation INT,
@IdSuburb INT,
@Occupation VARCHAR(50),
@Suburb VARCHAR(50),
@Education VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON;

    UPDATE dbo.Customers SET 
      Name = @Name,
      [Address] = @Address,
      PostalCode = @PostalCode,
      Phone = @Phone,
      IdOccupation = @IdOccupation,
      IdSuburb = @IdSuburb,
      IdEducation = @IdEducation,
      Occupation = @Occupation,
      Suburb = @Suburb,
      Education = @Education
          
   WHERE IdCustomer = @IdCustomer 
    
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateOrder]
@IdOrder INT,
@IdCustomer VARCHAR(50),
@IdProduct VARCHAR(50),
@Quantity INT,
@CustomerName VARCHAR(50),
@ProductName VARCHAR(50),
@Orderdate DATETIME
AS
BEGIN

	SET NOCOUNT ON;
	
	UPDATE dbo.Orders SET
	  IdCustomer = @IdCustomer,
      IdProduct = @IdProduct,
      Quantity  = @Quantity,
      CustomerName = @CustomerName,
      ProductName = @ProductName,
      OrderDate = @Orderdate
    WHERE IdOrder = @IdOrder
   
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrder]
@IdCustomer VARCHAR(50),
@IdProduct VARCHAR(50),
@Quantity INT,
@CustomerName VARCHAR(50),
@ProductName VARCHAR(50),
@Orderdate DATETIME
AS
BEGIN

	SET NOCOUNT ON;

    INSERT INTO dbo.Orders
            ( IdCustomer ,
              IdProduct ,
              Quantity ,
              CustomerName,
              ProductName,
              OrderDate
            )
    VALUES  ( @IdCustomer , -- IdCustomer - int
              @IdProduct , -- IdProduct - int
              @Quantity , -- Quantity - int
              @CustomerName,
              @ProductName,
              @OrderDate
            )
  
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderById]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderById]
@IdOrder INT
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT * FROM dbo.Orders
	WHERE IdOrder = @IdOrder
   
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllOrders]    Script Date: 02/12/2019 19:14:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllOrders]

AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT * FROM dbo.Orders
   
END
GO
/****** Object:  ForeignKey [FK_Customers_Educations]    Script Date: 02/12/2019 19:14:02 ******/
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Educations] FOREIGN KEY([IdOccupation])
REFERENCES [dbo].[Educations] ([IdEducation])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Educations]
GO
/****** Object:  ForeignKey [FK_Customers_Occupations]    Script Date: 02/12/2019 19:14:02 ******/
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Occupations] FOREIGN KEY([IdOccupation])
REFERENCES [dbo].[Occupations] ([IdOccupation])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Occupations]
GO
/****** Object:  ForeignKey [FK_Customers_Suburbs]    Script Date: 02/12/2019 19:14:02 ******/
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Suburbs] FOREIGN KEY([IdSuburb])
REFERENCES [dbo].[Suburbs] ([IdSuburb])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Suburbs]
GO
/****** Object:  ForeignKey [FK_Orders_Customers]    Script Date: 02/12/2019 19:14:02 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
/****** Object:  ForeignKey [FK_Orders_Products]    Script Date: 02/12/2019 19:14:02 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Products] ([IdProduct])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
