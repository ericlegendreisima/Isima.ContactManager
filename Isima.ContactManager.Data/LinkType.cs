using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Data
{
    [Serializable]
    public enum LinkType : int
    {
        Friend = 0,
        Colleague = 1,
        Relation = 2,
        Network = 3
    }
}
