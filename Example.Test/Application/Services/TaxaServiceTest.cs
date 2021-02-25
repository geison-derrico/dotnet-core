using Example.Application.Interfaces;
using Example.Application.Services;
using Example.Application.ViewModels.Taxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Test.Application.Services
{
    [TestClass]
    public class TaxaServiceTest
    {
        private ITaxaService _service;

        [TestMethod]
        public void TaxaService_BuscarTaxaJuros_RetornarValorFixado()
        {
            //Arrange 
            TaxaViewModel taxa = new TaxaViewModel();
            taxa.TaxaJuros = 0.01M;

            //Act
            _service = new TaxaService();
            var resultadoAtual = _service.GetTaxaJuros();

            //Assert
            Assert.AreEqual(resultadoAtual.TaxaJuros, taxa.TaxaJuros);
        }

    }
}
