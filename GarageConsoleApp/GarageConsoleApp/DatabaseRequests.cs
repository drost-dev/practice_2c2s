using Npgsql;

namespace GarageConsoleApp;

/// <summary>
/// Класс DatabaseRequests
/// содержит методы для отправки запросов к БД
/// </summary>
public static class DatabaseRequests
{
    /// <summary>
    /// Метод GetTypeCarQuery
    /// отправляет запрос в БД на получение списка типов машин
    /// выводит в консоль список типов машин
    /// </summary>
    public static void GetTypeCarQuery()
    {
        // Сохраняем в переменную запрос на получение всех данных и таблицы type_car
        var querySql = "SELECT * FROM type_car";
        // Создаем команду(запрос) cmd, передаем в нее запрос и соединение к БД
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        // Выполняем команду(запрос)
        // результат команды сохранится в переменную reader
        using var reader = cmd.ExecuteReader();
        
        // Выводим данные которые вернула БД
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}, Название: {reader[1]}");
        }
    }

    /// <summary>
    /// Метод AddTypeCarQuery
    /// отправляет запрос в БД на добавление типа машины
    /// </summary>
    public static void AddTypeCarQuery(string name)
    {
        var checkExistQuerySql = $"SELECT count(name) FROM type_car WHERE name='{name}'";
        using var cmd = new NpgsqlCommand(checkExistQuerySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        reader.Read();
        //cmd.Cancel();
        if (Convert.ToInt32(reader[0]) >= 1)
        {
            Console.WriteLine($"Тип \"{name}\" уже существует!");
        }
        else
        {
            reader.Close();
            cmd.Cancel();
            var querySql = $"INSERT INTO type_car(name) VALUES ('{name}')";
            using var cmd2 = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd2.ExecuteNonQuery();
            Console.WriteLine($"\"{name}\" добавлен!");
        }
    }

    /// <summary>
    /// Метод AddDriverQuery
    /// отправляет запрос в БД на добавление водителей
    /// </summary>
    public static void AddDriverQuery(string firstName, string lastName, DateTime birthdate, string categories)
    {
        var querySql = $"SELECT count(*) FROM driver WHERE first_name='{firstName}' AND last_name='{lastName}'";
        using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
        {
            cmd.ExecuteNonQuery();
            cmd.Cancel();
        }
        
        querySql = $"INSERT INTO driver(first_name, last_name, birthdate) " +
                       $"VALUES ('{firstName}', '{lastName}', '{birthdate.Year}-{birthdate.Month}-{birthdate.Day}')";
        using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
        {
            cmd.ExecuteNonQuery();
            cmd.Cancel();
        }
        
        querySql = $"SELECT id FROM driver WHERE first_name='{firstName}' AND last_name='{lastName}'";
        int idDriver;
        using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
        {
            var reader = cmd.ExecuteReader();
            reader.Read();
            idDriver = Convert.ToInt32(reader[0]);
            reader.Close();
            cmd.Cancel();
        }

        bool atLeatsOneCategoryAdded = false;
        foreach (var category in categories)
        {
            try
            {
                querySql = $"SELECT count(id) FROM rights_category WHERE name='{category}'";
                using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                {
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    if (Convert.ToInt32(reader[0]) == 0)
                    {
                        Console.WriteLine($"Категории \"{category}\" не существует!");
                        reader.Close();
                        cmd.Cancel();
                        continue;
                    }
                    reader.Close();
                    cmd.Cancel();
                }
                
                int idCategory;
                querySql = $"SELECT id FROM rights_category WHERE name='{category}'";
                using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                {
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    idCategory = Convert.ToInt32(reader[0]);
                    reader.Close();
                    cmd.Cancel();
                }
                
                querySql = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES " +
                           $"('{idDriver}', '{idCategory}')";
                using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                {
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                }

                atLeatsOneCategoryAdded = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        if (!atLeatsOneCategoryAdded)
        {
            querySql = $"DELETE FROM driver WHERE id='{idDriver}'";
            using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Метод GetDriverQuery
    /// отправляет запрос в БД на получение списка водителей
    /// выводит в консоль данные о водителях
    /// </summary>
    public static void GetDriverQuery()
    {
        var querySql = "SELECT * FROM driver";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}, Имя: {reader[1]}, Фамилия: {reader[2]}, Дата рождения: {reader[3]}");
        }
    }
    
    public static void GetDriverAndRightsCategoryQuery()
    {
        var querySql = "SELECT * FROM driver " +
                       "INNER JOIN public.driver_rights_category drc on driver.id = drc.id_driver " +
                       "INNER JOIN public.rights_category rc on drc.id_rights_category = rc.id";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}, Имя: {reader[1]}, Фамилия: {reader[2]}, " +
                              $"Дата рождения: {reader[3]}, Категория прав: {reader[7]}");
        }
    }

    /// <summary>
    /// Метод AddRightsCategoryQuery
    /// отправляет запрос в БД на добавление категорий прав
    /// </summary>
    public static void AddRightsCategoryQuery(string name)
    {
        var querySql = $"INSERT INTO rights_category(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Метод AddDriverRightsCategoryQuery
    /// отправляет запрос в БД на добавление категории прав водителю
    /// </summary>
    public static void AddDriverRightsCategoryQuery(int driver, int rightsCategory)
    {
        var querySql = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES ({driver}, {rightsCategory})";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }
    
    public static int GetDriverRightsCategoryByNameQuery(char category)
    {
        var querySql = $"SELECT id FROM rights_category WHERE name='{category}'";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
        var reader = cmd.ExecuteReader();
        reader.Read();
        
        try
        {
            var categoryId = reader[0];
            reader.Close();
            return Convert.ToInt32(categoryId);
        }
        catch (Exception e)
        {
            reader.Close();
            return -1;
        }
    }

    /// <summary>
    /// Метод GetDriverRightsCategoryQuery
    /// отправляет запрос в БД на получение категорий водителей
    /// выводит в консоль информацию о категориях прав водителей
    /// </summary>
    public static void GetDriverRightsCategoryQuery(int driver)
    {
        var querySql = "SELECT dr.first_name, dr.last_name, rc.name " +
                       "FROM driver_rights_category " +
                       "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                       "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category " +
                       $"WHERE dr.id = {driver};";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Имя: {reader[0]}, Фамилия: {reader[1]}, Категория прав: {reader[2]}");
        }
    }
    
    public static void GetCarQuery()
    {
        // Сохраняем в переменную запрос на получение всех данных и таблицы type_car
        var querySql = "SELECT * FROM car INNER JOIN public.type_car tc on tc.id = car.id_type_car";
        // Создаем команду(запрос) cmd, передаем в нее запрос и соединение к БД
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        // Выполняем команду(запрос)
        // результат команды сохранится в переменную reader
        using var reader = cmd.ExecuteReader();
        
        // Выводим данные которые вернула БД
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}, Модель: {reader[2]}, Госномер: {reader[3]}, " +
                              $"Число пассажиров: {reader[4]}, Тип авто: {reader[6]}");
        }
    }
    
    public static void AddCarQuery(int id, string name, string stateNumber, int numOfPassengers)
    {
        var checkExistQuerySql = $"SELECT count(id) FROM type_car WHERE id='{id}'";
        int count = 0;
        using (var cmd = new NpgsqlCommand(checkExistQuerySql, DatabaseService.GetSqlConnection()))
        {
            using var reader = cmd.ExecuteReader();
            reader.Read();
            count = Convert.ToInt32(reader[0]);
            reader.Close();
            cmd.Cancel();
        }
        
        //cmd.Cancel();
        if (Convert.ToInt32(count) > 1)
        {
            Console.WriteLine($"Авто \"{name}\" уже существует!");
        }
        else if (Convert.ToInt32(count) == 0)
        {
            Console.WriteLine("Такого типа авто не существует!");
        }
        else
        {
            var querySql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers) " +
                           $"VALUES ('{id}', '{name}', '{stateNumber}', '{numOfPassengers}')";
            using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
            {
                cmd.ExecuteNonQuery();
            }
            
            Console.WriteLine($"Авто \"{name}\" добавлено!");
        }
    }
    
    public static void GetItinearyQuery()
    {
        var querySql = "SELECT * FROM itinerary";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}, Название: {reader[1]}");
        }
    }
    
    public static void AddItinearyQuery(string name)
    {
        var querySql = $"SELECT count(name) FROM itinerary WHERE name = '{name}'";
        var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        var reader = cmd.ExecuteReader();
        reader.Read();
        
        if (Convert.ToInt32(reader[0]) == 0)
        {
            cmd.Cancel();
            reader.Close();
            querySql = $"INSERT INTO itinerary(name) VALUES ('{name}')";
            cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Маршрут \"{name}\" добавлен!");
        }
        else
        {
            Console.WriteLine($"Маршрут \"{name}\" уже существует!");
        }
    }
    
    public static void GetRouteQuery()
    {
        var querySql = "SELECT route.id, d.first_name, d.last_name, c.name, c.state_number, i.name, route.number_passengers " +
                       "FROM route " +
                       "inner join driver d on d.id = route.id_driver " +
                       "inner join car c on c.id = route.id_car " +
                       "inner join itinerary i on i.id = route.id_itinerary";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]}, Водитель: {reader[1]} {reader[2]}, Авто: {reader[3]}, " +
                              $"Госномер: {reader[4]}, Маршрут: {reader[5]}, Количество пассажиров: {reader[6]}");
        }
    }
    
    public static void AddRouteQuery(int idDriver, int idCar, int idItinerary, int numOfPassengers)
    {
        /*var querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) " +
                       $"VALUES ('{idDriver}', '{idCar}', '{idItinerary}', '{numOfPassengers}')";*/
        var querySql =
            $"SELECT count(*) FROM route WHERE id_driver='{idDriver}' AND id_car='{idCar}' " +
            $"AND id_itinerary='{idItinerary}' AND number_passengers='{numOfPassengers}'";
        var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        var reader = cmd.ExecuteReader();
        reader.Read();
        
        if (Convert.ToInt32(reader[0]) == 0)
        {
            cmd.Cancel();
            reader.Close();
            querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) " +
                       $"VALUES ('{idDriver}', '{idCar}', '{idItinerary}', '{numOfPassengers}')";
            cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Рейс добавлен!");
        }
        else
        {
            Console.WriteLine($"Рейс уже существует!");
        }
    }
}