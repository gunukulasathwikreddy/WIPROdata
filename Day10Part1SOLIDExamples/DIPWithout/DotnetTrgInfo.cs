using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPWithout
{
    internal class DotnetTrgInfo
    {
        private DotnetTrg dotnetTrg;

        public DotnetTrgInfo(DotnetTrg dotnetTrg)
        {
            this.dotnetTrg = dotnetTrg;
        }

        public void Details()
        {
            dotnetTrg.TrainerName();
            dotnetTrg.City();
        }
    }
}
