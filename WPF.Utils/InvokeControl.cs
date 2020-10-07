using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF.Utils
{
    public static class InvokeControl
    {
        private static void SetVisibilityWork(Control control, Visibility value)
        {
            control.Visibility = value;
        }

        public static void SetVisibility(Control control, Visibility value)
        {
            if (!control.CheckAccess())
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetVisibilityWork(control, value);
                });
            else
                SetVisibilityWork(control, value);
        }

        private static void SetIsEnabledWork(Control control, bool value)
        {
            control.IsEnabled = value;
        }

        public static void SetIsEnabled(Control control, bool value)
        {
            if (!control.CheckAccess())
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetIsEnabledWork(control, value);
                });
            else
                SetIsEnabledWork(control, value);
        }

        private static void SetBackgroundWork(Control control, System.Windows.Media.Brush value)
        {
            control.Background = value;
        }

        public static void SetBackground(Control control, System.Windows.Media.Brush value)
        {
            if (!control.CheckAccess())
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetBackgroundWork(control, value);
                });
            else
                SetBackgroundWork(control, value);
        }

        private static void SetForegroundWork(Control control, System.Windows.Media.Brush value)
        {
            control.Foreground = value;
        }

        public static void SetForeground(Control control, System.Windows.Media.Brush value)
        {
            if (!control.CheckAccess())
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    SetForegroundWork(control, value);
                });
            else
                SetForegroundWork(control, value);
        }

        private static void FocusWork(Control control)
        {
            control.Focus();
        }

        public static void Focus(Control control)
        {
            if (!control.CheckAccess())
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
                {
                    FocusWork(control);
                });
            else
                FocusWork(control);
        }
    }
}
