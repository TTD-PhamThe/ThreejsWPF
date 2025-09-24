using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.Geometry.Curve;

namespace ThreejsJsonObject.Models.ThreejsObject;

public class Shape : BaseObject
{
    public override string type { get; set; } = "Shape";
    public double[] currentPoint { get; set; } = [0, 0];
    public BaseCurve[] curves { get; set; } = [];
    public Hole[] holes { get; set; } = [];
}

public class Hole : BaseObject
{
    public override string type { get; set; } = "Path";
    public double[] currentPoint { get; set; }
    public BaseCurve[] curves { get; set; } = [];
}
