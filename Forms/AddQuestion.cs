using System;
using System.Windows.Forms;
using SeaBattle.Core;
using SeaBattle.Data;
using SeaBattle.Models;

namespace SeaBattle.Forms;

public partial class AddQuestion : Form
{
    public AddQuestion()
    {
        InitializeComponent();
    }

    private void ButtonAction_Click(object sender, EventArgs e)
    {
        if (textBox1.Text.Length < 1)
        {
            MessageBoxFramework.DisplayError("Введите вопрос!");
        }
        else if (textBox2.Text.Length < 1)
        {
            MessageBoxFramework.DisplayError("Введите ответ!");
        }
        else if (numericUpDown1.Value < 1)
        {
            MessageBoxFramework.DisplayError("Укажите положительное значение очков за вопрос");
        }
        else
        {
            var questions = QuestionProcessor.GetQuestions();

            questions.Add(new Question
            {
                Name = textBox1.Text.Trim(), Answer = textBox2.Text.Trim(),
                Score = (int) numericUpDown1.Value
            });

            QuestionProcessor.SaveQuestions(questions);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
