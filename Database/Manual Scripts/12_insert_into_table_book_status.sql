SET IDENTITY_INSERT [dbo].[book_status] ON;

INSERT INTO [dbo].[book_status]
(
    [id],
    [status]
)
VALUES
(1, N'Available'),
(2, N'Borrowed'),
(3, N'Lost');

SET IDENTITY_INSERT [dbo].[book_status] OFF;