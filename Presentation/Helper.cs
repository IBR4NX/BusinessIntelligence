using Domain;
using System.Data;

namespace Presentation
{
    internal static class Helper
    {
        public static void Show(string message, string caption = "Business Intelligence", MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.OK,
                icon);
        }

    }
}
