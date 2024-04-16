CREATE TABLE IF NOT EXISTS itinerary
(
    id   SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS type_car
(
    id   SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE IF NOT EXISTS car
(
    id                SERIAL PRIMARY KEY,
    id_type_car       INT REFERENCES type_car (id) NOT NULL,
    name              VARCHAR(100)                 NOT NULL,
    state_number      VARCHAR(10) UNIQUE           NOT NULL,
    number_passengers INT                          NOT NULL
);

CREATE TABLE IF NOT EXISTS driver
(
    id         SERIAL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name  VARCHAR(50) NOT NULL,
    birthdate  DATE        NOT NULL
);

CREATE TABLE IF NOT EXISTS route
(
    id                SERIAL PRIMARY KEY,
    id_driver         INT REFERENCES driver (id)    NOT NULL,
    id_car            INT REFERENCES car (id)       NOT NULL,
    id_itinerary      INT REFERENCES itinerary (id) NOT NULL,
    number_passengers INT                           NOT NULL
);


CREATE TABLE IF NOT EXISTS rights_category
(
    id   SERIAL PRIMARY KEY,
    name VARCHAR(5) NOT NULL
);

CREATE TABLE IF NOT EXISTS driver_rights_category
(
    id_driver          INT REFERENCES driver (id)          NOT NULL,
    id_rights_category INT REFERENCES rights_category (id) NOT NULL,
    PRIMARY KEY (id_driver, id_rights_category)
);
