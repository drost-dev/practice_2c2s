-- Вывод всех данных из таблицы RightsCategory
SELECT * FROM rights_category;
-- Вывод всех данных из таблицы Driver
SELECT * FROM driver;

-- Добавление данных в таблицу Driver
INSERT INTO driver(first_name, last_name, birthdate) VALUES ('Иван', 'Салманов', '2000-02-01');

-- Добавление данных в таблицу DriveRightsCategory(Добавление категории прав водителю)
INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES (4, 2);

-- Вывод прав всех водителей
SELECT dr.first_name, dr.last_name, rc.name
FROM driver_rights_category
         INNER JOIN driver dr on driver_rights_category.id_driver = dr.id
         INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category;

-- Вывод прав конкретного водителя
SELECT dr.first_name, dr.last_name, rc.name
FROM driver_rights_category
         INNER JOIN driver dr on driver_rights_category.id_driver = dr.id
         INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category
WHERE dr.id = 1;