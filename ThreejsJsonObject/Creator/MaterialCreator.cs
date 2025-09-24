using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class MaterialCreator
{
    public static Material Generate(string name, string color)
    {
        return new Material()
        {
            uuid = Guid.NewGuid().ToString(),
            type = "MeshStandardMaterial",
            name = name,
            color = color,
            roughness = 0.5
        };
    }
}
