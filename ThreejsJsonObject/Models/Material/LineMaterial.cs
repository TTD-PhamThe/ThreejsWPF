namespace ThreejsJsonObject.Models.Material;

public class LineMaterial : BaseMaterial
{
    public override string type { get; set; } = MaterialConst.LINE_BASIC_MATERIAL;
    public double linewidth { get; set; } = 1;
}
