using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.Hospital.View.Secretary.Commands
{
    public static class RoutedCommand
    {
        public static readonly RoutedUICommand Back = new RoutedUICommand("Back", "BackButton", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.B, ModifierKeys.Control)
        });
    }
}
