using System.Numerics;
using ThreejsJsonObject.Creator.Base;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class BearingCreator : BaseMeshCreator<CylinderGeometry>
{
    private double _widthBearing;
    private double _heightBearing;
    public BearingCreator(double widthBearing, double heightBearing)
    {
        _widthBearing = widthBearing;
        _heightBearing = heightBearing;
    }

    protected override CylinderGeometry GenerateGeometry()
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
        var matrixRotateX90 = Matrix4x4.CreateRotationX((float)Math.PI / 2);
        var matrixRotateY45 = Matrix4x4.CreateRotationZ((float)Math.PI / 4);
        var matrixMove = Matrix4x4.CreateTranslation(0, 0, (float)_heightBearing / 2);
        return matrixRotateX90 * matrixRotateY45 * matrixMove;
    }
}
