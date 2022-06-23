IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 1
          AND author_id = 1
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (1, 1);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 2
          AND author_id = 1
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (2, 1);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 3
          AND author_id = 1
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (3, 1);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 4
          AND author_id = 1
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (4, 1);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 5
          AND author_id = 2
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (5, 2);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 6
          AND author_id = 2
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (6, 2);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 7
          AND author_id = 2
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (7, 2);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 8
          AND author_id = 2
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (8, 2);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 9
          AND author_id = 2
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (9, 2);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 10
          AND author_id = 3
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (10, 3);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 11
          AND author_id = 3
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (11, 3);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 12
          AND author_id = 3
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (12, 3);
END;

IF NOT EXISTS
(
    SELECT *
    FROM [dbo].[book_author]
    WHERE book_id = 13
          AND author_id = 4
)
BEGIN
    INSERT INTO [dbo].[book_author]
    (
        [book_id],
        [author_id]
    )
    VALUES
    (13, 4);
END;