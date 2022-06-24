IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'book_status'
)
BEGIN
    CREATE TABLE [dbo].[book_status]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [status] NVARCHAR(200) NOT NULL,
        CONSTRAINT [PK_book_status_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO