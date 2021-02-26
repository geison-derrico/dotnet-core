using Example.Application.Interfaces;
using Example.Application.ViewModels.Calculo;
using System;

namespace Example.Application.Services
{
    public class CalculoService : ICalculoService
    {
        private readonly ITaxaService _taxaService;

        public CalculoService(ITaxaService taxa)
        {
            _taxaService = taxa;
        }

        public CalculoViewModel GetCalculoJuros(decimal valorInicial, int meses)
        {
            CalculoViewModel calculo = new CalculoViewModel();

            decimal taxaJuros = _taxaService.GetTaxaJuros().TaxaJuros;
            calculo.ValorFinal = Truncar(valorInicial * CalcularTaxaJuros_periodoTempo(1 + taxaJuros, meses));
            calculo.JurosCalculado = Truncar(calculo.ValorFinal - valorInicial);
            calculo.ValorFinal = Truncar(calculo.ValorFinal);

            return calculo;
        }

        public SourceCodeViewModel GetSourceCodeUrl()
        {
            SourceCodeViewModel url = new SourceCodeViewModel();
            url.GitHubUrl = "https://github.com/geison-derrico/dotnet-core";

            return url;
        }

        private decimal CalcularTaxaJuros_periodoTempo(decimal valorParaCalculo, int tempo)
        {
            decimal valorTotal = valorParaCalculo;
            for (int i = 1; i < tempo; i++)
            {
                valorTotal *= valorParaCalculo;
            }
            return valorTotal;
        }

        private decimal Truncar(decimal valor)
        {
            return Math.Truncate(100 * valor) / 100;
        }
    }
}
