namespace ThreejsJsonObject.Models;

public class BoxGeometry : Geometry
{
    public override string type { get; set; } = "BoxGeometry";

    /// <summary>
    /// chiều dài theo trục x
    /// </summary>
    public double width { get; set; }

    /// <summary>
    /// chiều cao theo trục y
    /// </summary>
    public double height { get; set; }

    /// <summary>
    /// chiều dài theo trục z
    /// </summary>
    public double depth { get; set; }
}

public class CylinderGeometry : Geometry
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


public class BufferGeometry : Geometry
{
    public override string type { get; set; } = "BufferGeometry";

    public Data data { get; set; }


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
        public float[] array { get; set; }
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
}




