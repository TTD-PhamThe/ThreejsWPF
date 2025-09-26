using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.Material;
using ThreejsJsonObject.Models.Shape;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class RootObjectCreator
{
    public static RootObject Generate(BaseGeometry[] geometries, Shape[] shapes, BaseMaterial[] materials, Scene scene)
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
