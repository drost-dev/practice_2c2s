-- Добавление типов автомобилей
INSERT INTO type_car(name) VALUES ('Автобус');
INSERT INTO type_car(name) VALUES ('Микроавтобус');
INSERT INTO type_car(name) VALUES ('Легковой автомобиль');


-- Добавление автомобилей
INSERT INTO car(id_type_car, name, state_number, number_passengers)
VALUES (1, 'ПАЗ-32053', 'К800МР70', 25);
INSERT INTO car(id_type_car, name, state_number, number_passengers)
VALUES (2, 'Hyundai Grand Starex 1', 'С197КХ70', 9);
INSERT INTO car(id_type_car, name, state_number, number_passengers)
VALUES (3, 'Audi A8', 'С395ММ70', 3);
INSERT INTO car(id_type_car, name, state_number, number_passengers)
VALUES (3, 'LADA Vesta', 'К581ХВ70', 3);


-- Добавление маршрутов
INSERT INTO itinerary(name) VALUES ('Томск-Новосибирск');
INSERT INTO itinerary(name) VALUES ('Новосибирск-Томск');
INSERT INTO itinerary(name) VALUES ('Томск-Кемерово');
INSERT INTO itinerary(name) VALUES ('Томск-Колпашево');
INSERT INTO itinerary(name) VALUES ('Молчаново-Томск');


-- Добавление водителей
INSERT INTO driver(first_name, last_name, birthdate) VALUES ('Дмитрий', 'Антипов', '1958-01-08');
INSERT INTO driver(first_name, last_name, birthdate) VALUES ('Виктор', 'Гаан', '2000-04-05');
INSERT INTO driver(first_name, last_name, birthdate) VALUES ('Даниил', 'Авдеев', '2001-11-28');


-- Добавление категорий прав
INSERT INTO rights_category(name) VALUES ('A');
INSERT INTO rights_category(name) VALUES ('B');
INSERT INTO rights_category(name) VALUES ('D');


-- Добавление категорий прав водителям
INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES (1, 1);
INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES (1, 2);
INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES (2, 2);
INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES (2, 3);
INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES (3, 2);


-- Добавление рейсов
INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES (1, 3, 1, 1);
INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES (2, 4, 3, 2);
INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES (3, 3, 2, 3);
INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES (2, 2, 5, 7);


-- Вывод данных из таблиц
select * from route;
select * from driver_rights_category;
select * from rights_category;
select * from driver;
select * from itinerary;
select * from car;
select * from type_car;