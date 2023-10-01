namespace HA.Helpers
{
    public class PageDing
    {
        public int currentPage{set;get;}
        public int coutPage{set;get;}
        public Func<int?,string>genarateUrl{set;get;}
    }
}