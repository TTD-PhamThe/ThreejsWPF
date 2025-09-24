namespace ThreejsJsonObject.Models.Geometry.Solid;

public class BufferGeometry : BaseGeometry
{
    public override string type { get; set; } = "BufferGeometry";

    public Data data { get; set; }
}

public class Data
{
    public Attributes attributes { get; set; }
}

public class Attributes
{
    public Position position { get; set; }
    public Normal normal { get; set; }
    public Uv uv { get; set; }
}

public class BaseAttributes
{
    public int itemSize { get; set; }
    public string type { get; set; } = "Float32Array";
    public double[] array { get; set; }
    public bool normalized { get; set; }
}

public class Position : BaseAttributes
{
}

public class Normal : BaseAttributes
{
}

public class Uv : BaseAttributes
{
}
