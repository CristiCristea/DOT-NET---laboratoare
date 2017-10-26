namespace CrossCuttingConcerns
{
    public class Romania : IVATStrategy
    {
        public int GetVatByCountryCode()
        {
            return 24;
        }
    }
}