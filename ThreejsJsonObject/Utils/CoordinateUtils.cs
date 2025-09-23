using System.Numerics;

namespace ThreejsJsonObject.Utils;

public class CoordinateUtils
{
    public static Matrix4x4 GetTransformGlobalToLocal(Vector3 origin, Vector3 xAxis, Vector3 yAxis)
    {
        xAxis = Vector3.Normalize(xAxis);
        yAxis = Vector3.Normalize(yAxis);
        var zAxis = Vector3.Normalize(Vector3.Cross(xAxis, yAxis));
        return new Matrix4x4(
            xAxis.X, xAxis.Y, xAxis.Z, 0,
            yAxis.X, yAxis.Y, yAxis.Z, 0,
            zAxis.X, zAxis.Y, zAxis.Z, 0,
            origin.X, origin.Y, origin.Z, 1
        );
    }

}
