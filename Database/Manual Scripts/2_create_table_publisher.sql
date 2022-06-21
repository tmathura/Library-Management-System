IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
          AND TABLE_NAME = 'publisher'
)
BEGIN
    CREATE TABLE [dbo].[publisher]
    (
        [id] INT NOT NULL IDENTITY(1, 1),
        [name] NVARCHAR(200) NOT NULL,
        CONSTRAINT [PK_publisher_id] PRIMARY KEY CLUSTERED ([id] ASC) ON [PRIMARY]
    );
END;
GO