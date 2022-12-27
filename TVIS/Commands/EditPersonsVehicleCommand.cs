using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TVIS.Exceptions;
using TVIS.MVVM.Models;
using TVIS.MVVM.ViewModels;

namespace TVIS.Commands
{
    public class EditPersonsVehicleCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            
        }
        public override bool CanExecute(object? parameter)
        {
            return false;
        }
    }
}
