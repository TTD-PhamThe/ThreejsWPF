using System.Numerics;
using ThreejsJsonObject.Creator.Base;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class BearingCreator : BaseObjectCreator<CylinderGeometry>
{
    private double _widthBearing;
    private double _heightBearing;
    public BearingCreator(double widthBearing, double heightBearing)
    {
        _widthBearing = widthBearing;
        _heightBearing = heightBearing;
    }

    protected override CylinderGeometry GenerateGeomety()
    {
        return new CylinderGeometry()
        {
            uuid = Guid.NewGuid().ToString(),
            radiusTop = 0,
            radiusBottom = _widthBearing / Math.Sqrt(2),
            radialSegments = 4,
            height = _heightBearing,
            heightSegments = 1,
        };
    }

    protected override Matrix4x4 PreTransformToLocation()
    {
        Matrix4x4 matrixRotateX90 = Matrix4x4.CreateRotationX((float)Math.PI / 2);
        Matrix4x4 matrixRotateY45 = Matrix4x4.CreateRotationZ((float)Math.PI / 4);
        return matrixRotateX90 * matrixRotateY45;
    }
}
