namespace ThreejsJsonObject.Models.Geometry.Solid.BufferData;

public class Attribute
{
    public int itemSize { get; set; }
    public string type { get; set; } = "Float32Array";
    public double[] array { get; set; }
    public bool normalized { get; set; }
}
