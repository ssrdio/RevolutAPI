using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.Shared.Enums
{
    public enum PayoutLinkState
    {
        created, failed, awaiting, active, expired, cancelled, processing, processed
    }
}
