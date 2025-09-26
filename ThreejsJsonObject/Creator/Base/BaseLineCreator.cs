using System.Numerics;
using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.Material;
using ThreejsJsonObject.Models.Object;
using ThreejsJsonObject.Utils;

namespace ThreejsJsonObject.Creator.Base;

public abstract class BaseLineCreator<TGeometry> where TGeometry : BaseGeometry
{
    private TGeometry _geometry;
    public TGeometry Geometry
    {
        get
        {
            if (_geometry == null)
            {
                _geometry = GenerateGeometry();
            }
            return _geometry;
        }
    }

    protected abstract TGeometry GenerateGeometry();

    public virtual LineChild GenerateObject(string name, BaseMaterial material)
    {
        return new LineChild()
        {
            uuid = Guid.NewGuid().ToString(),
            name = name,
            geometry = Geometry.uuid,
            material = material.uuid
        };
    }
}
