using ThreejsJsonObject.Models;

namespace ThreejsJsonObject.Creator;

public class RootObjectCreator
{
    public static RootObject Generate(Geometry[] types, Material[] materials, Scene rootObject)
    {
        return new RootObject()
        {
            geometries = types,
            materials = materials,
            Scene = rootObject
        };
    }
}
