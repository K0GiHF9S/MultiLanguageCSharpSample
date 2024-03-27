using MultiLanguageCSharpSample.Properties;
using MultiLanguageCSharpSample.Util;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xaml;

namespace MultiLanguageCSharpSample.Markup;

public class ResourceBindingExtension(BindingBase? binding) : MarkupExtension
{
    [ConstructorArgument("binding")]
    public BindingBase? Binding { get; set; } = binding;

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        if (Binding is null)
        {
            return null;
        }

        if (Binding.ProvideValue(serviceProvider) is not BindingExpressionBase expression)
        {
            return this;
        }

        var reference = new WeakReference<BindingExpressionBase>(expression);
        void handler(object? o, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ResourceManager.Singleton.Resources))
            {
                if (reference.TryGetTarget(out var target))
                {
                    target.UpdateTarget();
                }
                else
                {
                    ResourceManager.Singleton.PropertyChanged -= handler;
                }
            }
        }

        ResourceManager.Singleton.PropertyChanged += handler;
        return expression;

    }
}
