using Shared.Commands;

namespace Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message, Object result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Object Result { get; set; }
    }
}
