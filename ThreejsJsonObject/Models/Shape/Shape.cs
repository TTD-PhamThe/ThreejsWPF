using ThreejsJsonObject.Models.Geometry;

namespace ThreejsJsonObject.Models.Shape;

public class Shape : BaseObject
{
    public override string type { get; set; } = "Shape";
    public double[] currentPoint { get; set; } = [0, 0];
    public BaseCurve[] curves { get; set; } = [];
    public Hole[] holes { get; set; } = [];
}
