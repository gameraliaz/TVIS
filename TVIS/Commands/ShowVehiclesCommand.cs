using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVIS.MVVM.ViewModels;

namespace TVIS.Commands
{
    public class ShowVehiclesCommand : CommandBase
    {
        private readonly DashboardViewModel dashboardViewModel;

        public ShowVehiclesCommand(DashboardViewModel dashboardViewModel)
        {
            this.dashboardViewModel = dashboardViewModel;
        }

        public override void Execute(object? parameter)
        {
            dashboardViewModel.Table = dashboardViewModel.Vehicles;
        }
    }
}
