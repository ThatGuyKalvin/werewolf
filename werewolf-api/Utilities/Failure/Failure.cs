namespace werewolf_api.Utilities.Failure
{
    public class Failure
    {
        public Failure(FailureCodeEnum code, string message, object? detail) {
            Code = code;
            Message = message;
            Detail = detail;
        }

        public Failure(FailureCodeEnum code, string message)
        {
            Code = code;
            Message = message;
        }



        public FailureCodeEnum Code { get; }
        public string Message { get; }
        public object? Detail { get; }

    }
}
