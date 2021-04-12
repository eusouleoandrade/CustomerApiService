namespace CustomerApiWithService.Application.Notifications
{
    public class Notification
    {
        // Properties
        public string Message { get; private set; }

        // Ctors
        public Notification(string message)
        {
            Message = message;
        }
    }
}
