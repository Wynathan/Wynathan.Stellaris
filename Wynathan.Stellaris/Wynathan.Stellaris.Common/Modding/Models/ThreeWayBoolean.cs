using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wynathan.Stellaris.Common.Attributes;

namespace Wynathan.Stellaris.Common.Modding.Models
{
    public enum ThreeWayBoolean
    {
        [CommonBinding("no")]
        No,
        [CommonBinding("yes")]
        Yes,
        [CommonBinding("always")]
        Always
    }
}
