using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class RootObjectCreator
{
    public static RootObject Generate(BaseGeometry[] types, Material[] materials, Scene rootObject)
    {
        return new RootObject()
        {
            geometries = types,
            materials = materials,
            Scene = rootObject
        };
    }
}
