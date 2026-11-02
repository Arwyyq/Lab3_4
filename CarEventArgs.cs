using System;

namespace Lab3_4
{
    //клас-аргумент події
    public class CarEventArgs : EventArgs
    {
        public double CurrentSpeed { get; }
        public double MaxAllowedSpeed { get; }
        public string Message { get; }

        public CarEventArgs(double currentSpeed, double maxAllowedSpeed, string message)
        {
            CurrentSpeed = currentSpeed;
            MaxAllowedSpeed = maxAllowedSpeed;
            Message = message;
        }
    }
}