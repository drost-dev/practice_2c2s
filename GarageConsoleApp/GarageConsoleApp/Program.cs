namespace GarageConsoleApp;

/// <summary>
/// Класс Program
/// здесь описываем логику приложения
/// вызываем нужные методы пишем обработчики и тд
/// </summary>
public class Program 
{
    public static void Main(string[] args)
    {
        /*// Вызовем метод для получения данных о водителях
        DatabaseRequests.GetDriverQuery();
        Console.WriteLine();
        // Добавим нового водителя в БД
        DatabaseRequests.AddDriverQuery("Денис", "Иванов", DateTime.Parse("1997.01.12"));
        // Вызовем метод для получения данных о водителях
        DatabaseRequests.GetDriverQuery();
        
        // Вызовем метод для получения данных о типах автомобилей
        DatabaseRequests.GetTypeCarQuery();
        Console.WriteLine();
        // Добавим новый тип автомобиля в БД
        DatabaseRequests.AddTypeCarQuery("Воздушный");
        // Вызовем метод для получения данных о типах автомобилей
        DatabaseRequests.GetTypeCarQuery();*/
        
        
        
        //Console.Clear();
        Console.WriteLine("Добро пожаловать в систему управления предприятием.");
        

        while (true)
        {
            Console.Write("\nЧто вас интересует?\n" +
                              "1 - типы машин\n" +
                              "2 - водители и их права\n" +
                              "3 - машины\n" +
                              "4 - маршруты\n" +
                              "5 - рейсы\n" +
                              "0 - выход\n" +
                              "> ");
            
            switch (getChoose())
            {
                case 1:
                    //1. Просмотр и добавление типов машин;
                    Console.Write("  1 - просмотр\n" +
                                  "  2 - добавление\n" +
                                  "  0 - возврат\n" +
                                  "  > ");
                
                    switch (getChoose())
                    {
                        case 1:
                            DatabaseRequests.GetTypeCarQuery();
                            break;
                        case 2:
                            Console.Write("Название типа авто: ");
                            DatabaseRequests.AddTypeCarQuery(Console.ReadLine());
                            break;
                        case 0:
                            break;
                    }
                    break;
                case 2:
                    //2. Просмотр и добавление водителей и их прав;
                    
                    Console.Write("  1 - просмотр\n" +
                                  "  2 - добавление\n" +
                                  "  0 - возврат\n" +
                                  "  > ");
                
                    switch (getChoose())
                    {
                        case 1:
                            //просмотр водителей и прав
                            Console.Write("    1 - все водители\n" +
                                          "    2 - по ID\n" +
                                          "    0 - возврат\n" +
                                          "    > ");
                
                            switch (getChoose())
                            {
                                case 1:
                                    //все водители
                                    DatabaseRequests.GetDriverAndRightsCategoryQuery();
                                    break;
                                case 2:
                                    //по ID
                                    Console.Write("ID водителя: ");
                                    DatabaseRequests.GetDriverRightsCategoryQuery(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 0:
                                    break;
                            }
                            break;
                        case 2:
                            //добавление водителей и прав
                            Console.Write("Имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Фамилия: ");
                            string surname = Console.ReadLine();
                            Console.Write("Дата рождения: ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            int id = DatabaseRequests.AddDriverQuery(name, surname, date);
                            
                            Console.Write("Введите категории прав (слитно): ");
                            string rights = Console.ReadLine();
                            foreach (var category in rights)
                            {
                                var categoryId = DatabaseRequests.GetDriverRightsCategoryByNameQuery(category);
                                if (categoryId != -1)
                                {
                                    DatabaseRequests.AddDriverRightsCategoryQuery(id, categoryId);
                                }
                                else
                                {
                                    Console.WriteLine($"Категории {category} не существует!");
                                }
                            }
                            break;
                        case 0:
                            break;
                    }
                    break;
                case 3:
                    //3. Просмотр и добавление машин;
                    //машины
                    Console.Write("  1 - просмотр\n" +
                                  "  2 - добавление\n" +
                                  "  0 - возврат\n" +
                                  "  > ");
                    
                    switch (getChoose())
                    {
                        case 1:
                            DatabaseRequests.GetCarQuery();
                            break;
                        case 2:
                            Console.Write("запрос: ");
                            //DatabaseRequests.AddTypeCarQuery(Console.ReadLine());
                            
                            //TODO: доделать добавление авто
                            
                            break;
                        case 0:
                            break;
                    }
                    break;
                case 4:
                    //4. Просмотр и добавление маршрутов;
                    //маршруты
                    break;
                case 5:
                    //5. Просмотр и добавление рейсов;
                    //рейсы
                    break;
                case 0:
                    Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("Такого варианта нет.");
                    break;
            }
        }
    }

    static int getChoose()
    {
        int choose;
        while (true)
        {
            try
            {
                choose = Convert.ToInt32(Console.ReadLine());
                //Console.Clear();
                return choose;
            }
            catch (Exception e)
            {
                Console.WriteLine("Неверный ввод.");
            }
        }
    }
}