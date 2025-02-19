using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class WeaponService
    {
        private IWeaponFactory weaponFactory;
        private ISword sword;
        private IMagicStuff magicStuff;

        public WeaponService(IWeaponFactory weaponFactory)
        {
            this.weaponFactory = weaponFactory;
        }
        public void CreateSword()
        {
           this.sword = weaponFactory.CreateSword();
            Console.WriteLine("Sword is created");

        }

        public void CreateMagicStuff()
        {
            this.magicStuff = weaponFactory.CreateMagicStuff();
            Console.WriteLine("Magic stuff is created");
        }

        public void HitWithSword(float damage)        {
            if (sword == null)
            {
                throw new Exception("Sword is not created");
            }
            sword.Hit(damage);
        }

        public void UseMagicStuff(float damage, float radius)        {
            if(magicStuff == null)
            {
                throw new Exception("Magic stuff is not created");
            }

            magicStuff.DoMagic(damage, radius);
        }
    }
}
