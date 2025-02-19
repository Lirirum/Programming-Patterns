namespace Abstract_Factory
{
    public interface IMagicStuff
    {
        public void DoMagic(float damage, float radius);
    }

    public class FireMagicStuff : IMagicStuff
    {
        private float damageMultiplier = 0.25f;
        public void DoMagic(float damage, float radius)
        {
            Console.WriteLine($"Fire magic does {damage} damage in a {radius} radius");
            Console.WriteLine($"All targets in radius of {radius} is rigged. Fire does {damage * damageMultiplier} extra fire damage to every target");
        }
    }

    public class IceMagicStuff : IMagicStuff
    {
        private float slowdownMultiplier = 0.25f;
        public void DoMagic(float damage, float radius)
        {
            Console.WriteLine($"Ice magic does {damage} damage in a {radius} radius");
            Console.WriteLine($"All targets in radius of {radius} is frozen. All targets are slowed by 25% for {slowdownMultiplier * damage} seconds");
        }
    }
}
