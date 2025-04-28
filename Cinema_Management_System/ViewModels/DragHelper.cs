using System.Drawing;
using System.Windows.Forms;

namespace Cinema_Management_System.Views
{
    public static class DragHelper
    {
        private static bool dragging = false;
        private static Point dragCursorPoint;
        private static Point dragFormPoint;

        public static void EnableDrag(Form form, Control control)
        {
            control.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragging = true;
                    dragCursorPoint = Cursor.Position;
                    dragFormPoint = form.Location;
                }
            };

            control.MouseMove += (sender, e) =>
            {
                if (dragging)
                {
                    Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    form.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            };

            control.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragging = false;
                }
            };
        }
    }
}