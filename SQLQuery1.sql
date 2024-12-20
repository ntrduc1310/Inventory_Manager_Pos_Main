CREATE TABLE SaleDetail (
    SaleDetailID INT IDENTITY(1,1) PRIMARY KEY, -- Khoá chính
    SaleID INT NOT NULL,                        -- Khoá ngoại tham chiếu đến bảng Sale
    ProductID INT NOT NULL,                     -- Khoá ngoại tham chiếu đến bảng Product
    Quantity INT NOT NULL,                      -- Số lượng sản phẩm
    Price DECIMAL(18, 2) NOT NULL,              -- Giá mỗi sản phẩm
    SubTotal DECIMAL(18, 2) NOT NULL,           -- Tổng tiền cho sản phẩm (Quantity * Price)
    CreatedAt DATETIME DEFAULT GETDATE()        -- Ngày tạo bản ghi
);

-- Tạo khoá ngoại liên kết với bảng Sale
ALTER TABLE SaleDetail
ADD CONSTRAINT FK_SaleDetail_Sale FOREIGN KEY (SaleID)
REFERENCES Sale(SaleID) ON DELETE CASCADE;

-- Tạo khoá ngoại liên kết với bảng Product
ALTER TABLE SaleDetail
ADD CONSTRAINT FK_SaleDetail_Products FOREIGN KEY (ProductID)
REFERENCES Products(ProductID) ON DELETE CASCADE;
