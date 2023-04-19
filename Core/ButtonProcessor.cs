using System;
using System.Linq;
using System.Windows.Forms;
using SeaBattle.Data;
using SeaBattle.Extensions;
using SeaBattle.Forms;
using SeaBattle.Models;
using ButtonState = SeaBattle.Enums.ButtonState;

namespace SeaBattle.Core;

public static class ButtonProcessor
{
    private static readonly StateData StateData = StateData.GetInstance();

    public static void ProcessButtonAtStart(Button button, ButtonState buttonState, ButtonPosition buttonPosition)
    {
        switch (buttonState)
        {
            case ButtonState.ChooseIdle:
                button.SetState(ButtonState.ChooseSelected);
                StateData.ButtonStates[buttonPosition] = ButtonState.ChooseSelected;
                StateData.Ships.Add(buttonPosition);
                break;

            case ButtonState.ChooseSelected:
                button.SetState(ButtonState.ChooseIdle);
                StateData.ButtonStates[buttonPosition] = ButtonState.ChooseIdle;
                StateData.Ships.RemoveAll(x => x.Equals(buttonPosition));
                break;

            default:
                throw new ArgumentOutOfRangeException(buttonState.ToString(), buttonState, null);
        }
    }

    public static void ProcessButtonAtProgress(Button button, ButtonPosition buttonPosition)
    {
        var teamName = TeamData.IsOneTeamTurn ? TeamData.TeamOne : TeamData.TeamTwo;
        if (buttonPosition.IsShip())
        {
            MessageBoxFramework.DisplayInfo($"Команда {teamName} подбила корабль!\n+20 очков");
            button.SetState(ButtonState.ProgressShipDisabled);
            StateData.ButtonStates[buttonPosition] = ButtonState.ProgressShipDisabled;
            StateData.Ships.RemoveAll(x => x.Equals(buttonPosition));
            TeamData.AddScore(20);
            return;
        }

        var question = QuestionProcessor.GetRandomQuestion();
        if (new QuestionPopup(question).ShowDialog() == DialogResult.Yes)
        {
            button.SetState(ButtonState.ProgressDisabledRight);
            StateData.ButtonStates[buttonPosition] = ButtonState.ProgressDisabledRight;
            TeamData.AddScore(20);
        }
        else
        {
            button.SetState(ButtonState.ProgressDisabledFail);
            StateData.ButtonStates[buttonPosition] = ButtonState.ProgressDisabledFail;
        }
    }

    private static bool IsShip(this ButtonPosition position)
    {
        return StateData.Ships.Any(position.Equals);
    }
}
