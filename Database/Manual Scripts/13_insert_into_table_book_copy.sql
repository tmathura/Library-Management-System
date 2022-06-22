SET IDENTITY_INSERT [dbo].[book_copy] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (1, 1, 352937340, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (2, 2, 895561092, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (3, 3, 486862645, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 4)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (4, 4, 616635367, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 5)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (5, 5, 764521378, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 6)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (6, 6, 822479937, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 7)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (7, 7, 265504039, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 8)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (8, 8, 342400406, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 9)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (9, 9, 62844303, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 10)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (10, 10, 22703206, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 11)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (11, 11, 737823730, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 12)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (12, 12, 77686418, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 13)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (13, 13, 278574638, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 14)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (14, 1, 637880206, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 15)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (15, 2, 423034619, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 16)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (16, 3, 942034024, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 17)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (17, 4, 15756861, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 18)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (18, 5, 120932880, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 19)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (19, 6, 16031147, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (20, 7, 152447175, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 21)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (21, 8, 646932929, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 22)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (22, 9, 475892425, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 23)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (23, 10, 49005473, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 24)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (24, 11, 901609323, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 25)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (25, 12, 483284294, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 26)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (26, 13, 444443004, 2);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 27)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (27, 1, 759867238, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 28)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (28, 2, 799988760, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 29)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (29, 3, 751567001, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 30)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (30, 4, 191338485, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 31)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (31, 5, 147805664, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 32)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (32, 6, 110348237, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 33)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (33, 7, 495792343, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 34)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (34, 8, 588281033, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 35)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (35, 9, 994056111, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 36)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (36, 10, 999777797, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 37)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (37, 11, 176477204, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 38)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (38, 12, 451100293, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 39)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (39, 13, 282785298, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 40)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (40, 1, 54225380, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 41)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (41, 2, 247566719, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 42)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (42, 3, 829411576, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 43)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (43, 4, 616818782, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 44)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (44, 5, 422119903, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 45)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (45, 6, 915092079, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 46)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (46, 7, 87386899, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 47)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (47, 8, 642410416, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 48)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (48, 9, 390106996, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 49)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (49, 10, 746592943, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 50)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (50, 11, 234357788, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 51)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (51, 12, 659929537, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 52)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (52, 13, 125854588, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 53)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (53, 1, 776302130, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 54)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (54, 2, 155052146, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 55)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (55, 3, 220242126, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 56)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (56, 4, 2567619, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 57)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (57, 5, 738038949, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 58)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (58, 6, 442268764, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 59)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (59, 7, 624366821, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 60)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (60, 8, 412803560, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 61)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (61, 9, 503409761, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 62)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (62, 10, 443298506, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 63)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (63, 11, 162867223, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 64)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (64, 12, 810157378, 1);
END;
GO

IF NOT EXISTS (SELECT * FROM [dbo].[book_copy] WHERE id = 65)
BEGIN
    INSERT INTO [dbo].[book_copy]
    (
        [id],
        [book_id],
        [barcode],
        [book_status_id]
    )
    VALUES
    (65, 13, 435573406, 1);
END;
GO

SET IDENTITY_INSERT [dbo].[book_copy] OFF;