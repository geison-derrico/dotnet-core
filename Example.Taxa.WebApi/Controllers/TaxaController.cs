using Example.Application.Interfaces;
using Example.Application.ViewModels;
using Example.Application.ViewModels.Taxa;
using Example.Domain.Core.Bus.Normalize;
using Example.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Taxa.WebApi.Controllers
{
    public class TaxaController : ApiControllerBase
    {
        private readonly ITaxaService _taxaService;

        public TaxaController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandlerNormalize mediator, 
            ITaxaService taxaService) : base(notifications, mediator)
        {
            _taxaService = taxaService;
        }

        [HttpGet("taxaJuros")]
        [ProducesResponseType(200, Type = typeof(ResultViewModel<TaxaViewModel>))]
        public IActionResult TaxaJuros()
        {
            return Response(_taxaService.GetTaxaJuros());
        }
    }
}