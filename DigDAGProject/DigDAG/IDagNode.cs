using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDAG
{
    public interface IDagNode
    {
        IEnumerable<IDagNode> Nexts { get; }
    }
}
