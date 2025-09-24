using System.Numerics;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Models.ThreejsObject;
using ThreejsJsonObject.Utils;
using ThreejsJsonObject.Models.Geometry.Curve;
using ThreejsJsonObject.Creator.Base;

namespace ThreejsJsonObject.Creator;

public class BraceExtrudeCreator : BaseObjectCreator<ExtrudeGeometry>
{
    private float _width;
    private float _height;
    private float _thickness;
    private float _length;
    public Shape Shape { get; private set; }

    public BraceExtrudeCreator(float width, float height, float thickness, float length)
    {
        _width = width;
        _height = height;
        _thickness = thickness;
        _length = length;
        Shape = GenerateLBraceShape();
    }

    private Shape GenerateLBraceShape()
    {
        var shape = new Shape();
        shape.uuid = Guid.NewGuid().ToString();
        shape.curves = [
            new LineCurve()
            {
                v1 = [0, 0],
                v2 = [_width, 0]
            },
            new LineCurve()
            {
                v1 = [_width, 0],
                v2 = [_width, _thickness]
            },
            new LineCurve()
            {
                v1 = [_width, _thickness],
                v2 = [_thickness, _thickness]
            },
            new LineCurve()
            {
                v1 = [_thickness, _thickness],
                v2 = [_thickness, _height]
            },
            new LineCurve()
            {
                v1 = [_thickness, _height],
                v2 = [0, _height]
            },
            new LineCurve()
            {
                v1 = [0, _height],
                v2 = [0, 0]
            }
        ];
        return shape;
    }

    protected override Matrix4x4 PreTransformToLocation()
    {
        return Matrix4x4.CreateTranslation(0, 0, -(float)Geometry.options.depth);
    }

    protected override ExtrudeGeometry GenerateGeomety()
    {
        return new ExtrudeGeometry()
        {
            uuid = Guid.NewGuid().ToString(),
            shapes = [Shape.uuid],
            options = new Options()
            {
                depth = _length
            }
        };
    }
}
