using ThreejsJsonObject.Models.Object;
using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class SceneCreator
{
    public static Scene Generate(BaseChild[] children)
    {
        return new Scene()
        {
            uuid = Guid.NewGuid().ToString(),
            children = children
        };
    }
}
