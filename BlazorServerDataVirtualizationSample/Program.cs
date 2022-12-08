using BlazorServerDataVirtualizationSample.Data;
using IgniteUI.Blazor.Controls;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        // IgbGrid で BodyTemplate を使用する場合に、Blazor Server の SignalR 通信サイズが
        // 既定の上限値を超える場合があるので、通信サイズ上限を緩和
        options.MaximumReceiveMessageSize = 102400000;
    });

builder.Services.AddSingleton<PersonalInformationService>();

//Ignite UI for Blazor
builder.Services.AddIgniteUIBlazor(
                typeof(IgbPropertyEditorPanelModule),
                typeof(IgbGridModule),
                typeof(IgbCalloutLayerModule),
                typeof(IgbNumberAbbreviatorModule),
                typeof(IgbLegendModule),
                typeof(IgbButtonModule),
                typeof(IgbInputModule)
           );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
