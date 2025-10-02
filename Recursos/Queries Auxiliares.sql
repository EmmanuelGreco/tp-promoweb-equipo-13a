-- -- USE master;
-- -- GO;
-- -- ALTER DATABASE PROMOS_DB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- -- DROP DATABASE PROMOS_DB;

USE PROMOS_DB;
SELECT * FROM ARTICULOS
SELECT * FROM CATEGORIAS
SELECT * FROM IMAGENES
SELECT * FROM MARCAS
SELECT * FROM Clientes
SELECT * FROM Vouchers

-- Para probar el carousel con cantidad variable de fotos
-- UPDATE IMAGENES SET IdArticulo = 2 WHERE Id = 3

-- DELETE FROM Clientes WHERE Id = x

-- UPDATE Vouchers SET IdCliente = NULL, FechaCanje = NULL, IdArticulo = NULL WHERE CodigoVoucher = 'Codigo02'