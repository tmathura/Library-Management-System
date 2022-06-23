CREATE OR ALTER PROCEDURE [dbo].[top_borrowed_books_get]
(@number_of_books INT)
AS
BEGIN
    SELECT TOP (@number_of_books)
           COUNT(*) AS copies_loaned,
           b.id,
           b.isbn,
           b.title,
           b.[description],
           b.total_pages,
           b.published_date,
           b.publisher_id
    FROM [dbo].[book_copy_loan] bcl
        INNER JOIN [dbo].[book_copy] bc
            ON bc.id = bcl.book_copy_id
        INNER JOIN [dbo].[book] b
            ON b.id = bc.book_id
    GROUP BY b.id,
             b.isbn,
             b.title,
             b.[description],
             b.total_pages,
             b.published_date,
             b.publisher_id
    ORDER BY COUNT(*) DESC,
             b.id ASC;
END;