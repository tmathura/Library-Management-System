SET IDENTITY_INSERT [dbo].[publisher] ON;

INSERT INTO [dbo].[publisher]
(
    [id],
    [name]
)
VALUES
(1, N'Spectra'),
(2, N'Grafton Books'),
(3, N'Random House'),
(4, N'Del Rey'),
(5, N'Aslaradis Publishing'),
(6, N'Orbit');

SET IDENTITY_INSERT [dbo].[publisher] OFF;