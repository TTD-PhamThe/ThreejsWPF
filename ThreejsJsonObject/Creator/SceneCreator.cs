using ThreejsJsonObject.Models.ThreejsObject;

namespace ThreejsJsonObject.Creator;

public class SceneCreator
{
    public static Scene Generate(Child[] children)
    {
        return new Scene()
        {
            uuid = Guid.NewGuid().ToString(),
            children = children
        };
    }
}
