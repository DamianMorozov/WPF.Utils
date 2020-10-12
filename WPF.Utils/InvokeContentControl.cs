using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils
{
    public static class InvokeContentControl
    {

        public static void SetContent(ContentControl control, string value)
        {
            if (control is null)
                return;
            void Work(ContentControl inControl, string inValue)
            {
                inControl.Content = inValue;
            }
            if (!control.CheckAccess())
                if (!(System.Windows.Application.Current is null))
                    System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, value);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, value);
                    }));
            else
                Work(control, value);
        }


        public static void AddContent(ContentControl control, string value)
        {
            if (control is null)
                return;
            void Work(ContentControl inControl, string inValue)
            {
                inControl.Content += inValue + Environment.NewLine;
            }
            if (!control.CheckAccess())
                if (!(System.Windows.Application.Current is null))
                    System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, value);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, value);
                    }));
            else
                Work(control, value);
        }
    }
}