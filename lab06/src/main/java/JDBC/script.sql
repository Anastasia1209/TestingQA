use Lab6_Testing;

CREATE TABLE brands (
                        brand_id INT PRIMARY KEY identity(1, 1),
                        brand_name VARCHAR(255) NOT NULL
);

-- Создание таблицы автомобилей
CREATE TABLE cars (
                      car_id INT PRIMARY KEY identity(1, 1),
                      model VARCHAR(255) NOT NULL,
                      year INT,
                      price DECIMAL(10, 2),
                      brand_id INT,
                      FOREIGN KEY (brand_id) REFERENCES brands(brand_id)
);

INSERT INTO brands (brand_name) VALUES
                                    ('Toyota'),
                                    ('Ford'),
                                    ('Honda'),
                                    ('Chevrolet'),
                                    ('Nissan');

-- Вставка данных в таблицу автомобилей
INSERT INTO cars (model, year, price, brand_id) VALUES
                                                    ('Camry', 2022, 25000.00, 1),
                                                    ('F-150', 2023, 35000.50, 2),
                                                    ('Accord', 2021, 27000.75, 3),
                                                    ('Silverado', 2022, 30000.25, 4),
                                                    ('Altima', 2023, 28000.50, 5);

SELECT cars.car_id, cars.model, cars.year, cars.price, brands.brand_name
FROM cars
INNER JOIN brands ON cars.brand_id = brands.brand_id;

