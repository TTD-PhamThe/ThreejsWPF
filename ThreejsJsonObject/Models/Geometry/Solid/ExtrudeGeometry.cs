namespace ThreejsJsonObject.Models.Geometry.Solid;

public class ExtrudeGeometry : BaseGeometry
{
    public override string type { get ; set ; } = "ExtrudeGeometry";

    /// <summary>
    /// danh sách uuid hình dạng 2D để extrude ra 3D
    /// </summary>
    public string[] shapes { get; set; }

    /// <summary>
    /// tùy chọn của khối extrude
    /// </summary>
    public Options options { get; set; } = new Options();
}

public class Options
{
    /// <summary>
    /// chiều cao của hình học được tạo ra.
    /// </summary>
    public double depth { get; set; } = 1;

    /// <summary>
    /// các cạnh extrud của vát không
    /// </summary>
    public bool bevelEnabled { get; set; }
}
