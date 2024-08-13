CREATE TABLE [dbo].[tborder] (
    [orderid] INT  IDENTITY (1, 1) NOT NULL,
    [odate]   DATE NOT NULL,
    [pid]     INT  NOT NULL,
    [cid]     INT  NOT NULL,
    [qty]     INT  NOT NULL,
    [price]   INT  NOT NULL,
    [total]   INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([orderid] ASC)
);

