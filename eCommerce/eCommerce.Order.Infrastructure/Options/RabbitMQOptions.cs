﻿namespace eCommerce.Order.Infrastructure.Options
{
    public class RabbitMQOptions
    {
        public const string Key = "RabbitMQ";
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
    }
}
