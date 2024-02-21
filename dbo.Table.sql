CREATE TABLE [dbo].[RentHistory]
(
	[RentalHistoryId] INT NOT NULL PRIMARY KEY, 
    [RentalDamaged] BIT NULL, 
    [DamagesIncurred] NCHAR(10) NULL, 
    [Rental] NCHAR(10) NULL
)
