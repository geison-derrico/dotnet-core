namespace Example.Application.ViewModels
{
    public class ResultViewModel
    {
        public object Data { get; set; }
        public bool Success { get; set; } = true;
    }

    public class ResultViewModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
    }
}