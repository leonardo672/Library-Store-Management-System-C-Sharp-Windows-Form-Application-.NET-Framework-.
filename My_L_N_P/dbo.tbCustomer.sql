CREATE TABLE [dbo].[tbCustomer] (
    [cid]    INT          NOT NULL IDENTITY,
    [cname]  VARCHAR (50) NOT NULL,
    [cphone] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([cid] ASC)
);

