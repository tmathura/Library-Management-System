CREATE OR ALTER PROCEDURE [dbo].[other_books_loaned_by_borrowers_of_a_specific_book_get]
(@book_id INT)
AS
BEGIN
    SELECT b.id,
           b.isbn,
           b.title,
           b.[description],
           b.total_pages,
           b.published_date,
           b.publisher_id
    FROM dbo.book_copy_loan bcl
        INNER JOIN dbo.book_copy bc
            ON bc.id = bcl.book_copy_id
        INNER JOIN dbo.book b
            ON b.id = bc.book_id
        JOIN
        (
            SELECT bcl.borrower_id
            FROM dbo.book_copy_loan bcl
                INNER JOIN dbo.book_copy bc
                    ON bc.id = bcl.book_copy_id
            WHERE bc.book_id = @book_id
        ) AS other_borrowers
            ON bcl.borrower_id = other_borrowers.borrower_id
    GROUP BY bc.book_id,
             b.id,
             b.isbn,
             b.title,
             b.[description],
             b.total_pages,
             b.published_date,
             b.publisher_id
    ORDER BY bc.book_id;
END;