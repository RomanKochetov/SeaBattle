using System;

namespace SeaBattle.Models;

public class Question : IEquatable<Question>
{
    public string Name { get; set; }
    public string Answer { get; set; }
    public int Score { get; set; }

    public bool Equals(Question other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && Answer == other.Answer;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((ButtonPosition) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var result = Name.GetHashCode();
            result = 31 * result + Answer.GetHashCode();
            return result;
        }
    }
}
