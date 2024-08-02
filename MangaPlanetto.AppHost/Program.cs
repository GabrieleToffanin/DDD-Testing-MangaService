internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var rabbitMq = builder.AddRabbitMQ("rabbitmq")
                              .WithManagementPlugin();

        builder.AddProject<Projects.MangaPlanetto_Cms_Api>("cms")
               .WithReference(rabbitMq);

        builder.Build().Run();
    }
}