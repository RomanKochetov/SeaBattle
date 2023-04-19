using System.Collections.Generic;
using System.Windows.Forms;
using SeaBattle.Enums;
using SeaBattle.Models;
using ButtonState = SeaBattle.Enums.ButtonState;

namespace SeaBattle.Data;

public class StateData
{
    private static StateData _instance;

    private StateData()
    {
        ButtonStates = new Dictionary<ButtonPosition, ButtonState>();
        Ships = new List<ButtonPosition>();
        Cells = new List<Button>();
        MapState = MapState.Start;
    }

    public Dictionary<ButtonPosition, ButtonState> ButtonStates { get; }
    public List<ButtonPosition> Ships { get; }
    public List<Button> Cells { get; }
    public MapState MapState { get; set; }

    public static StateData GetInstance()
    {
        return _instance ??= new StateData();
    }
}
