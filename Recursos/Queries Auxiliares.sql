USE master
GO
ALTER DATABASE PROMOS_DB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE PROMOS_DB

USE PROMOS_DB
SELECT * FROM ARTICULOS
SELECT * FROM CATEGORIAS
SELECT * FROM IMAGENES
SELECT * FROM MARCAS
SELECT * FROM Clientes
SELECT * FROM Vouchers

-- INSERT INTO Vouchers (CodigoVoucher) VALUES ('Codigo06')
-- INSERT INTO Vouchers (CodigoVoucher) VALUES ('Codigo07')
-- INSERT INTO Vouchers (CodigoVoucher) VALUES ('Codigo08')
-- INSERT INTO Vouchers (CodigoVoucher) VALUES ('Codigo09')
-- INSERT INTO Vouchers (CodigoVoucher) VALUES ('Codigo10')

-- update IMAGENES set IdArticulo = 2 where IdArticulo = 1

-- Para probar el carousel con cantidad variable de fotos
-- UPDATE IMAGENES SET IdArticulo = 2 WHERE Id = 3

-- SELECT * FROM Vouchers WHERE CodigoVoucher = 'Codigo02'

-- DELETE FROM Clientes WHERE Id = x

-- UPDATE Vouchers SET IdCliente = NULL, FechaCanje = NULL, IdArticulo = NULL WHERE CodigoVoucher = 'Codigo02'
