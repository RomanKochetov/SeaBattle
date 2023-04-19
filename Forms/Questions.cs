using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SeaBattle.Core;
using SeaBattle.Data;
using SeaBattle.Models;

namespace SeaBattle.Forms;

public partial class Questions : Form
{
    private List<Question> _questions = QuestionProcessor.GetQuestions();

    public Questions()
    {
        InitializeComponent();
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.WrapContents = false;
        flowLayoutPanel1.Dock = DockStyle.Fill;
        flowLayoutPanel1.AutoScroll = true;
        CreateControls();
    }

    private void CreateControls()
    {
        for (var i = 0; i < _questions.Count; i++)
        {
            var question = _questions[i];
            var label = new Label();
            label.Text = $"Вопрос на {question.Name}";
            label.Location = new Point(0, i * 3);
            label.AutoSize = true;

            var score = new Label();
            score.Text = $"Баллы: {question.Score}";
            score.Location = new Point(0, i * 3 + 1);
            score.AutoSize = true;

            var answer = new Label();
            answer.Text = $"Ответ: {question.Answer}";
            answer.Location = new Point(0, i * 3 + 2);
            answer.AutoSize = true;

            var addButton = new Button();
            addButton.Location = new Point(i * 3 + 3);
            addButton.Click += delegate
            {
                var result = new ChangeQuestion(question).ShowDialog();
                if (result != DialogResult.OK) return;
                MessageBoxFramework.DisplayInfo("Вопрос сохранен!");
                _questions = QuestionProcessor.GetQuestions();
                flowLayoutPanel1.Controls.Clear();
                CreateControls();
            };
            addButton.BackColor = Color.White;
            addButton.Text = "Изменить";

            flowLayoutPanel1.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(score);
            flowLayoutPanel1.Controls.Add(answer);
            flowLayoutPanel1.Controls.Add(addButton);
        }

        var button = new Button
        {
            Text = "Добавить вопрос",
            Location = new Point(0, Bottom)
        };
        button.AutoSize = true;
        button.BackColor = Color.White;
        button.Click += delegate
        {
            var result = new AddQuestion().ShowDialog();
            if (result != DialogResult.OK) return;
            MessageBoxFramework.DisplayInfo("Вопрос сохранен!");
            _questions = QuestionProcessor.GetQuestions();
            flowLayoutPanel1.Controls.Clear();
            CreateControls();
        };
        flowLayoutPanel1.Controls.Add(button);
    }
}
