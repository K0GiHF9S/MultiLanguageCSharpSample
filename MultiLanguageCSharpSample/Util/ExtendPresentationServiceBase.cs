using Kamishibai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLanguageCSharpSample.Util;

public static class ExtendPresentationServiceBase
{
    public static void DisposeCurrentDataContext(this IPresentationServiceBase presentationService)
    {
        var frame = presentationService.GetNavigationFrame();
        if (frame.Count != 0)
        {
            (frame.CurrentDataContext as IDisposable)?.Dispose();
        }
    }
}
