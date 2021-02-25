using Example.Application.Interfaces;
using Example.Application.ViewModels;
using Example.Application.ViewModels.Calculo;
using Example.Domain.Core.Bus.Normalize;
using Example.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Example.Calculo.WebApi.Controllers
{
    public class SourceCodeController : ApiControllerBase
    {
        private readonly ICalculoService _calculoService;

        public SourceCodeController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandlerNormalize mediator,
            ICalculoService calculoService) : base(notifications, mediator)
        {
            _calculoService = calculoService;
        }

        [HttpGet("/showmethecode")]
        [ProducesResponseType(200, Type = typeof(ResultViewModel<SourceCodeViewModel>))]
        public IActionResult GetSourceCode()
        {
            return Response(_calculoService.GetSourceCodeUrl());
        }
    }
}
