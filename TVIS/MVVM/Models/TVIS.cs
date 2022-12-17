using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.Models;

namespace TVIS.MVVM.Model
{
    public class TVIS
    {
        private readonly ViolationsBook _ViolationsBook;
        private readonly PersonsBook _PersonsBook;
        private readonly VehiclesBook _VehiclesBook;
        private readonly PersonsVehiclesBook _PersonsVehiclesBook;
        public TVIS()
        {
            _ViolationsBook = new();
            _PersonsBook = new();
            _VehiclesBook = new();
            _PersonsVehiclesBook = new();
        }

        public void MakeViolation(Violation violation) 
        {

        }
        public void MakePerson(Person person)
        {

        }
        public void MakeVehicle(Vehicle vehicle)
        {

        }
        public void MakePersonsVehicle(PersonsVehicle personsVehicle)
        {

        }
    }
}
