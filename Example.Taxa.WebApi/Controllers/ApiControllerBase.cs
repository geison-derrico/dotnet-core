﻿using System.Collections.Generic;
using System.Linq;
using Example.Domain.Core.Bus.Normalize;
using Example.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Example.Taxa.WebApi.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediatorHandlerNormalize _mediator;
        private readonly DomainNotificationHandler _notifications;
        private IMediatorHandlerNormalize mediator;

        protected ApiControllerBase(INotificationHandler<DomainNotification> notifications,
            IMediatorHandlerNormalize mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected ApiControllerBase(IMediatorHandlerNormalize mediator)
        {
            this.mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            IEnumerable<ModelError> erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (ModelError erro in erros)
            {
                string erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors) NotifyError(result.ToString(), error.Description);
        }
    }
}
