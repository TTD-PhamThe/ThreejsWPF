namespace ThreejsJsonObject.Models.Geometry.Solid;

public class BoxGemetry : BaseGeometry
{
    public override string type { get ; set; } = "BoxGeometry";

    /// <summary>
    /// chiều dài theo trục x
    /// </summary>
    public double width { get; set; } = 1;

    /// <summary>
    /// chiều cao theo trục y
    /// </summary>
    public double height { get; set; } = 1;

    /// <summary>
    /// chiều dài theo trục z
    /// </summary>
    public double depth { get; set; } = 1;
}
