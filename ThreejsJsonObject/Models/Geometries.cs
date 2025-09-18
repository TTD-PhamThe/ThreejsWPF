namespace ThreejsJsonObject.Models;

public class BoxGeometry : Geometry
{
    public override string type { get; set; } = "BoxGeometry";
    public double width { get; set; }
    public double height { get; set; }
    public double depth { get; set; }
}

public class CylinderGeometry : Geometry
{
    public override string type { get; set; } = "CylinderGeometry";
    public double radiusTop { get; set; }
    public double radiusBottom { get; set; }
    public double height { get; set; }
    public int radialSegments { get; set; }
}


