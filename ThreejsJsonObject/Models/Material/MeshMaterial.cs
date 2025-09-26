namespace ThreejsJsonObject.Models.Material;

public class MeshMaterial : BaseMaterial
{
    public override string type { get; set; } = MaterialConst.MESH_STANDARD_MATERIAL;
    public double roughness { get; set; } = 0.5;
}
