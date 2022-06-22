SET IDENTITY_INSERT [dbo].[book_status] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[book_status] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[book_status]
    (
        [id],
        [status]
    )
    VALUES
    (1, N'Available');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_status] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[book_status]
    (
        [id],
        [status]
    )
    VALUES
    (2, N'Borrowed');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_status] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[book_status]
    (
        [id],
        [status]
    )
    VALUES
    (3, N'Lost');
END;
GO

SET IDENTITY_INSERT [dbo].[book_status] OFF;