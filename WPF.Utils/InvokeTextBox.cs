using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils
{
    public static class InvokeTextBox
    {
        private static void ClearWork(TextBox item)
        {
            item.Clear();
        }

        public static void Clear(TextBox item)
        {
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    ClearWork(item);

                });
            else
                ClearWork(item);
        }

        private static void SetTextWork(TextBox item, string text)
        {
            item.Text = text;
        }

        public static void SetText(TextBox item, string text)
        {
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetTextWork(item, text);
                });
            else
                SetTextWork(item, text);
        }

        private static string GetTextWork(TextBox item)
        {
            return item.Text;
        }

        public static string GetText(TextBox item)
        {
            var result = string.Empty;
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    result = GetTextWork(item);
                });
            else
                result = GetTextWork(item);
            return result;
        }

        private static void AddTextWork(TextBox item, string text)
        {
            item.Text += text + Environment.NewLine;
        }

        public static void AddText(TextBox item, string text)
        {
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    AddTextWork(item, text);
                });
            else
                AddTextWork(item, text);
        }

        private static void AddTextFormatWork(TextBox item, System.Diagnostics.Stopwatch sw, string text)
        {
            item.Text += $@"[{sw.Elapsed}] {text}" + Environment.NewLine;
        }

        public static void AddTextFormat(TextBox item, System.Diagnostics.Stopwatch sw, string text)
        {
            if (!item.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    AddTextFormatWork(item, sw, text);
                });
            else
                AddTextFormatWork(item, sw, text);
        }
    }
}
