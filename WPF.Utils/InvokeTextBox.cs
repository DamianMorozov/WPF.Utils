using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
// ReSharper disable UnusedMember.Global

namespace WPF.Utils
{
    public static class InvokeTextBox
    {
        public static void Clear(TextBox control)
        {
            void Work(TextBox inControl)
            {
                inControl.Clear();
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control);
                    }));
            else
                Work(control);
        }

        public static void SetText(TextBox control, string text)
        {
            void Work(TextBox inControl, string inText)
            {
                inControl.Text = inText;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
            else
                Work(control, text);
        }

        public static string GetText(TextBox control)
        {
            var result = string.Empty;
            string Work(TextBox inControl)
            {
                return inControl.Text;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        result = Work(control);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        result = Work(control);
                    }));
            else
                result = Work(control);
            return result;
        }

        public static void AddText(TextBox control, string text)
        {
            void Work(TextBox inControl, string inText)
            {
                inControl.Text += inText + Environment.NewLine;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
            else
                Work(control, text);
        }

        public static void AddTextFormat(TextBox control, Stopwatch sw, string text)
        {
            void Work(TextBox inControl, Stopwatch inSw, string inText)
            {
                inControl.Text += $@"[{inSw.Elapsed}] {inText}" + Environment.NewLine;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, sw, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, sw, text);
                    }));
            else
                Work(control, sw, text);
        }
    }
}
