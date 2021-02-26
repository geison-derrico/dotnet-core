using Example.Application.Interfaces;
using Example.Application.Services;
using Example.Application.ViewModels.Taxa;
using Example.Application.ViewModels.Calculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Test.Application.Services
{
    [TestClass]
    public class CalculoServiceTest
    {
        private ITaxaService _taxaService;
        private ICalculoService _calculoService;

        [TestMethod]
        public void CalculoService_CalcularJuros_RetornarValorComDuasCasasDecimais()
        {
            // Arrange
            CalculoViewModel calculo = new CalculoViewModel();
            calculo.JurosCalculado = 5.10M;
            calculo.ValorFinal = 105.10M;

            // Act
            _taxaService = new TaxaService();
            _calculoService = new CalculoService(_taxaService);

            decimal valorInicial = 100;
            int meses = 5;

            var resultadoAtual = _calculoService.GetCalculoJuros(valorInicial, meses);

            // Assert
            Assert.AreEqual(resultadoAtual.JurosCalculado, calculo.JurosCalculado);
            Assert.AreEqual(resultadoAtual.ValorFinal, calculo.ValorFinal);
        }
    }
}
