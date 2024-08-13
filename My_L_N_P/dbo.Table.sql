CREATE TABLE [dbo].[tbOrder]
(
	[orderid] INT NOT NULL PRIMARY KEY IDENTITY, 
    [odata] DATE NOT NULL, 
    [pid] INT NOT NULL, 
    [cid] INT NOT NULL, 
    [qty] INT NOT NULL, 
    [price] INT NOT NULL, 
    [total] INT NOT NULL
)
