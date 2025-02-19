
namespace Abstract_Factory
{
    public interface IWeaponFactory
    {
        public ISword CreateSword();
        public IMagicStuff CreateMagicStuff();
    }

    public class FireWeaponFactory : IWeaponFactory
    {
        public ISword CreateSword()
        {
            return new FireSword();
        }

        public IMagicStuff CreateMagicStuff()
        {
            return new FireMagicStuff();
        }
    }

    public class IceWeaponFactory : IWeaponFactory
    {
        public ISword CreateSword()
        {
            return new IceSword();
        }

        public IMagicStuff CreateMagicStuff()
        {
            return new IceMagicStuff();
        }
    }
}
