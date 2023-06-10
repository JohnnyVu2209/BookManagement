using BookManagement.UI.Blazor;
using BookManagement.UI.Blazor.Services;
using BookManagement.UI.Blazor.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7001/") });
builder.Services.AddScoped<IBookService, BookService>();

await builder.Build().RunAsync();
