using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Model;

namespace TVIS.MVVM.Models
{
    public class PersonsVehicle
    {
        public string ID { get; }
        public string Pelak { get; }

        public PersonsVehicle(string Pelak, string ID)
        {
            this.Pelak = Pelak;
            this.ID = ID;
        }

        public override bool Equals(object? obj)
        {
            return obj is PersonsVehicle personsvehicle &&
                   EqualityComparer<string>.Default.Equals(ID, personsvehicle.ID) &&
                   EqualityComparer<string>.Default.Equals(Pelak, personsvehicle.Pelak);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Pelak);
        }

        public override string? ToString()
        {
            return $"{ID},{Pelak}";
        }
    }
}
