using CommandLine;

namespace Learning.ConsoleApplications.Models
{
    internal class Options
    {
        [Option('m', "mode", Required = true,
            HelpText = "Options to be executed: (cg)ConsoleGames")]
        public string Mode { get; set; }
    }
}
