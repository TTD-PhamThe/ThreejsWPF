namespace ThreejsJsonObject.Models.ThreejsObject;

public class Scene : BaseObject
{
    public override string type { get; set; } = "Scene";
    public Child[] children { get; set; } = [];
    public int[] up { get; set; } = [0, 0, 1];
}
