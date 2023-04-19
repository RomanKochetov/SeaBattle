using System.Windows.Forms;

namespace SeaBattle.Core;

public static class MessageBoxFramework
{
    private const string Name = "Морской бой";

    public static void DisplayInfo(string message)
    {
        MessageBox.Show(message, Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void DisplayError(string message)
    {
        MessageBox.Show(message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
