using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class WeatherReporter : IObserver<WeatherData>
    {
        private IDisposable unsubscriber;
        private string instName;

        public WeatherReporter(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<WeatherData> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
                Console.WriteLine("📡 Підписка на отримання даних про погоду від {0}.", this.Name);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Відстежувач погоди завершив передачу даних до {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception error)
        {
            Console.WriteLine($"❌ Помилка: {error.Message}");
        }

        public virtual void OnNext(WeatherData value)
        {
            Console.WriteLine($"{this.Name} отримав сповіщення");
            Console.WriteLine($"Дисплей: |🌡  Поточна температура: {value.Temperature}°C| 🧭  Тиск: {value.Pressure} | 💧  Віднсона вологість: {value.Humidity}%");
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
