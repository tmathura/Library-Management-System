IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'borrower'
)
BEGIN
    CREATE TABLE [dbo].[borrower]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [first_name] NVARCHAR(200) NOT NULL,
        [last_name] NVARCHAR(200) NOT NULL,
        [contact_number] NVARCHAR(15) NOT NULL,
        [address] NVARCHAR(500) NOT NULL,
        CONSTRAINT [PK_borrower_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO