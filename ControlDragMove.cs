using System.Drawing;

namespace System.Windows.Forms
{
    public static class ControlDragMove
    {
        private static Point _mouseLocation;

        public static void DragMove(this Control control)
        {
            control.MouseDown += Control_MouseDown;
            control.MouseMove += Control_MouseMove;
        }

        private static void Control_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(e.X, e.Y);
        }

        private static void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Form form = (Form)control.TopLevelControl;
                form.Location = new Point(form.Location.X + (e.X - _mouseLocation.X), form.Location.Y + (e.Y - _mouseLocation.Y));
            }
        }
    }
}