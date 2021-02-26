using Example.Application.Interfaces;
using Example.Application.ViewModels;
using Example.Application.ViewModels.Calculo;
using Example.Domain.Core.Bus.Normalize;
using Example.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Calculo.WebApi.Controllers
{
    [Route("calculajuros")]
    public class CalculoController : ApiControllerBase
    {
        private readonly ICalculoService _calculoService;

        public CalculoController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandlerNormalize mediator, 
            ICalculoService calculoService) : base(notifications, mediator)
        {
            _calculoService = calculoService;
        }

        [HttpGet("{valorinicial:decimal}/{meses:int}")]
        [ProducesResponseType(200, Type = typeof(ResultViewModel<CalculoViewModel>))]
        [ProducesResponseType(400, Type = typeof(ErrorViewModel))]
        public IActionResult CalculoJuros(decimal valorinicial, int meses)
        {
            return Response(_calculoService.GetCalculoJuros(valorinicial, meses));
        }
    }
}