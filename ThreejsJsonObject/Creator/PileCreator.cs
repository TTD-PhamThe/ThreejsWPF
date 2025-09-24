using System.Numerics;
using ThreejsJsonObject.Models.ThreejsObject;
using ThreejsJsonObject.Models.Geometry.Solid;

namespace ThreejsJsonObject.Creator;

public class PileCreator
{
    public static BoxGemetry GeneratePileGeometry(double width, double height, double length)
    {
        return new BoxGemetry()
        {
            uuid = Guid.NewGuid().ToString(),
            width = (double)width,
            height = (double)height,
            depth = (double)length
        };
    }

    public static Child GeneratePileObject(string name, BoxGemetry geometry, Material material, Vector3 position)
    {
        Matrix4x4 matrix = Matrix4x4.CreateTranslation(position.X, position.Y, (float)(position.Z - geometry.depth / 2));
        return new Child()
        {
            uuid = Guid.NewGuid().ToString(),
            type = "Mesh",
            name = name,
            geometry = geometry.uuid,
            material = material.uuid,
            matrix =
            [
                matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                matrix.M41, matrix.M42, matrix.M43, matrix.M44,
            ]
        };
    }
}
