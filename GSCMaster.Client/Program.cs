using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GSCMaster.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services
    .AddGSCMasterClient()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7000/graphql");
    });

await builder.Build().RunAsync();