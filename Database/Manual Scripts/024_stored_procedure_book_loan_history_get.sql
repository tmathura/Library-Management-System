CREATE OR ALTER PROCEDURE [dbo].[book_loan_history_get]
(@book_id INT)
AS
BEGIN
    SELECT bcl.from_date,
           bcl.to_date,
           bcl.return_date,
           DATEDIFF(DAY, bcl.from_date, bcl.return_date) AS days_loaned
    FROM dbo.book_copy_loan bcl
        INNER JOIN dbo.book_copy bc
            ON bc.id = bcl.book_copy_id
        INNER JOIN dbo.book b
            ON b.id = bc.book_id
    WHERE b.id = @book_id
    ORDER BY bcl.from_date,
             bcl.return_date;
END;