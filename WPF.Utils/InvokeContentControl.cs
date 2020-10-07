using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils
{
    public static class InvokeContentControl
    {
        private static void SetContentWork(ContentControl item, string value)
        {
            item.Content = value;
        }

        public static void SetContent(ContentControl item, string value)
        {
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetContentWork(item, value);
                });
            else
                SetContentWork(item, value);
        }

        private static void AddContentWork(ContentControl item, string value)
        {
            item.Content += value + Environment.NewLine;
        }

        public static void AddContent(ContentControl item, string value)
        {
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    AddContentWork(item, value);
                });
            else
                AddContentWork(item, value);
        }
    }
}