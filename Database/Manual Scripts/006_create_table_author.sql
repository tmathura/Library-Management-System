IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'author'
)
BEGIN
    CREATE TABLE [dbo].[author]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [first_name] NVARCHAR(200) NOT NULL,
        [middle_name] NVARCHAR(200) NULL,
        [last_name] NVARCHAR(200) NOT NULL,
        CONSTRAINT [PK_author_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO