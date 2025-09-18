using ThreejsJsonObject.Models;
using System.Numerics;

namespace ThreejsJsonObject.Creator;

public class BoxCreator
{
    public static BoxGeometry GenerateType(double width, double height, double depth)
    {
        return new BoxGeometry()
        {
            uuid = Guid.NewGuid().ToString(),
            width = (double)width,
            height = (double)height,
            depth = (double)depth
        };
    }

    public static Child GenerateInstance(string name, Geometry geometry, Material material, Vector3 position)
    {
        return new Child()
        {
            uuid = Guid.NewGuid().ToString(),
            type = "Mesh",
            name = name,
            geometry = geometry.uuid,
            material = material.uuid,
            matrix = new int[]
            {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                (int)position.X, (int)position.Y, (int)position.Z, 1
            }
        };
    }
}
