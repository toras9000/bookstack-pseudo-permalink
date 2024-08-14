#r "nuget: Lestaly, 0.67.0"
#r "nuget: Kokuban, 0.2.0"
#nullable enable
using System.Threading;
using Kokuban;
using Lestaly;
using Lestaly.Cx;

await Paved.RunAsync(async () =>
{
    var composeFile = ThisSource.RelativeFile("./docker/compose.yml");

    WriteLine(Chalk.Green["Pseudo-Permalink by Theme System"]);
    WriteLine($"""
      It uses a logical/visual theme system and redirection to achieve pseudo permalinks to each entity.
      Display the Permalink in the detailed information area of the entity.
      This is not a very efficient operation because of the redirection method.
    """);
    WriteLine();

    WriteLine(Chalk.Green["Restart containers."]);
    await "docker".args("compose", "--file", composeFile.FullName, "down", "--remove-orphans", "--volumes");
    await "docker".args("compose", "--file", composeFile.FullName, "up", "-d", "--wait").result().success();
    WriteLine();

    WriteLine("Container up completed.");
    var pubPort = await "docker".args("compose", "--file", composeFile.FullName, "port", "app", "80").silent().result().success().output();
    var portNum = pubPort.AsSpan().SkipToken(':').TryParseNumber<ushort>();
    var service = new Uri($"http://localhost:{portNum}");

    await CmdShell.ExecAsync(service.AbsoluteUri);
});
