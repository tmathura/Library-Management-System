CREATE OR ALTER PROCEDURE [dbo].[borrowers_borrowed_book_count_for_each_time_frame_get]
(@borrower_id INT)
AS
BEGIN
    SELECT bcl.from_date,
           bcl.to_date,
           COUNT(*) AS books_loaned
    FROM [dbo].[book_copy_loan] bcl
    WHERE bcl.borrower_id = @borrower_id
    GROUP BY bcl.from_date,
             bcl.to_date
    ORDER BY bcl.from_date;
END;