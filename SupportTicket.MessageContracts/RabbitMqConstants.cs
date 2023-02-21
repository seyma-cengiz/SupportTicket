namespace SupportTicket.MessageContracts
{
    public static class RabbitMqConstants
    {
        public static string Host => "rabbitmq://localhost/supportticket/";
        public static string Username => "guest";
        public static string Password => "guest";
        public static string RegistrationServiceQueue => "registration.service";
        public static string NotificationServiceQueue => "notification.service";
    }
}
