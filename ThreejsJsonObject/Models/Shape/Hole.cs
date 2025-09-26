using ThreejsJsonObject.Models.Geometry;

namespace ThreejsJsonObject.Models.Shape;

public class Hole : BaseObject
{
    public override string type { get; set; } = "Path";
    public double[] currentPoint { get; set; }
    public BaseCurve[] curves { get; set; } = [];
}
