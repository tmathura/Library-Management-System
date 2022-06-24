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

SET IDENTITY_INSERT [dbo].[author] OFF;