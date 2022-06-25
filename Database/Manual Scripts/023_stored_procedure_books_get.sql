CREATE OR ALTER PROCEDURE [dbo].[books_get]
(@book_id INT NULL)
AS
BEGIN
    SELECT b.id,
           b.isbn,
           b.title,
           b.[description],
           b.total_pages,
           b.published_date,
           b.publisher_id
    FROM [dbo].[book] b
    WHERE (
              b.id = @book_id
              OR @book_id IS NULL
          )
    ORDER BY b.id;
END;