CREATE OR ALTER PROCEDURE [dbo].[top_borrowed_books_get]
(@number_of_books INT)
AS
BEGIN
    SELECT TOP (@number_of_books) b.id, b.title, COUNT(*) AS copies_loaned
    FROM [dbo].[book_copy_loan] bcl
        INNER JOIN [dbo].[book_copy] bc ON bc.id = bcl.book_copy_id
        INNER JOIN [dbo].[book] b ON b.id = bc.book_id
    GROUP BY b.id, b.title
    ORDER BY COUNT(*) DESC, b.id ASC;
END;