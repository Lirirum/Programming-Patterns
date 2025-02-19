using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class WeatherTracker : IObservable<WeatherData>
    {

        private List<IObserver<WeatherData>> observers = new();
       
        public WeatherTracker()
        {
            observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }


        private class Unsubscriber : IDisposable
        {
            private List<IObserver<WeatherData>> _observers;
            private IObserver<WeatherData> _observer;

            public Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void TrackWeather(WeatherData weatherData)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(weatherData);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
            {
                if (observers.Contains(observer))
                    observer.OnCompleted();
            }

            observers.Clear();
        }
    }

    
}
