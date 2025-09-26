using ThreejsJsonObject.Models.Material;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class MaterialCreator
{
    public static BaseMaterial GenerateMeshMaterial(string name, string color)
    {
        return new MeshMaterial()
        {
            uuid = Guid.NewGuid().ToString(),
            name = name,
            color = color
        };
    }

    public static BaseMaterial GenerateLineMaterial(string name, string color)
    {
        return new LineMaterial()
        {
            uuid = Guid.NewGuid().ToString(),
            name = name,
            color = color
        };
    }
}
