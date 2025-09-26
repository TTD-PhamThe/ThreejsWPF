using ThreejsJsonObject.Creator.Base;
using ThreejsJsonObject.Models.Geometry.Solid;
using ThreejsJsonObject.Models.Geometry.Solid.BufferData;
using Attribute = ThreejsJsonObject.Models.Geometry.Solid.BufferData.Attribute;

namespace ThreejsJsonObject.Creator;

public class DimCreator : BaseLineCreator<BufferLineGeometry>
{
    protected override BufferLineGeometry GenerateGeometry()
    {
        return new BufferLineGeometry()
        {
            uuid = Guid.NewGuid().ToString(),
            data = new LineData
            {
                attributes = new LineAttributes
                {
                    position = new Attribute { itemSize = 3, array = [2000, 0, 2000, 0, 2000, 0] }
                }
            }
        };
    }
}
