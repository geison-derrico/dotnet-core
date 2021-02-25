using System.Collections.Generic;

namespace Example.Application.ViewModels
{
    public class ErrorViewModel
    {
        public bool Success { get; set; } = false;
        public IEnumerable<string> Errors { get; set; } = new HashSet<string>();
    }
}