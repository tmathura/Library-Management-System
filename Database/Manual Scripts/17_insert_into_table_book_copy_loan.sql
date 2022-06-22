SET IDENTITY_INSERT [dbo].[book_copy_loan] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (1, 1, N'2022-04-01T00:00:00', N'2022-04-14T00:00:00', N'2022-04-10T00:00:00', 2);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (2, 1, N'2022-04-01T00:00:00', N'2022-04-14T00:00:00', N'2022-04-14T00:00:00', 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (3, 13, N'2022-04-01T00:00:00', N'2022-04-14T00:00:00', N'2022-04-14T00:00:00', 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 4)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (4, 2, N'2022-04-15T00:00:00', N'2022-04-28T00:00:00', N'2022-04-24T00:00:00', 2);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 5)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (5, 3, N'2022-04-15T00:00:00', N'2022-04-28T00:00:00', N'2022-04-24T00:00:00', 2);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 6)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (6, 4, N'2022-04-15T00:00:00', N'2022-04-28T00:00:00', N'2022-04-24T00:00:00', 2);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 7)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (7, 3, N'2022-05-01T00:00:00', N'2022-05-14T00:00:00', N'2022-05-14T00:00:00', 3);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 8)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (8, 16, N'2022-05-01T00:00:00', N'2022-05-14T00:00:00', N'2022-05-13T00:00:00', 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 9)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (9, 13, N'2022-05-15T00:00:00', N'2022-05-28T00:00:00', N'2022-05-22T00:00:00', 2);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 10)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (10, 13, N'2022-05-15T00:00:00', N'2022-05-28T00:00:00', N'2022-05-28T00:00:00', 3);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 11)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (11, 26, N'2022-06-15T00:00:00', N'2022-06-28T00:00:00', N'2022-06-25T00:00:00', 4);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy_loan] WHERE id = 12)
BEGIN
    INSERT INTO [dbo].[book_copy_loan]
    (
        [id],
        [book_copy_id],
        [from_date],
        [to_date],
        [return_date],
        [borrower_id]
    )
    VALUES
    (12, 62, N'2022-06-15T00:00:00', N'2022-06-28T00:00:00', N'2022-06-20T00:00:00', 5);
END;
GO

SET IDENTITY_INSERT [dbo].[book_copy_loan] OFF;