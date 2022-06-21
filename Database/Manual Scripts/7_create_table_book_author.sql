IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'book_author'
)
BEGIN
    CREATE TABLE [dbo].[book_author]
    (
        [book_id] INT NOT NULL,
        [author_id] INT NOT NULL,
        CONSTRAINT [PK_book_author_id] PRIMARY KEY CLUSTERED ([book_id], [author_id] ASC) ON [PRIMARY]
    );
END;
GO

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_author_book_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book_author]')
)
BEGIN
    ALTER TABLE [dbo].[book_author] WITH CHECK ADD CONSTRAINT [FK_book_author_book_id] FOREIGN KEY ([book_id]) REFERENCES [dbo].[book] ([id]);
END;

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_author_author_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book_author]')
)
BEGIN
    ALTER TABLE [dbo].[book_author] WITH CHECK ADD CONSTRAINT [FK_book_author_author_id] FOREIGN KEY ([author_id]) REFERENCES [dbo].[author] ([id]);
END;