using Example.Application.AutoMapper;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Test.Application.Mapper
{
    [TestClass]
    public class AutoMapperTest
    {
        /// <summary>
        /// Testa os mapamentos de uma maneira geral
        /// </summary>
        [TestMethod]
        public void MapeamentosSaoValidos()
        {
            AutoMapper.Mapper.Reset();

            MapperConfiguration config = AutoMapperConfig.RegisterMappings();
            config.AssertConfigurationIsValid();
        }
    }
}