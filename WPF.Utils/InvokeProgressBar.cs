using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils
{
    public static class InvokeProgressBar
    {
        private static void SetValueWork(ProgressBar control, int value)
        {
            control.Value = value;
        }

        public static void SetValue(ProgressBar control, int value)
        {
            if (!control.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetValueWork(control, value);
                });
            else
                SetValueWork(control, value);
        }

        private static void SetMinimumWork(ProgressBar control, int value)
        {
            control.Minimum = value;
        }

        public static void SetMinimum(ProgressBar control, int value)
        {
            if (!control.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetMinimumWork(control, value);
                });
            else
                SetMinimumWork(control, value);
        }

        private static void SetMaximumWork(ProgressBar control, int value)
        {
            control.Maximum = value;
        }

        public static void SetMaximum(ProgressBar control, int value)
        {
            if (!control.CheckAccess())
                System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetMaximumWork(control, value);
                });
            else
                SetMaximumWork(control, value);
        }
    }
}
