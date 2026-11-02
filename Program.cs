using System;

namespace Lab3_4
{
    public delegate int StringProcessor(string input);

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // == -- == Частина 1 == -- ==
            Console.WriteLine("= - = Завдання 1: Делегати, анонімні методи та лямбда-вирази = - =");

            string testString = "Привіт Світ! Hello World 123";
            Console.WriteLine($"Текстовий рядок: \"{testString}\"");

            //Реалізація через Анонімний Метод (delegate)
            StringProcessor anonymousMethod = delegate (string str)
            {
                int count = 0;
                foreach (char letter in str)
                {
                    if (char.IsLower(letter))
                    {
                        count++;
                    }
                }
                return count;
            };

            //Реалізація через Лямбда-вираз
            StringProcessor lambdaExpression = str =>
            {
                int count = 0;
                foreach (char letter in str)
                {
                    if (char.IsLower(letter))
                    {
                        count++;
                    }
                }
                return count;
            };
            //Викликаємо обидва варіанти через делегати
            int resultAnon = anonymousMethod(testString);
            int resultLambda = lambdaExpression(testString);

            Console.WriteLine($"Кількість малих літер (через анонімний метод): {resultAnon}");
            Console.WriteLine($"Кількість малих літер (через лямбда-вираз): {resultLambda}");

            // == -- == Частина 2 та 3 == -- ==
            Console.WriteLine("\n\n = - = Завдання 2 та 3: Події");

            Car myCar = new Car("Audi S5 b6", maxAllowedSpeed: 50, initialFuel: 10);

            myCar.SpeedLimitExceeded += PoliceRadar_SpeedLimitExceeded;

            myCar.StartEngine();
            myCar.Accelerate(30); // 30 км/год - все ок
            myCar.Accelerate(15); // 45 км/год - все ок

            Console.WriteLine("\n --- Виїждаємо на пряму дорогу... ---");
            myCar.Accelerate(20); // 65 км/год - перевищення (спрацює подія)

            myCar.StopEngine();
            myCar.Refuel(15);
        }

        private static void PoliceRadar_SpeedLimitExceeded(object? sender, CarEventArgs e)
        {
            // Перевіряє хто саме викликав подію (перетворює sender на Car)
            if (sender is Car car)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n >> Поліцейський радар спрацював <<");
                Console.WriteLine($"Повідомлення: {e.Message}");
                Console.WriteLine($"Порушник: {car.Model}");
                Console.WriteLine($"Ліміт: {e.MaxAllowedSpeed} км/год | Поточна швидкість: {e.CurrentSpeed} км/год!");
                Console.WriteLine($"Виписано штраф!\n");
                Console.ResetColor();
            }
        }
    }

}