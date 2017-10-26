namespace CrossCuttingConcerns
{
    public class CommonService
    {
        public int GetVatByCountryCode(Country countryCode)
        {
            VATContext vat = new VATContext();
            return vat.GetVatByCountryCode(countryCode);
        }

        public double GetVATValueFromPrice(Country countryCode, double price)
        {
            VATContext vat = new VATContext();
            return (vat.GetVatByCountryCode(countryCode) * price) / 100.0;
        }

        public double GetFinalPrice(Country countryCode, double price)
        {
            VATContext vat = new VATContext();
            return price + GetVATValueFromPrice(countryCode, price);
        }
    }
}
