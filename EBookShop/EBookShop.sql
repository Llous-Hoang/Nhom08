use EBookShop
GO

DELETE FROM Carts;
DBCC CHECKIDENT ('EBookShop.dbo.Carts', RESEED, 0);
GO
DELETE FROM InvoiceDetails;
DBCC CHECKIDENT ('EBookShop.dbo.InvoiceDetails', RESEED, 0);
GO
DELETE FROM Invoices;
DBCC CHECKIDENT ('EBookShop.dbo.Invoices', RESEED,0 );
GO
DELETE FROM Accounts;
DBCC CHECKIDENT ('EBookShop.dbo.Accounts', RESEED, 0);
GO
DELETE FROM Products;
DBCC CHECKIDENT ('EBookShop.dbo.Products', RESEED, 0);
GO
DELETE FROM ProductTypes;
DBCC CHECKIDENT ('EBookShop.dbo.ProductTypes', RESEED, 0);
GO

INSERT into Accounts(username,password,email,phone,address,avatar,isAdmin,isActive) VALUES ('admin', 'admin', 'admin@cty.com', '0123456789', N'Đồng Nai','1.jpg',1,1)
INSERT into Accounts(username,password,email,phone,address,avatar,isAdmin,isActive) VALUES ('tinhyeucuatoi', 'loveyou', 'tinhyeu@cty.com', '0213456789', N'Hồ Chí Minh','2.jpg',0,1)
INSERT into Accounts(username,password,email,phone,address,avatar,isAdmin,isActive) VALUES ('bautroituoitho', 'sky', 'shpere@cty.com', '0312456789', N'Bến Tre','3.jpg',0,1)
INSERT into Accounts(username,password,email,phone,address,avatar,isAdmin,isActive) VALUES ('ozawa', 'japanese', 'jpa@cty.com', '0412356789', N'Đồng Tháp','4.jpg',0,1)
INSERT into Accounts(username,password,email,phone,address,avatar,isAdmin,isActive) VALUES ('gamer', 'dbzgoku', 'dragonball@cty.com', '0512346789', N'Bình Định','5.jpg',0,1)
INSERT into Accounts(username,password,email,phone,address,avatar,isAdmin,isActive) VALUES ('designer', 'myhobbyneverdie', 'lovoshop@cty.com', '0612345789', N'Ninh Bình','6.jpg',0,1)



INSERT INTO Products(SKU,Name,Description,Price, Stock,ProductTypeId, Image, Status) VALUES ( '8934974180968', N'Box Set Dạy Con Làm Giàu - Trọn Bộ 13 Cuốn (Tái Bản 2022)', '', 1376400,19,2,'',1)
INSERT INTO Products(SKU,Name,Description,Price, Stock,ProductTypeId, Image, Status) VALUES ( '8934974150350', N'Harry Potter Hộp (Trọn Bộ 7 Cuốn)', '', 1550000,46,1,'',1)
INSERT INTO Products(SKU,Name,Description,Price, Stock,ProductTypeId, Image, Status) VALUES ( '8934974178163', N'Ajin - BoxSet Số 1 (Tập 1 Đến Tập 6) - Tặng Kèm Bookmark 3D', '', 300000,60,4,'',1)
INSERT INTO Products(SKU,Name,Description,Price, Stock,ProductTypeId, Image, Status) VALUES ( '8934974178996', N'Ajin - BoxSet Số 2 (Tập 7 Đến Tập 12) - Tặng Kèm Bookmark', '', 300000,0,4,'',1)
INSERT INTO Products(SKU,Name,Description,Price, Stock,ProductTypeId, Image, Status) VALUES ( '8934974180500', N'Ajin - BoxSet Số 3 (Tập 13 Đến Tập 17) - Tặng Kèm Bookmark', '', 270000,15,4,'',1)
INSERT INTO Products(SKU,Name,Description,Price, Stock,ProductTypeId, Image, Status) VALUES ( '8935235231115', N'Đời Ngắn Đừng Ngủ Dài (Tái Bản 2018)', '', 55000,26,2,'',1)

INSERT INTO ProductTypes(Name,Status) VALUES (N'Văn học', 1)
INSERT INTO ProductTypes(Name,Status) VALUES (N'Tâm lý- Kỹ năng sống', 1)
INSERT INTO ProductTypes(Name,Status) VALUES (N'Ngoại ngữ', 1)
INSERT INTO ProductTypes(Name,Status) VALUES (N'Truyện tranh', 1)
INSERT INTO ProductTypes(Name,Status) VALUES (N'Kinh tế', 1)

INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (1, 1, 2);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (2, 1, 4);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (5, 2, 2);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (5, 6, 1);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (5, 5, 3);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (5, 4, 5);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (2, 5, 7);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (2, 3, 2);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (2, 6, 4);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (4, 2, 1);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (4, 3, 1);
INSERT INTO Carts (AccountId, ProductId, Quantity) VALUES (4, 6, 2);

INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('299541176755', 5, '2020-01-15 15:06:12', N'Quận 3, Tp.HCM', '0987654321', 618000, 1);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('527777447269', 2, '2020-01-16 10:30:19', N'Quận 1, Tp.HCM', '0983564782', 167000, 1);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('228448970415', 2, '2020-01-18 18:02:07', N'Quận 5, Tp.HCM', '0983564782', 570000, 1);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('827349270900', 2, '2020-01-20 20:35:53', N'Quận 1, Tp.HCM', '0983564782', 480000, 0);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('127745305853', 3, '2020-01-24 08:20:17', N'Quận 7, Tp.HCM', '0905785346', 829000, 1);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('074407650817', 4, '2020-01-24 09:00:52', N'Nha Trang', '0459123845', 478000, 0);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('611108375524', 3, '2020-01-28 14:20:54', N'Quận 7, Tp.HCM', '0905785346', 642000, 1);
INSERT INTO Invoices (Code, AccountId, IssuedDate, ShippingAddress, ShippingPhone, Total, Status) VALUES ('178291648473', 4, '2020-01-24 18:29:07', N'Nha Trang', '0459123845', 327000, 1);

INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (1, 1, 2, 45000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (1, 3, 5, 59000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (1, 4, 1, 53000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (1, 6, 3, 60000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (2, 5, 1, 40000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (2, 2, 1, 55000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (2, 1, 2, 36000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (3, 5, 10, 57000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (4, 1, 4, 50000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (4, 3, 7, 40000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (5, 2, 4, 50000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (5, 3, 3, 59000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (5, 4, 6, 57000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (5, 2, 2, 55000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (6, 5, 7, 52000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (6, 6, 2, 57000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (7, 6, 2, 36000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (7, 2, 10, 57000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (8, 4, 1, 53000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (8, 6, 3, 60000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (8, 4, 1, 56000);
INSERT INTO InvoiceDetails (InvoiceId, ProductId, Quantity, UnitPrice) VALUES (8, 1, 1, 38000);