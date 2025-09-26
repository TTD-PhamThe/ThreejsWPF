using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreejsJsonObject.Models.Object;

public class MeshChild : BaseChild
{
    public override string type { get; set; } = "Mesh";
    public double[] matrix { get; set; }
    public int[] up { get; set; } = [0, 0, 1];
}
