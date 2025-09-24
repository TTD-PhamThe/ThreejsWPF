namespace ThreejsJsonObject.Models;

public class BaseObject : ITypedObject
{
    public string uuid { get; set; }
    public virtual string type { get; set; }
}
