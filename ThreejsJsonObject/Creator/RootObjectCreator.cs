using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class RootObjectCreator
{
    public static RootObject Generate(BaseGeometry[] geometries, Shape[] shapes, Material[] materials, Scene scene)
    {
        return new RootObject()
        {
            geometries = geometries,
            shapes = shapes,
            materials = materials,
            Scene = scene
        };
    }
}
