using System;
using System.Text.RegularExpressions;

namespace TVIS.MVVM.Models
{
    public class Person
    {
        public string ID { get; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? Image { get; set; }
        public Person(string ID)
        {
            this.ID = ID;
            if (!Regex.IsMatch(ID, "[1-9][0-9]{9}"))
            {
                var message = string.Format("ID({0}) is not valid.", ID);
                throw new ArgumentException(message, nameof(this.ID));
            }
            this.ID = ID;
        }
        public override string ToString()
        {
            return $"{ID},{FirstName},{LastName}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Person prson &&
                ID == prson.ID;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
