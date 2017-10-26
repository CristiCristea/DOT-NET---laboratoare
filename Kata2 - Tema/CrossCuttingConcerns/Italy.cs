namespace CrossCuttingConcerns
{
    public class Italy : IVATStrategy
    {
        public int GetVatByCountryCode()
        {
            return 22;
        }
    }
}