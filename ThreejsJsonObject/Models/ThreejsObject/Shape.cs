using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.Geometry.Curve;

namespace ThreejsJsonObject.Models.ThreejsObject;

public class Shape : BaseObject
{
    public override string type { get; set; } = "Shape";
    public double[] currentPoint { get; set; }
    BaseCurve[] curves { get; set; } = [];
    Hole[] holes { get; set; } = [];
}
