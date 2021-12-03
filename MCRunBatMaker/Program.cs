Console.WriteLine("Hello, World!");

Console.WriteLine("Enter local path to starup jar");

string? path = Console.ReadLine();

Console.WriteLine("Enter min ram in GB");

string? min = Console.ReadLine();

Console.WriteLine("Enter max ram in GB");

string? max = Console.ReadLine();

Console.WriteLine("Enter Template Default or Paper, (1 or 2)");

string? template = Console.ReadLine();
if (template == "1")
{
    string data = $"java -Xmx{max}G -Xms{min}G -jar {path} nogui\nPAUSE";
    File.WriteAllText(Directory.GetCurrentDirectory() + @"\run.bat", data);
}
else if (template == "2")
{
    string data = $"java -Xms{min}G -Xmx{max}G -XX:+UseG1GC -XX:+ParallelRefProcEnabled -XX:MaxGCPauseMillis=200 -XX:+UnlockExperimentalVMOptions -XX:+DisableExplicitGC -XX:+AlwaysPreTouch -XX:G1NewSizePercent=30 -XX:G1MaxNewSizePercent=40 -XX:G1HeapRegionSize=8M -XX:G1ReservePercent=20 -XX:G1HeapWastePercent=5 -XX:G1MixedGCCountTarget=4 -XX:InitiatingHeapOccupancyPercent=15 -XX:G1MixedGCLiveThresholdPercent=90 -XX:G1RSetUpdatingPauseTimePercent=5 -XX:SurvivorRatio=32 -XX:+PerfDisableSharedMem -XX:MaxTenuringThreshold=1 -Dusing.aikars.flags=https://mcflags.emc.gs -Daikars.new.flags=true -jar {path} nogui\nPAUSE";
    File.WriteAllText(Directory.GetCurrentDirectory() + @"\run.bat", data);
}
else
{
    Console.WriteLine("Unknown.");
}

Console.WriteLine("Any key to close");
Console.ReadKey();