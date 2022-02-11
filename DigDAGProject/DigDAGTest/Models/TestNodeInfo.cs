using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDAGTest.Models
{
    internal record TestNodeInfo(uint Id, ulong Depth, int Index, uint ParentId);
}
