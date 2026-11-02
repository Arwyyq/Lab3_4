using System;

namespace Lab3_4
{
    //клас в якому генерується подія
    public class Car
    {
        public string Model { get; set; }
        public double Fuel { get; set; }
        public double CurrentSpeed { get; private set; }
        public double MaxAllowedSpeed { get; set; }

        //Оголошує подію з використання стандартного делегата
        public event EventHandler<CarEventArgs>? SpeedLimitExceeded;

        public Car(string model, double maxAllowedSpeed, double initialFuel = 20)
        {
            Model = model;
            MaxAllowedSpeed = maxAllowedSpeed;
            Fuel = initialFuel;
            CurrentSpeed = 0;
        }

        public void StartEngine()
        {
            Console.WriteLine($"\n[{Model}] Двигун запущено.");
        }

        public void StopEngine()
        {
            CurrentSpeed = 0;
            Console.WriteLine($"[{Model}] Автомобіль зупинився. Двигун вимкнено.");
        }

        public void Refuel(double amount)
        {
            Fuel += amount;
            Console.WriteLine($"[{Model}] Заправлено {amount} л. Поточний бак: {Fuel} л.");
        }

        //Метод руху та прискорення
        public void Accelerate(double speedIncrease)
        {
            if (Fuel <= 0)
            {
                Console.WriteLine($"[{Model}] Бак порожній! Рух неможливий");
                return;
            }

            CurrentSpeed += speedIncrease;
            Fuel -= speedIncrease * 0.05; //0.005 літрів на 1 км/год прискорення

            Console.WriteLine($"[{Model}] Поточна швидкість: {CurrentSpeed} км/год (Паливо: {Fuel:F1} л)");

            //Перевірка перевищення швидкості
            if (CurrentSpeed > MaxAllowedSpeed)
            {
                CarEventArgs args = new CarEventArgs(CurrentSpeed, MaxAllowedSpeed, "Увага! Перевищення ліміту швидкості!");

                //викликає подію
                OnSpeedLimitExceeded(args);
            }
        }

        protected virtual void OnSpeedLimitExceeded(CarEventArgs e)
        {
            SpeedLimitExceeded?.Invoke(this, e);
        }
    }
}