using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
// ReSharper disable UnusedMember.Global

namespace WPF.Utils
{
    public static class InvokeControl
    {
        public static void SetVisibility(Control control, Visibility value)
        {
            void Work(Control inControl, Visibility inValue)
            {
                inControl.Visibility = inValue;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
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

        public static void SetIsEnabled(Control control, bool value)
        {
            void Work(Control inControl, bool inValue)
            {
                inControl.IsEnabled = inValue;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
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

        public static void SetBackground(Control control, Brush value)
        {
            void Work(Control inControl, Brush inValue)
            {
                inControl.Background = inValue;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
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

        public static void SetForeground(Control control, Brush value)
        {
            void Work(Control inControl, Brush inValue)
            {
                inControl.Foreground = inValue;
            }
            if (!(control is null) && !control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
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

        public static void Focus(Control control)
        {
            void Work(Control inControl)
            {
                inControl.Focus();
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
    }
}
