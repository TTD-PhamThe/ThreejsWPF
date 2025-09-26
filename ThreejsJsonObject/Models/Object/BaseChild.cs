using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreejsJsonObject.Models.Object;
public class BaseChild : BaseObject
{
    public string name { get; set; }
    public string geometry { get; set; }
    public string material { get; set; }
}
