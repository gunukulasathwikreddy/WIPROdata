using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPWith
{
    internal class TrainerUtil
    {
        private ITrainerData iTrainerData;

        public TrainerUtil(ITrainerData iTrainerData)
        {
            this.iTrainerData = iTrainerData;
        }

        public void ShowInfo()
        {
            iTrainerData.Name();
            iTrainerData.City();
            iTrainerData.Email();
        }
    }
}
