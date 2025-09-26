namespace ThreejsJsonObject.Models.Geometry.Curve;

public class LineCurve : BaseCurve
{
    public override string type { get; set; } = "LineCurve";

    /// <summary>
    /// start point x,y
    /// </summary>
    public double[] v1 { get; set; } = [0, 0];

    /// <summary>
    /// end point x,y
    /// </summary>
    public double[] v2 { get; set; } = [0, 0];
}
