internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        builder.AddProject<Projects.MangaPlanetto_Cms_Api>("cms");

        builder.Build().Run();
    }
}