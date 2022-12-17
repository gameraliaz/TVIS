using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVIS.MVVM.Model
{
    public enum ViolationsType
    {
        overtaking = 1,
        Speed = 2,
        Belt = 3,
    }
    public class Violation
    {
        public string ID { get; }
        public string Pelak { get; }
        public DateTime ViolationDateTime { get; }
        public ViolationsType? TypeOfViolation { get; set; }
        public int? Cost { get; set; }
        public Violation(string ID, string Pelak, DateTime ViolationDateTime)
        {
            this.ID = ID;
            this.Pelak = Pelak;
            this.ViolationDateTime = ViolationDateTime;
        }

        public override bool Equals(object? obj)
        {
            return obj is Violation violation &&
                   EqualityComparer<string>.Default.Equals(ID, violation.ID) &&
                   EqualityComparer<string>.Default.Equals(Pelak, violation.Pelak) &&
                   ViolationDateTime == violation.ViolationDateTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Pelak, ViolationDateTime);
        }

        public override string? ToString()
        {
            return $"{ID},{Pelak},{ViolationDateTime}";
        }
    }
}
