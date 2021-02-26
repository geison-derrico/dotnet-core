using Example.Application.ViewModels.Calculo;

namespace Example.Application.Interfaces
{
    public interface ICalculoService
    {
        CalculoViewModel GetCalculoJuros(decimal valorInicial, int meses);

        SourceCodeViewModel GetSourceCodeUrl();
    }
}
