/****** Object:  Table [dbo].[Saledetail]    Script Date: 12-02-2021 10:26:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Saledetail]') AND type in (N'U'))
DROP TABLE [dbo].[Saledetail]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 12-02-2021 10:26:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sale]') AND type in (N'U'))
DROP TABLE [dbo].[Sale]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 12-02-2021 10:26:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registration]') AND type in (N'U'))
DROP TABLE [dbo].[Registration]
GO
/****** Object:  Table [dbo].[PartyMaster]    Script Date: 12-02-2021 10:26:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PartyMaster]') AND type in (N'U'))
DROP TABLE [dbo].[PartyMaster]
GO
/****** Object:  Table [dbo].[city]    Script Date: 12-02-2021 10:26:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[city]') AND type in (N'U'))
DROP TABLE [dbo].[city]
GO
/****** Object:  Table [dbo].[city]    Script Date: 12-02-2021 10:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[cityid] [int] IDENTITY(1,1) NOT NULL,
	[cityname] [varchar](50) NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[cityid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartyMaster]    Script Date: 12-02-2021 10:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyMaster](
	[partyid] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](50) NULL,
 CONSTRAINT [PK_PartyMaster] PRIMARY KEY CLUSTERED 
(
	[partyid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 12-02-2021 10:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[cityid] [int] NULL,
	[Isstudent] [bit] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 12-02-2021 10:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[Saleid] [int] IDENTITY(1,1) NOT NULL,
	[Customerid] [int] NULL,
	[Saledate] [datetime] NULL,
	[SaleNo] [int] NULL,
	[Remark] [nvarchar](500) NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Saleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saledetail]    Script Date: 12-02-2021 10:26:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saledetail](
	[Saledetailid] [int] IDENTITY(1,1) NOT NULL,
	[Saleid] [int] NULL,
	[ItemName] [nvarchar](50) NULL,
	[Qty] [int] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Saledetail] PRIMARY KEY CLUSTERED 
(
	[Saledetailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


---------------------------------------------------------------------------------------------------------------------------


USE [ParekhDbNew]
GO
/****** Object:  StoredProcedure [dbo].[Ins_Inward]    Script Date: 12-02-2021 22:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[Ins_Inward]
@InwardID int,
@PartyId int,
@InwardDate datetime,
@CenterId int,
@BillNo varchar(50),
@Remark nvarchar(MAX),
@AmountAdd int,
@AmountLess int,
@Total Numeric(18,2),
@Paid int,
@PaidRemark nvarchar(MAX),
@OrderNo varchar(50),
@OrderDate datetime,
@ChallanNo nvarchar(max),
@ChallanDate datetime,
@LRNo varchar(50),
@LRDate datetime,
@VatPerFour numeric(18,2),
@VatFourAmont numeric(18,2),
@ATaxOne numeric(18,2),
@ATaxOneAmount numeric(18,2),
@VatPerTwelveFive numeric(18,2),
@VatPerTwelveFiveAmount numeric(18,2),
@ATaxTwoFive numeric(18,2),
@ATaxTwoFiveAmount numeric(18,2),
@TotalAmont numeric(18,2),
@DisFive numeric(18,2),
@DisFiveAmount numeric(18,2),
@NetAmont numeric(18,2),
@CstTwoPer numeric(18,2),
@CstTwoPerAmount numeric(18,2),
@Roundoff numeric(18,2),
@DetailDiscount numeric(18,2),
@isQuatation bit,
@InvoiceType varchar(50),
@Action AS smallint,
@GSTNo varchar(50), 
@SGST5 numeric(18,2), 
@SGST12 numeric(18,2), 
@SGST18 numeric(18,2), 
@SGST28 numeric(18,2),	
@CGST5 numeric(18,2), 
@CGST12 numeric(18,2), 
@CGST18 numeric(18,2), 
@CGST28 numeric(18,2), 
@IGST5 numeric(18,2), 
@IGST12 numeric(18,2), 
@IGST18 numeric(18,2), 
@IGST28 numeric(18,2),
@StateCode int
,@IwdDetails As ins_InwardDetails READONLY
AS
BEGIN
SET NOCOUNT ON;

	BEGIN TRANSACTION;

	BEGIN TRY
		
		IF @Action = 1 
			BEGIN
				INSERT INTO dbo.Inward
				(
					PartyId, InwardDate, BillNo, Remark, AmountAdd, AmountLess, Total, Paid, PaidRemark, OrderNo,
					OrderDate, ChallanNo, ChallanDate, LRNo, LRDate, VatPerFour, VatFourAmont, ATaxOne, ATaxOneAmount, 
					VatPerTwelveFive, VatPerTwelveFiveAmount, ATaxTwoFive, ATaxTwoFiveAmount, TotalAmont, DisFive, DisFiveAmount,
					NetAmont, CstTwoPer, CstTwoPerAmount, Roundoff, DetailDiscount, isQuatation, InvoiceType,
					GSTNo, SGST5, SGST12, SGST18, SGST28,	CGST5, CGST12, CGST18, CGST28, IGST5, IGST12, IGST18, IGST28, StateCode
				)
				VALUES
				(
					@PartyId, @InwardDate, @BillNo, @Remark, @AmountAdd, @AmountLess, @Total, @Paid, @PaidRemark, @OrderNo,
					@OrderDate, @ChallanNo, @ChallanDate, @LRNo, @LRDate, @VatPerFour, @VatFourAmont, @ATaxOne, @ATaxOneAmount, 
					@VatPerTwelveFive, @VatPerTwelveFiveAmount, @ATaxTwoFive, @ATaxTwoFiveAmount, @TotalAmont, @DisFive, @DisFiveAmount,
					@NetAmont, @CstTwoPer, @CstTwoPerAmount, @Roundoff, @DetailDiscount, @isQuatation, @InvoiceType,
					@GSTNo, @SGST5, @SGST12, @SGST18, @SGST28,	@CGST5, @CGST12, @CGST18, @CGST28, @IGST5, @IGST12, @IGST18, @IGST28, @StateCode
				)
				SET @InwardID = SCOPE_IDENTITY ()
				
				INSERT into dbo.InwardDetail
				(
					InwardId, ItemId, CapitalA, Digital1, smalla, ItemRemark, HSNCode, 
					Unit, Qty, Rate ,Dis, DisAmount, Vatper, VatAmount, Amount, CapitalAHidden  	
				)
				SELECT 
					@InwardID, ItemId, CapitalA, Digital1, smalla, ItemRemark, HSNCode, 
					Unit, Qty, Rate ,Dis, DisAmount, Vatper, VatAmount, Amount, CapitalAHidden
				FROM @IwdDetails
				
				Select @InwardID InwardId

			END

		IF @Action = 2
			BEGIN
				UPDATE dbo.Inward SET
					PartyId = @PartyId, InwardDate = @InwardDate,  BillNo = @BillNo, Remark = @Remark, AmountAdd = @AmountAdd, 
					AmountLess = @AmountLess, Total = @Total, Paid = @Paid, PaidRemark = @PaidRemark, OrderNo = @OrderNo, OrderDate = @OrderDate, 
					ChallanNo = @ChallanNo, ChallanDate = @ChallanDate, LRNo = @LRNo, LRDate = @LRDate, VatPerFour = @VatPerFour, VatFourAmont = @VatFourAmont, 
					ATaxOne = @ATaxOne, ATaxOneAmount = @ATaxOneAmount,	VatPerTwelveFive = @VatPerTwelveFive, VatPerTwelveFiveAmount = @VatPerTwelveFiveAmount, 
					ATaxTwoFive = @ATaxTwoFive, ATaxTwoFiveAmount = @ATaxTwoFiveAmount, TotalAmont = @TotalAmont, DisFive = @DisFive, 
					DisFiveAmount = @DisFiveAmount, NetAmont = @NetAmont, CstTwoPer = @CstTwoPer, CstTwoPerAmount = @CstTwoPerAmount, Roundoff = @Roundoff, 
					DetailDiscount = @DetailDiscount, isQuatation = @isQuatation, InvoiceType = @InvoiceType,
					GSTNo = @GSTNo, SGST5 = @SGST5, SGST12 = @SGST12, SGST18 = @SGST18, SGST28 = @SGST28,
					CGST5 = @CGST5, CGST12 = @CGST12, CGST18 = @CGST18, CGST28 = @CGST28, 
					IGST5 = @IGST5, IGST12 = @IGST12, IGST18 = @IGST18, IGST28 = @IGST28,
					StateCode = @StateCode
				WHERE InwardId = @InwardID
			
				Delete From InwardDetail WHere InwardId = @InwardID 
				INSERT into dbo.InwardDetail
				(
					InwardId, ItemId, CapitalA, Digital1, smalla, ItemRemark, HSNCode, 
					Unit, Qty, Rate, Amount, Vatper, VatAmount ,Dis, DisAmount, CapitalAHidden	
				)
				SELECT 
					@InwardID, ItemId, CapitalA, Digital1, smalla, ItemRemark, HSNCode, 
					Unit, Qty, Rate, Amount, Vatper, VatAmount ,Dis, DisAmount, CapitalAHidden
				FROM @IwdDetails
				
				Select @InwardID InwardId
				
			END


	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0  
			ROLLBACK TRANSACTION;
	    
		Select 0 InwardId
	    
	END CATCH

	IF @@TRANCOUNT > 0  
		COMMIT TRANSACTION; 


END

