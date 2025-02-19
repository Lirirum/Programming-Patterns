namespace Adapter
{   

    public interface ITempData
    {
        public float GetTemp1();
        public float GetTemp2();
    }

    public class TempDataCelsius : ITempData
    {
        private float t1;
        private float t2;

        public TempDataCelsius(float t1, float t2)
        {
            this.t1 = t1;
            this.t2 = t2;
        }

        public float GetTemp1()
        {
            return t1;
        }

        public float GetTemp2()
        {
            return t2;
        }
    }

    public class TempDataFahrenheit
    {
        private float t1;
        private float t2;

        public TempDataFahrenheit(float t1, float t2)
        {
            this.t1 = t1;
            this.t2 = t2;
        }
        public float GetTemp1() {
            return t1;
        }
        public float GetTemp2()
        {
            return t2;
        }
    }
}
