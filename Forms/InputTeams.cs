using SeaBattle.Core;
using SeaBattle.Data;
using System;
using System.Windows.Forms;

namespace SeaBattle.Forms
{
    public partial class InputTeams : Form
    {
        public InputTeams()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBoxFramework.DisplayError("Введите названия команд");
                return;
            }

            if (textBox1.Text.Length > 20 || textBox2.Text.Length > 20)
            {
                MessageBoxFramework.DisplayError("Название команды не должно превышать 20 символов");
                return;
            }

            if (textBox1.Text == textBox2.Text)
            {
                MessageBoxFramework.DisplayError("Названия команд не должны совпадать");
                return;
            }

            TeamData.SetTeams(textBox1.Text, textBox2.Text);

            MessageBoxFramework.DisplayInfo("Команды сохранены");
            Close();
        }
    }
}
