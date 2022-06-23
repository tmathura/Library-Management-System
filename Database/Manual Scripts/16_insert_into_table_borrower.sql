SET IDENTITY_INSERT [dbo].[borrower] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[borrower] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[borrower]
    (
        [id],
        [first_name],
        [last_name],
        [contact_number],
        [address]
    )
    VALUES
    (1, N'Hannes', N'Bothma', N'+27586038182', N'635 Gregory Isle East Zanele, KZN 6064');
END;

IF NOT EXISTS (SELECT * FROM [dbo].[borrower] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[borrower]
    (
        [id],
        [first_name],
        [last_name],
        [contact_number],
        [address]
    )
    VALUES
    (2, N'Heather', N'Solomon', N'+27137489941', N'5028 Masango Fords Ceciliatown, NC 8775');
END;

IF NOT EXISTS (SELECT * FROM [dbo].[borrower] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[borrower]
    (
        [id],
        [first_name],
        [last_name],
        [contact_number],
        [address]
    )
    VALUES
    (3, N'Thulani', N'Booysen', N'+27126969185', N'746 Collins Vista Suite 543 South Juliahaven, KZN 7169');
END;

IF NOT EXISTS (SELECT * FROM [dbo].[borrower] WHERE id = 4)
BEGIN
    INSERT INTO [dbo].[borrower]
    (
        [id],
        [first_name],
        [last_name],
        [contact_number],
        [address]
    )
    VALUES
    (4, N'Clive', N'Swanepoel', N'+27121037914', N'7436 Human Stravenue Suite 261 Adamshaven, KZN 0546');
END;

IF NOT EXISTS (SELECT * FROM [dbo].[borrower] WHERE id = 5)
BEGIN
    INSERT INTO [dbo].[borrower]
    (
        [id],
        [first_name],
        [last_name],
        [contact_number],
        [address]
    )
    VALUES
    (5, N'Asanda', N'Davies', N'+27284592737', N'986 Unathi Extensions Apt. 377 North Brandonchester, NC');
END;

SET IDENTITY_INSERT [dbo].[borrower] OFF;