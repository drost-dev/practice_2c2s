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
        Console.WriteLine("Добро пожаловать в систему управления предприятием.");

        while (true)
        {
            try
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
                                var date = Console.ReadLine();
                                Console.Write("Введите категории прав (слитно): ");
                                string rights = Console.ReadLine();
                                DatabaseRequests.AddDriverQuery(name, surname, DateTime.Parse(date), rights);
                                Console.WriteLine("Сотрудник добавлен!");
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
                                Console.Write("ID типа авто: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Название: ");
                                string name = Console.ReadLine();
                                Console.Write("Госномер: ");
                                string stateNum = Console.ReadLine();
                                Console.Write("Число пассажиров: ");
                                int numOfPass = Convert.ToInt32(Console.ReadLine());
                                DatabaseRequests.AddCarQuery(id, name, stateNum, numOfPass);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 4:
                        //4. Просмотр и добавление маршрутов;
                        Console.Write("  1 - просмотр\n" +
                                      "  2 - добавление\n" +
                                      "  0 - возврат\n" +
                                      "  > ");
                        
                        switch (getChoose())
                        {
                            case 1:
                                DatabaseRequests.GetItinearyQuery();
                                break;
                            case 2:
                                Console.Write("Введите название маршрута: ");
                                string name = Console.ReadLine();
                                DatabaseRequests.AddItinearyQuery(name);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 5:
                        //5. Просмотр и добавление рейсов;
                        //рейсы
                        Console.Write("  1 - просмотр\n" +
                                      "  2 - добавление\n" +
                                      "  0 - возврат\n" +
                                      "  > ");
                        
                        switch (getChoose())
                        {
                            case 1:
                                DatabaseRequests.GetRouteQuery();
                                break;
                            case 2:
                                
                                DatabaseRequests.AddRouteQuery(1, 1, 1, 10);
                                //DatabaseRequests.AddItinearyQuery(name);
                                break;
                            case 0:
                                break;
                        }
                        break;
                    case 0:
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Такого варианта нет.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка!\n{e}");
                throw;
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