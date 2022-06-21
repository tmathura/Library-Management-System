IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'book'
)
BEGIN
    CREATE TABLE [dbo].[book]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [isbn] BIGINT NOT NULL,
        [title] NVARCHAR(200) NOT NULL,
        [description] NVARCHAR(MAX) NOT NULL,
        [total_pages] INT NOT NULL,
        [published_date] DATETIME NOT NULL,
        [publisher_id] INT NOT NULL,
        CONSTRAINT [PK_book_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_publisher_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book]')
)
BEGIN
    ALTER TABLE [dbo].[book] WITH CHECK ADD CONSTRAINT [FK_book_publisher_id] FOREIGN KEY ([publisher_id]) REFERENCES [dbo].[publisher] ([id]);
END;

IF OBJECT_ID('[dbo].[UQ_book_isbn]', 'UQ') IS NULL 
BEGIN
    ALTER TABLE [dbo].[book] ADD CONSTRAINT [UQ_book_isbn] UNIQUE ([isbn]);
END;