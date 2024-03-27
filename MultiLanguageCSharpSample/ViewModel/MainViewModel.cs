using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using MultiLanguageCSharpSample.Util;
using Kamishibai;
using System.Reactive.Linq;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MultiLanguageCSharpSample.ViewModel;

public class MainViewModel : DisposableBase
{
    private readonly IPresentationService _presentationService;

    public AsyncReactiveCommand NavigateCommand { get; }
    public AsyncReactiveCommand CancelCommand { get; }

    public ReactivePropertySlim<DateOnly> Number { get; } = new(DateOnly.FromDateTime(DateTime.Now));

    public ReactiveCommand DefaultCommand { get; }
    public ReactiveCommand ChangeCommand { get; }


    public MainViewModel(IPresentationService presentationService)
    {
        _presentationService = presentationService;
        NavigateCommand = new AsyncReactiveCommand()
            .WithSubscribe(() => _presentationService.NavigateToFirstAsync("Hello, Navigation Parameter!"))
            .AddTo(Disposable);

        CancelCommand = new AsyncReactiveCommand()
            .WithSubscribe(async () =>
            {
                _presentationService.DisposeCurrentDataContext();
                await _presentationService.NavigateToDummyAsync();
            })
            .AddTo(Disposable);

        DefaultCommand = new ReactiveCommand()
            .WithSubscribe(() => ResourceManager.ChangeCulture(CultureInfo.GetCultureInfo("en")))
            .AddTo(Disposable);

        ChangeCommand = new ReactiveCommand()
            .WithSubscribe(() => ResourceManager.ChangeCulture(CultureInfo.GetCultureInfo("ja")))
            .AddTo(Disposable);
    }
}