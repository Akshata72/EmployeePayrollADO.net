Use [payroll_service]
Go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[GetAllEmployeePayrollData()]
AS
BEGIN
SELECT Employee_Payroll.ID,First_Name,Last_Name,Gender,Basic_Pay,Deducations,Taxable_Pay,Income_Tax,Net_Pay from Employee_Payroll 
END
GO
exec [GetAllEmployeePayrollData()];
