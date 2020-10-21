using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils
{
    public static class InvokeWebBrowser
    {
        public static void SetSource(WebBrowser browser, Uri uri)
        {
            if (browser is null)
                return;
            void Work(WebBrowser inBrowser, Uri inUri)
            {
                inBrowser.Source = inUri;
            }
            if (!browser.CheckAccess())
                if (!(System.Windows.Application.Current is null))
                    System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(browser, uri);
                    }));
                else
                    browser.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(browser, uri);
                    }));
            else
                Work(browser, uri);
        }
    }
}