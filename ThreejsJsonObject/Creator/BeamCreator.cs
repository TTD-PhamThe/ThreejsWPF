using System.Numerics;
using ThreejsJsonObject.Creator.Base;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class BeamCreator : BaseMeshCreator<BoxGemetry>
{
    private double _width;
    private double _height;
    private double _length;
    public BeamCreator(double width, double height, double length)
    {
        _width = width;
        _height = height;
        _length = length;
    }

    protected override BoxGemetry GenerateGeometry()
    {
        return new BoxGemetry()
        {
            uuid = Guid.NewGuid().ToString(),
            width = _width,
            height = _length,
            depth = _height
        };
    }

    protected override Matrix4x4 PreTransformToLocation()
    {
        return Matrix4x4.CreateTranslation(0, (float)Geometry.height / 2, -(float)Geometry.depth / 2);
    }
}
