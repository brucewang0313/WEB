SELECT 
*
FROM Shippers

INSERT INTO Shippers(CompanyName,Phone)
--VALUES代表可新增多筆資料
VALUES('Post Office #1','(02)3333-2221'),
('Post Office #2','(02)3333-2222'),
('Post Office #3','(02)3333-2223')

--不能直接插入會報錯，因為KEY值是會自行帶入，要透過以下步驟：
INSERT INTO Shippers(ShipperID,CompanyName,Phone)
VALUES(5,'Air Delevery','(02)3333-2221')

-- 1. 開啟手動插入 IDENTITY 欄位的開關
SET IDENTITY_INSERT Shippers ON;

-- 2. 執行你的插入指令
INSERT INTO Shippers (ShipperID, CompanyName, Phone)
VALUES (5, 'Air Delevery', '(02)3333-2221');

-- 3. 執行完畢後，務必將開關關閉（恢復預設狀態）
SET IDENTITY_INSERT Shippers OFF;