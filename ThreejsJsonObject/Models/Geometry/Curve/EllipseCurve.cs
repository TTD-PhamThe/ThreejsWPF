namespace ThreejsJsonObject.Models.Geometry.Curve;

public class EllipseCurve : BaseCurve
{
    public override string type { get; set; } = "EllipseCurve";

    /// <summary>
    /// tọa độ x tâm elip
    /// </summary>
    public double aX { get; set; } = 0;

    /// <summary>
    /// tọa độ y tâm elip
    /// </summary>
    public double aY { get; set; } = 0;

    /// <summary>
    /// bán kính trục x elip
    /// </summary>
    public double xRadius { get; set; } = 1;

    /// <summary>
    /// bán kính trục y elip
    /// </summary>
    public double yRadius { get; set; } = 1;

    /// <summary>
    /// góc bắt đầu vẽ elip (theo radian)
    /// </summary>
    public double aStartAngle { get; set; } = 0;

    /// <summary>
    /// góc kết thúc vẽ elip (theo radian)
    /// </summary>
    public double aEndAngle { get; set; } = Math.PI * 2;

    /// <summary>
    /// chiều vẽ elip được vẽ
    /// </summary>
    public bool aClockwise { get; set; }

    /// <summary>
    /// góc xoay elip quanh tâm của nó (theo radian)
    /// </summary>
    public double aRotation { get; set; } = 0;
}
