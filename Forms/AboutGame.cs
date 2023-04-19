using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SeaBattle.Extensions;

namespace SeaBattle.Forms;

internal partial class AboutGame : Form
{
    private readonly List<Color> _buttonColors = new()
        {Color.Brown, Color.Black, Color.White, Color.Blue, Color.Yellow, Color.Red, Color.Pink, Color.DeepPink};

    private readonly List<Color> _labelColors = new()
        {Color.White, Color.White, Color.Black, Color.White, Color.Black, Color.White, Color.White, Color.Black};

    private int _lastIndex;

    public AboutGame()
    {
        InitializeComponent();

        label1.Dock = DockStyle.Top;
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        version.Text = $"Версия: {Assembly.GetExecutingAssembly().GetName().Version}";
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var psInfo = new ProcessStartInfo
        {
            FileName = "https://rkochetov.com",
            UseShellExecute = true
        };
        Process.Start(psInfo);
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void closeButton_Hover(object sender, EventArgs e)
    {
        var button = (Button) sender;

        var randomBackgroundColor = _buttonColors.GetRandom();

        var index = _buttonColors.IndexOf(randomBackgroundColor);

        while (index == _lastIndex)
        {
            randomBackgroundColor = _buttonColors.GetRandom();

            index = _buttonColors.IndexOf(randomBackgroundColor);
        }

        var randomTextColor = _labelColors[index];

        button.BackColor = randomBackgroundColor;
        button.ForeColor = randomTextColor;

        _lastIndex = index;
    }
}
