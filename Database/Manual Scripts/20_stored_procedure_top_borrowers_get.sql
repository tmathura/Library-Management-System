CREATE OR ALTER PROCEDURE [dbo].[top_borrowers_get]
(
    @number_of_borrowers INT,
    @from_date DATETIME,
    @to_date DATETIME
)
AS
BEGIN
    SELECT TOP (@number_of_borrowers)
           COUNT(*) AS books_loaned,
           bw.id,
           bw.first_name,
           bw.last_name,
           bw.contact_number,
           bw.[address]
    FROM [dbo].[book_copy_loan] bcl
        INNER JOIN [dbo].[borrower] bw
            ON bw.id = bcl.borrower_id
    WHERE bcl.from_date
    BETWEEN @from_date AND @to_date
    GROUP BY bw.id,
             bw.first_name,
             bw.last_name,
             bw.contact_number,
             bw.[address]
    ORDER BY COUNT(*) DESC;
END;