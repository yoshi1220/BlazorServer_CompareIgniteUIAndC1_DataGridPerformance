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
        // IgbGrid �� BodyTemplate ���g�p����ꍇ�ɁABlazor Server �� SignalR �ʐM�T�C�Y��
        // ����̏���l�𒴂���ꍇ������̂ŁA�ʐM�T�C�Y������ɘa
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
