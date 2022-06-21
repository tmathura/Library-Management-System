IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'book_copy_loan'
)
BEGIN
    CREATE TABLE [dbo].[book_copy_loan]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [book_copy_id] INT NOT NULL,
        [from_date] DATETIME NOT NULL,
        [to_date] DATETIME NOT NULL,
        [return_date] DATETIME NULL,
        [borrower_id] INT NOT NULL,
        CONSTRAINT [PK_book_copy_loan_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_copy_loan_book_copy_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book_copy_loan]')
)
BEGIN
    ALTER TABLE [dbo].[book_copy_loan] WITH CHECK ADD CONSTRAINT [FK_book_copy_loan_book_copy_id] FOREIGN KEY ([book_copy_id]) REFERENCES [dbo].[book_copy] ([id]);
END;

IF NOT EXISTS
(
    SELECT *
    FROM sys.foreign_keys
    WHERE object_id = OBJECT_ID(N'[dbo].[FK_book_copy_loan_borrower_id]')
          AND parent_object_id = OBJECT_ID(N'[dbo].[book_copy_loan]')
)
BEGIN
    ALTER TABLE [dbo].[book_copy_loan] WITH CHECK ADD CONSTRAINT [FK_book_copy_loan_borrower_id] FOREIGN KEY ([borrower_id]) REFERENCES [dbo].[borrower] ([id]);
END;

IF OBJECT_ID('[dbo].[CK_book_copy_loan_to_date_less_than_from_date]', 'C') IS NULL 
BEGIN
    ALTER TABLE [dbo].[book_copy_loan] ADD CONSTRAINT [CK_book_copy_loan_to_date_less_than_from_date] CHECK ([to_date] > [from_date]);
END;

IF OBJECT_ID('[dbo].[CK_book_copy_loan_return_date_less_than_from_date]', 'C') IS NULL 
BEGIN
    ALTER TABLE [dbo].[book_copy_loan] ADD CONSTRAINT [CK_book_copy_loan_return_date_less_than_from_date] CHECK ([return_date] > [from_date]);
END;