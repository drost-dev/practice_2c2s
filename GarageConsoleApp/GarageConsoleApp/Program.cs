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
        Console.Clear();
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
                    Console.Write("\t1 - просмотр\n" +
                                  "\t2 - добавление\n" +
                                  "\t0 - возврат\n" +
                                  "\t> ");
                
                    switch (getChoose())
                    {
                        case 1:
                            DatabaseRequests.GetTypeCarQuery();
                            break;
                        case 2:
                            //добавление типов машин
                            Console.Write("запрос: ");
                            DatabaseRequests.AddTypeCarQuery(Console.ReadLine());
                            break;
                        case 0:
                            break;
                    }
                    break;
                case 2:
                    //водители, их права
                    break;
                case 3:
                    //машины
                    break;
                case 4:
                    //маршруты
                    break;
                case 5:
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
        int choose = 0;
        while (true)
        {
            try
            {
                choose = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                return choose;
            }
            catch (Exception e)
            {
                Console.WriteLine("Неверный ввод.");
            }
        }
    }
}