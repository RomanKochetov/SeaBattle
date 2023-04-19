using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SeaBattle.Core;
using SeaBattle.Data;
using SeaBattle.Enums;
using SeaBattle.Extensions;
using SeaBattle.Models;
using ButtonState = SeaBattle.Enums.ButtonState;

namespace SeaBattle.Forms;

public partial class Main : Form
{
    private const int CellSize = 30;
    private const int MapSize = 10;
    private const string Alphabet = "АБВГДЕЖЗИКЛМН";
    private readonly StateData _stateData = StateData.GetInstance();

    public Main()
    {
        InitializeComponent();
        CreateMap();
        QuestionProcessor.Init();
        new InputTeams().ShowDialog();
        Init();
    }

    private void Init()
    {
        TeamData.IsOneTeamTurn = true;
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        team1name.Text = $"Команда «{TeamData.TeamOne}»";
        team2name.Text = $"Команда «{TeamData.TeamTwo}»";

        team1score.Text = $"Счёт команды: {TeamData.TeamOneScore}";
        team2score.Text = $"Счёт команды: {TeamData.TeamTwoScore}";

        team1name.Font = new Font(team1name.Font, TeamData.IsOneTeamTurn ? FontStyle.Bold : FontStyle.Regular);
        team1score.Font = new Font(team1score.Font, TeamData.IsOneTeamTurn ? FontStyle.Bold : FontStyle.Regular);
        team2name.Font = new Font(team2name.Font, TeamData.IsOneTeamTurn ? FontStyle.Regular : FontStyle.Bold);
        team2score.Font = new Font(team2score.Font, TeamData.IsOneTeamTurn ? FontStyle.Regular : FontStyle.Bold);
    }

    private void DisplayWinScreen()
    {
        if (TeamData.TeamOneScore == TeamData.TeamTwoScore)
        {
            MessageBoxFramework.DisplayInfo("Ничья!\nДля продолжения воспользуйтесь меню");
            return;
        }

        var winner = TeamData.TeamOneScore > TeamData.TeamTwoScore ? TeamData.TeamOne : TeamData.TeamTwo;

        MessageBoxFramework.DisplayInfo($"Победила команда «{winner}»!\nДля продолжения воспользуйтесь меню");
    }

    private Button GetButton(int row, int column)
    {
        var button = new Button
        {
            Location = new Point(column * CellSize + 5 * column + 10, row * CellSize + 5 * row + 33),
            Size = new Size(CellSize, CellSize)
        };

        if (row == 0 && column > 0)
        {
            button.Enabled = false;
            button.BackColor = Color.Gray;
            button.Text = Alphabet[column - 1].ToString();
        }
        else
        {
            switch (column)
            {
                case 0 when row > 0:
                    button.Enabled = false;
                    button.BackColor = Color.Gray;
                    button.Text = row.ToString();
                    break;
                case 0 when row == 0:
                    button.Enabled = false;
                    button.BackColor = Color.Gray;
                    break;
                default:
                    button.BackColor = Color.White;
                    break;
            }
        }

        var uintRow = (uint) row;
        var uintColumn = (uint) column;


        button.Click += delegate { OnCellClick(button, uintRow, uintColumn); };
        _stateData.ButtonStates.Add(new ButtonPosition((uint) row, (uint) column, button), ButtonState.ChooseIdle);
        return button;
    }

    private void CreateMap()
    {
        for (var row = 0; row < MapSize; row++)
        for (var column = 0; column < MapSize; column++)
        {
            var button = GetButton(row, column);
            _stateData.Cells.Add(button);
            Controls.Add(button);
        }
    }

    private void OnCellClick(Button button, uint row, uint column)
    {
        var currentGameState = _stateData.MapState;
        var currentButtonState = _stateData.ButtonStates
            .First(x => x.Key.Row == row && x.Key.Column == column).Value;
        var position = new ButtonPosition(row, column, button);

        switch (currentGameState)
        {
            case MapState.Start:
                ButtonProcessor.ProcessButtonAtStart(button, currentButtonState, position);
                break;
            case MapState.InProgress:
                ButtonProcessor.ProcessButtonAtProgress(button, position);
                break;
        }

        TeamData.IsOneTeamTurn = !TeamData.IsOneTeamTurn;

        if (currentGameState is MapState.InProgress)
        {
            UpdateLabels();
        }

        if (!_stateData.Ships.Any() && _stateData.MapState is MapState.InProgress)
        {
            DisplayWinScreen();
            foreach (var cell in _stateData.Cells)
            {
                cell.Enabled = false;
            }
        }
    }

    private void Questions_Click(object sender, EventArgs e)
    {
        new Questions().ShowDialog();
    }

    private void ResetGame_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Вы уверены, что хотите начать заново?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        _stateData.ButtonStates.Clear();
        _stateData.Cells.Clear();
        _stateData.Ships.Clear();
        _stateData.MapState = MapState.Start;
        TeamData.TeamOneScore = 0;
        TeamData.TeamTwoScore = 0;

        if (MessageBox.Show("Вы хотите сменить команды?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            new InputTeams().ShowDialog();

        Controls.Clear();
        InitializeComponent();
        CreateMap();
        Init();
    }

    private void About_Click(object sender, EventArgs e)
    {
        new AboutGame().ShowDialog();
    }

    private void ButtonAction_Click(object sender, EventArgs e)
    {
        if (!_stateData.Ships.Any())
        {
            MessageBoxFramework.DisplayError("Обозначьте корабли");
            return;
        }

        foreach (Control control in Controls)
        {
            Button button;
            try
            {
                button = (Button) control;
            }
            catch (Exception)
            {
                continue;
            }

            switch (button.GetState())
            {
                case ButtonState.ChooseSelected:
                case ButtonState.ChooseIdle:
                    button.SetState(ButtonState.ProgressIdle);
                    break;
                default:
                    continue;
            }

            _stateData.MapState = MapState.InProgress;
        }

        ((Button) sender).Enabled = false;
    }
}
