using System.Numerics;
using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.Material;
using ThreejsJsonObject.Models.Object;
using ThreejsJsonObject.Models.ThreejsObject;
using ThreejsJsonObject.Utils;

namespace ThreejsJsonObject.Creator.Base;

public abstract class BaseMeshCreator<TGeometry> where TGeometry : BaseGeometry
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
    protected abstract Matrix4x4 PreTransformToLocation();

    public virtual MeshChild GenerateObject(string name, BaseMaterial material, Vector3 location, Vector3 xLocal, Vector3 yLocal)
    {
        var prePlace = PreTransformToLocation();
        var matrixToLocal = CoordinateUtils.GetTransformGlobalToLocal(location, xLocal, yLocal);
        Matrix4x4 matrix = prePlace * matrixToLocal;
        return new MeshChild()
        {
            uuid = Guid.NewGuid().ToString(),
            name = name,
            geometry = Geometry.uuid,
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
