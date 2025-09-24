namespace ThreejsJsonObject.Models.Geometry.Solid;

public class CylinderGeometry : BaseGeometry
{
    public override string type { get; set; } = "CylinderGeometry";

    /// <summary>
    /// bán kính mặt top
    /// </summary>
    public double radiusTop { get; set; }

    /// <summary>
    /// bán kính mặt bottom
    /// </summary>
    public double radiusBottom { get; set; }

    /// <summary>
    /// chiều cao
    /// </summary>
    public double height { get; set; }

    /// <summary>
    /// số mặt xung quanh
    /// </summary>
    public int radialSegments { get; set; }

    /// <summary>
    /// số mặt chiều cao
    /// </summary>
    public int heightSegments { get; set; }

    /// <summary>
    /// có đóng đầu không
    /// </summary>
    public bool openEnded { get; set; } = false;

    /// <summary>
    /// góc bắt đầu (theo radian) để vẽ mặt tròn, tính từ trục X dương theo chiều ngược kim đồng hồ.
    /// mặc định là góc
    /// </summary>
    public double thetaStart { get; set; } = 0;

    /// <summary>
    /// độ dài cung góc (theo radian)
    /// mặc định vẽ hết 1 vòng tròn
    /// </summary>
    public double thetaLength { get; set; } = Math.PI * 2;
}
