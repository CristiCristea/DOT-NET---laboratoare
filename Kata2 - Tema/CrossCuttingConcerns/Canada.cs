namespace CrossCuttingConcerns
{
    public class Canada : IVATStrategy
    {
        public int GetVatByCountryCode()
        {
            return 5;
        }
    }
}