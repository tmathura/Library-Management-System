SET IDENTITY_INSERT [dbo].[author] ON;

INSERT INTO [dbo].[author]
(
    [id],
    [first_name],
    [middle_name],
    [last_name]
)
VALUES
(1, N'Raymond', N'E.', N'Feist'),
(2, N'Peter', N'V.', N'Brett '),
(3, N'James', NULL, N'Islington'),
(4, N'Jane', NULL, N'Jensen');

SET IDENTITY_INSERT [dbo].[author] OFF;