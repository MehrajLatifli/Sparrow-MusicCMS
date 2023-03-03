using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MusicCMS_Admin.Helpers
{
    public static class DisableCapsLockBehavior
    {
        public static readonly DependencyProperty IsCapsLockDisabledProperty =
        DependencyProperty.RegisterAttached("IsCapsLockDisabled", typeof(bool), typeof(DisableCapsLockBehavior), new PropertyMetadata(false, OnIsCapsLockDisabledChanged));

        public static bool GetIsCapsLockDisabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCapsLockDisabledProperty);
        }

        public static void SetIsCapsLockDisabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCapsLockDisabledProperty, value);
        }

        private static void OnIsCapsLockDisabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                if (obj is UIElement element)
                {
                    element.AddHandler(Keyboard.KeyDownEvent, new KeyEventHandler(HandleKeyDownEvent), true);
                }
            }
            else
            {
                if (obj is UIElement element)
                {
                    element.RemoveHandler(Keyboard.KeyDownEvent, new KeyEventHandler(HandleKeyDownEvent));
                }
            }
        }

        private static void HandleKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.CapsLock)
            {
                e.Handled = true;
            }
        }
    }

}
