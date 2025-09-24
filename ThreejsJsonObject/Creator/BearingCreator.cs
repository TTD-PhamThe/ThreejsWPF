using System.Numerics;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class BearingCreator
{
    public static CylinderGeometry GenerateBearingGeometry(double widthBearing, double heightBearing)
    {
        return new CylinderGeometry()
        {
            uuid = Guid.NewGuid().ToString(),
            radiusTop = 0,
            radiusBottom = widthBearing / Math.Sqrt(2),
            radialSegments = 4,
            height = heightBearing,
            heightSegments = 1,
        };
    }

    public static Child GenerateBearingObject(string name, CylinderGeometry geometry, Material material, Vector3 position)
    {
        Matrix4x4 matrixRotateX90 = Matrix4x4.CreateRotationX((float)Math.PI / 2);
        Matrix4x4 matrixRotateY45 = Matrix4x4.CreateRotationZ((float)Math.PI / 4);
        Matrix4x4 matrixTransalateZ = Matrix4x4.CreateTranslation(position.X, position.Y, (float)(position.Z + geometry.height / 2));
        Matrix4x4 matrix = matrixRotateX90 * matrixRotateY45 * matrixTransalateZ;
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
