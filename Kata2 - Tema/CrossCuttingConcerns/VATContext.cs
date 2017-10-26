using System.Collections.Generic;

namespace CrossCuttingConcerns
{
    public class VATContext
    {
        private Dictionary<Country, IVATStrategy> vat = new Dictionary<Country, IVATStrategy>();

        public VATContext()
        {
            vat.Add(Country.BE, new Belgium());
            vat.Add(Country.FR, new France());
            vat.Add(Country.CA, new Canada());
            vat.Add(Country.IT,new Italy());
            vat.Add(Country.RO,new Romania());
        }

        public int GetVatByCountryCode(Country countryCode)
        {
            return vat[countryCode].GetVatByCountryCode();
        }
    }
}