SET IDENTITY_INSERT [dbo].[publisher] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[publisher] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[publisher]
    (
        [id],
        [name]
    )
    VALUES
    (1, N'Spectra');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[publisher] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[publisher]
    (
        [id],
        [name]
    )
    VALUES
    (2, N'Grafton Books');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[publisher] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[publisher]
    (
        [id],
        [name]
    )
    VALUES
    (3, N'Random House');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[publisher] WHERE id = 4)
BEGIN
    INSERT INTO [dbo].[publisher]
    (
        [id],
        [name]
    )
    VALUES
    (4, N'Del Rey');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[publisher] WHERE id = 5)
BEGIN
    INSERT INTO [dbo].[publisher]
    (
        [id],
        [name]
    )
    VALUES
    (5, N'Aslaradis Publishing');
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[publisher] WHERE id = 6)
BEGIN
    INSERT INTO [dbo].[publisher]
    (
        [id],
        [name]
    )
    VALUES
    (6, N'Orbit');
END;
GO

SET IDENTITY_INSERT [dbo].[publisher] OFF;