using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class SQLMethods
    {
        // Создаем текстовую переменную для хранения "пробела"
        static readonly string space = " ";

        // Метод для вывода списка всех версий
        public static string ReturnAllVersions()
        {
            // Создаем текстовую переменную для сборки возвращаемого результата
            string textResult = "";            

            // Создаем экземпляр класса контекста 
            DemoBaseContext demoBase = new();

            // Соединяем таблицы
            var queryResult = from StVersion in demoBase.StVersions
                         join StMain in demoBase.StMains on StVersion.InIdMain equals StMain.InId
                         join DsType in demoBase.DsTypes on StMain.InIdType equals DsType.InId
                         orderby StVersion.InId // Сортируем результаты по возрастанию StVersion.InId
                         select new { ID = StVersion.InId, Version = StVersion.StNumber, Name = StMain.StName, Type = DsType.StName };

            // Выводим информацию
            foreach (var row in queryResult)
            {
                textResult += row.ID + space + row.Version + space + row.Name + space + row.Type + "\n";
            }
            return textResult; // Возвращаем результат
        }

        // Метод для вывода конкретной версии
        public static string ReturnCustomVersion(int version)
        {
            string textResult = ""; // Создаем текстовую переменную для сборки возвращаемого результата

            // Создаем экземпляр класса контекста 
            DemoBaseContext demoBase = new();

            // Соединяем таблицы
            var queryResult = from StVersion in demoBase.StVersions
                         join StMain in demoBase.StMains on StVersion.InIdMain equals StMain.InId
                         join DsType in demoBase.DsTypes on StMain.InIdType equals DsType.InId
                         where StVersion.InId == version // Делаем выборку по запрашиваемой версии
                         orderby StVersion.InId // Сортируем результаты по возрастанию StVersion.InId
                         select new { ID = StVersion.InId, Version = StVersion.StNumber, Name = StMain.StName, Type = DsType.StName };

            // Выводим информацию
            if (queryResult.Any()) // Если результат не пустой
            {
                foreach (var row in queryResult)
                {
                    textResult += row.ID + space + row.Version + space + row.Name + space + row.Type + "\n";
                }
                return textResult; // Возвращаем результат
            }
            else // В противном случае - выдаем предупреждение об отсутствии запрашиваемой версии
            {
                return "Запрашиваемая версия не найдена!";
            }
        }
    }
}
