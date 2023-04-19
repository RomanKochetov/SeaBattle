using System;
using System.Windows.Forms;

namespace SeaBattle.Models;

public class ButtonPosition : IEquatable<ButtonPosition>
{
    public readonly uint Column;
    public readonly uint Row;
    public Button Button;

    public ButtonPosition(uint row, uint column, Button button)
    {
        Row = row;
        Column = column;
        Button = button;
    }

    public bool Equals(ButtonPosition other)
    {
        if (other == null) return false;
        return ReferenceEquals(this, other) || (Row == other.Row && Column == other.Column);
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        return ReferenceEquals(this, obj) || (obj.GetType() == GetType() && Equals((ButtonPosition) obj));
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((int) Row * 397) ^ (int) Column;
        }
    }
}
