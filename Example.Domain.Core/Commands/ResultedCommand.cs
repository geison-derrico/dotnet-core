using System;
using Example.Domain.Core.Events;
using FluentValidation.Results;

namespace Example.Domain.Core.Commands
{
    public abstract class ResultedCommand<T> : ResultedMessage<T>
    {
        public ResultedCommand()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}