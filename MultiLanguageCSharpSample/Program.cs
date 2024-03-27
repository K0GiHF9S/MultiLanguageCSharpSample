using MultiLanguageCSharpSample.View;
using MultiLanguageCSharpSample;
using Kamishibai;
using Microsoft.Extensions.Hosting;
using MultiLanguageCSharpSample.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using MultiLanguageCSharpSample.Util;
using System.Globalization;

ResourceManager.ChangeCulture(CultureInfo.CurrentCulture);

var builder = KamishibaiApplication<App, MainWindow>.CreateBuilder();

builder.Services
    .AddPresentation<MainWindow, MainViewModel>()
    .AddPresentation<FirstPage, FirstViewModel>()
    .AddPresentation<DummyPage, DummyViewModel>();

var app = builder.Build();
await app.RunAsync();