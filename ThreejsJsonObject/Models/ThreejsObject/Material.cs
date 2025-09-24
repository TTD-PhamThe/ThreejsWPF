namespace ThreejsJsonObject.Models.ThreejsObject;

public class Material : BaseObject
{
    public override string type { get; set; } = MESH_STANDARD_MATERIAL;
    public string color { get; set; }
    public string name { get; set; }
    public double roughness { get; set; }

    public const string MESH_STANDARD_MATERIAL = "MeshStandardMaterial";
    public const string MESH_PHONG_MATERIAL = "MeshPhongMaterial";
}
