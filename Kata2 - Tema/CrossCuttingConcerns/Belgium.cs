namespace CrossCuttingConcerns
{
    public class Belgium : IVATStrategy
    {
        public int GetVatByCountryCode()
        {
            return 21;
        }
    }
}