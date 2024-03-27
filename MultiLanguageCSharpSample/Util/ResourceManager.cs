using CommunityToolkit.Mvvm.ComponentModel;
using MultiLanguageCSharpSample.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace MultiLanguageCSharpSample.Util;

public partial class ResourceManager : ObservableObject
{
    private static ResourceManager? _singleton;
    public static ResourceManager Singleton => _singleton ??= new();

    public Resources Resources { get; } = new();

    private ResourceManager() { }

    public static void ChangeCulture(CultureInfo cultureInfo)
    {
        if (Resources.Culture != cultureInfo)
        {
            Resources.Culture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Singleton.OnPropertyChanged(nameof(Resources));
        }
    }
}
