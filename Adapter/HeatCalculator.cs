using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class HeatCalculator
    {
        
        float c;
        float m;
        public HeatCalculator( float c, float m) {      
            this.c = c;
            this.m = m;
        }


    public float CalculateHeat(ITempData tempData) { 
            float result = (tempData.GetTemp2()- tempData.GetTemp1()) * c * m;
            Console.WriteLine($"Для нагрівання матеріалу з температури {tempData.GetTemp1()} до {tempData.GetTemp2()} було  витрачено {result} Дж енергії");
            return result;
        }
    }

    
}
