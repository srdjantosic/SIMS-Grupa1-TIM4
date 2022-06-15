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
        public static readonly RoutedUICommand Back = new RoutedUICommand("back", "Back", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.B, ModifierKeys.Control)
        });

        public static readonly RoutedUICommand Right = new RoutedUICommand("right", "Right", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.R, ModifierKeys.Control)
        });

        public static readonly RoutedUICommand Left = new RoutedUICommand("left", "Left", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.L, ModifierKeys.Control)
        });
        public static readonly RoutedUICommand Up = new RoutedUICommand("up", "Up", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.U, ModifierKeys.Control)
        });
        public static readonly RoutedUICommand Down = new RoutedUICommand("down", "Down", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.D, ModifierKeys.Control)
        });
        public static readonly RoutedUICommand Select = new RoutedUICommand("select", "Select", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.S, ModifierKeys.Control)
        });
        public static readonly RoutedUICommand Delete = new RoutedUICommand("delete", "Delete", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.Delete, ModifierKeys.Control)
        });
        public static readonly RoutedUICommand Menu = new RoutedUICommand("menu", "Menu", typeof(RoutedCommand), new InputGestureCollection()
        {
            new KeyGesture(Key.M, ModifierKeys.Control)
        });
    }
}
