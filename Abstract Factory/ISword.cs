using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public interface ISword
    {
        public void Hit(float damage);
    }

    public class FireSword : ISword
    {
        private float damageMultiplier = 0.25f;

        public void Hit(float damage)
        {
            Console.WriteLine($"Fire sword hits for {damage} damage");
            Console.WriteLine($"Target is rigged. Fire does {damage * damageMultiplier} extra fire damage");
        }
    }

    public class IceSword : ISword
    {
        private float slowdownMultiplier = 0.25f;

        public void Hit(float damage)
        {
            Console.WriteLine($"Ice sword hits for {damage} damage");
            Console.WriteLine($"Target is frozen. Target is slowed by 25%  for {slowdownMultiplier * damage} seconds");
        }
    }
}
