IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'book_copy'
)
BEGIN
    CREATE TABLE [dbo].[book_copy]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [book_id] INT NOT NULL,
        [barcode] INT NOT NULL,
        [book_status_id] INT NOT NULL,
        CONSTRAINT [PK_book_copy_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_copy_book_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book_copy]')
)
BEGIN
    ALTER TABLE [dbo].[book_copy] WITH CHECK ADD CONSTRAINT [FK_book_copy_book_id] FOREIGN KEY ([book_id]) REFERENCES [dbo].[book] ([id]);
END;

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_copy_book_status_idbook_status_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book_copy]')
)
BEGIN
    ALTER TABLE [dbo].[book_copy] WITH CHECK ADD CONSTRAINT [FK_book_copy_book_status_id] FOREIGN KEY ([book_status_id]) REFERENCES [dbo].[book_status] ([id]);
END;

IF OBJECT_ID('[dbo].[UQ_book_copy_barcode]', 'UQ') IS NULL 
BEGIN
    ALTER TABLE [dbo].[book_copy] ADD CONSTRAINT [UQ_book_copy_barcode] UNIQUE ([barcode]);
END;