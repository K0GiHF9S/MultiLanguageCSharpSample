using Kamishibai;
using MultiLanguageCSharpSample.Util;
using Reactive.Bindings.Extensions;

namespace MultiLanguageCSharpSample.ViewModel;

[Navigate]
class FirstViewModel(string message) : DisposableBase
{
    public string Message { get; } = message;
}
