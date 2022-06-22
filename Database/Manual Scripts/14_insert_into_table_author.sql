SET IDENTITY_INSERT [dbo].[author] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[author] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[author]
    (
        [id],
        [first_name],
        [middle_name],
        [last_name]
    )
    VALUES
    (1, N'Raymond', N'E.', N'Feist');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[author] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[author]
    (
        [id],
        [first_name],
        [middle_name],
        [last_name]
    )
    VALUES
    (2, N'Peter', N'V.', N'Brett ');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[author] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[author]
    (
        [id],
        [first_name],
        [middle_name],
        [last_name]
    )
    VALUES
    (3, N'James', NULL, N'Islington');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[author] WHERE id = 4)
BEGIN
    INSERT INTO [dbo].[author]
    (
        [id],
        [first_name],
        [middle_name],
        [last_name]
    )
    VALUES
    (4, N'Jane', NULL, N'Jensen');
END;
GO

SET IDENTITY_INSERT [dbo].[author] OFF;