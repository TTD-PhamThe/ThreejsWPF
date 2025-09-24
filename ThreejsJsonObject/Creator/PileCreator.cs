using System.Numerics;
using ThreejsJsonObject.Models.ThreejsObject;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Creator.Base;

namespace ThreejsJsonObject.Creator;

public class PileCreator : BaseObjectCreator<BoxGemetry>
{
    private double _width;
    private double _height;
    private double _length;
    public PileCreator(double width, double height, double length)
    {
        _width = width;
        _height = height;
        _length = length;
    }

    protected override BoxGemetry GenerateGeomety()
    {
        return new BoxGemetry()
        {
            uuid = Guid.NewGuid().ToString(),
            width = _width,
            height = _height,
            depth = _length
        };
    }

    protected override Matrix4x4 PreTransformToLocation()
    {
        return Matrix4x4.CreateTranslation(0, 0, -(float)Geometry.depth / 2);
    }
}
