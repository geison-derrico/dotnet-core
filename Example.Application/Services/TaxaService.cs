using Example.Application.Interfaces;
using Example.Application.ViewModels.Taxa;

namespace Example.Application.Services
{
    public class TaxaService : ITaxaService
    {
        public TaxaViewModel GetTaxaJuros()
        {
            TaxaViewModel taxa = new TaxaViewModel();
            taxa.TaxaJuros = 0.01M;

            return taxa;
        }
    }
}
