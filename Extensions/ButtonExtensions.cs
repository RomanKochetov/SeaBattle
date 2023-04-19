using System;
using System.Drawing;
using System.Windows.Forms;
using SeaBattle.Data;
using SeaBattle.Enums;
using ButtonState = SeaBattle.Enums.ButtonState;

namespace SeaBattle.Extensions;

public static class ButtonExtensions
{
    private static readonly StateData StateData = StateData.GetInstance();

    public static void SetState(this Button button, ButtonState state)
    {
        switch (state)
        {
            case ButtonState.ProgressIdle:
            case ButtonState.ChooseIdle:
                button.BackColor = Color.White;
                break;
            case ButtonState.ChooseSelected:
                button.BackColor = Color.Red;
                break;

            case ButtonState.ProgressShipDisabled:
                button.BackColor = Color.Red;
                button.Enabled = false;
                break;
            case ButtonState.EdgeDisabled:
                button.BackColor = Color.Gray;
                button.Enabled = false;
                break;

            case ButtonState.ProgressDisabledFail:
                button.BackColor = Color.Crimson;
                button.Enabled = false;
                break;
            case ButtonState.ProgressDisabledRight:
                button.BackColor = Color.GreenYellow;
                button.Enabled = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(state.ToString(), state, null);
        }
    }

    public static ButtonState GetState(this Button button)
    {
        if (!button.Enabled && button.BackColor == Color.Gray)
            return ButtonState.EdgeDisabled;
        if (!button.Enabled && button.BackColor == Color.Red) return ButtonState.ProgressShipDisabled;
        if (!button.Enabled && button.BackColor == Color.Crimson) return ButtonState.ProgressDisabledFail;
        if (!button.Enabled && button.BackColor == Color.GreenYellow) return ButtonState.ProgressDisabledRight;

        if (button.BackColor == Color.Red) return ButtonState.ChooseSelected;

        if (button.BackColor == Color.White && StateData.MapState == MapState.Start) return ButtonState.ChooseIdle;

        return button.BackColor == Color.White ? ButtonState.ProgressIdle : ButtonState.Unknown;
    }
}
