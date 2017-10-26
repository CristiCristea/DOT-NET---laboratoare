namespace CrossCuttingConcerns
{
    public class France : IVATStrategy
    {
        public int GetVatByCountryCode()
        {
            return 20;
        }
    }
}