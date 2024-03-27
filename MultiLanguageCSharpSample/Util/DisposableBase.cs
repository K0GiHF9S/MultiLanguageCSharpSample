using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace MultiLanguageCSharpSample.Util;

public class DisposableBase : IDisposable
{
    protected CompositeDisposable Disposable { get; } = [];

    void IDisposable.Dispose() => Disposable.Dispose();
}
