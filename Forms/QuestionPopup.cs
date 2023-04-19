using System;
using System.Drawing;
using System.Windows.Forms;
using SeaBattle.Core;
using SeaBattle.Models;

namespace SeaBattle.Forms;

public partial class QuestionPopup : Form
{
    private readonly Question _question;

    public QuestionPopup(Question question)
    {
        DialogResult = DialogResult.No;
        InitializeComponent();
        _question = question;
        label1.TextAlign = ContentAlignment.MiddleCenter;
        label1.Text = _question.Name;
        label3.Text = string.Format("Вопрос на {0} баллов", question.Score);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var answer = textBox1.Text;
        if (answer.Length < 1)
        {
            MessageBoxFramework.DisplayError("Поле ответа не должно быть пустым");
            return;
        }

        var answerIsRight = answer.Trim().ToLower() == _question.Answer.Trim().ToLower();
        if (answerIsRight)
            MessageBoxFramework.DisplayInfo($"Правильный ответ: {_question.Answer}");
        else
            MessageBoxFramework.DisplayError($"Правильный ответ: {_question.Answer}");
        End(answerIsRight);
    }

    private void End(bool right)
    {
        DialogResult = right ? DialogResult.Yes : DialogResult.No;
        Close();
    }

    private void QuestionPopup_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode is Keys.Enter)
            button1_Click(sender, e);
    }
}
