using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FahrenheitToCelsiusAdapter : ITempData
    {
        private TempDataFahrenheit _tempDataFahrenheit;
        public FahrenheitToCelsiusAdapter(TempDataFahrenheit tempDataFahrenheit)
        {
            _tempDataFahrenheit = tempDataFahrenheit;
        }

        public float GetTemp1()
        {
           return (_tempDataFahrenheit.GetTemp1() - 32) *5 / 9;
        }

        public float GetTemp2()
        {
            return (_tempDataFahrenheit.GetTemp2() - 32) * 5 / 9;
        }

       
    }
}
