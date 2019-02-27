using StructureMap;

namespace Learning.ConsoleApplications.Configuration
{
    public static class StructureMapConfiguration
    {
        public static void RegiterDependencies()
        {
            new Container().Configure(config =>
            {
                config.AddRegistry(new ServiceRegistry());
                config.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
            });
        }
    }

    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            //Todo: Add depedency registration here
        }
    }
}
