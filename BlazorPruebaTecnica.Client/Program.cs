using BlazorPruebaTecnica.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPruebaTecnica.Client.services.Client;
using BlazorPruebaTecnica.Client.services.Invoice;
using BlazorPruebaTecnica.Client.services.Products;
using BlazorPruebaTecnica.Client.services.InvoiceDetail;
using CurrieTechnologies.Razor.SweetAlert2;
using BlazorPruebaTecnica.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7212") });

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
builder.Services.AddScoped<IinvoiceService, InvoiceService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();