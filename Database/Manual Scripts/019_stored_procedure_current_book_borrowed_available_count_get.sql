CREATE OR ALTER PROCEDURE [dbo].[book_status_get]
(@book_id INT)
AS
BEGIN
    SELECT COUNT(CASE WHEN bc.book_status_id = 1 THEN 1 ELSE NULL END) AS available,
           COUNT(CASE WHEN bc.book_status_id = 2 THEN 1 ELSE NULL END) AS borrowed,
           COUNT(CASE WHEN bc.book_status_id = 3 THEN 1 ELSE NULL END) AS lost
    FROM [dbo].[book_copy] bc
        INNER JOIN [dbo].[book] b
            ON b.id = bc.book_id
    WHERE b.id = @book_id;
END;