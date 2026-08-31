using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Hello from {RuntimeInformation.OSDescription} on {RuntimeInformation.OSArchitecture}");

app.Run();
