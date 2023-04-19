using System;
using System.Linq;
using System.Windows.Forms;
using SeaBattle.Core;
using SeaBattle.Data;
using SeaBattle.Models;

namespace SeaBattle.Forms;

public partial class ChangeQuestion : Form
{
    private readonly Question _question;

    public ChangeQuestion(Question question)
    {
        InitializeComponent();
        _question = question;
        textBox1.Text = question.Name;
        textBox2.Text = question.Answer;
        numericUpDown1.Value = question.Score;
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

            foreach (var quest in questions.Where(x => x.Name == _question.Name
                                                       && x.Answer == _question.Answer
                                                       && x.Score == _question.Score))
            {
                quest.Name = textBox1.Text.Trim();
                quest.Answer = textBox2.Text.Trim();
                quest.Score = (int) numericUpDown1.Value;
                break;
            }

            QuestionProcessor.SaveQuestions(questions);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
