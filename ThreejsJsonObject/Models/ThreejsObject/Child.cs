namespace ThreejsJsonObject.Models.ThreejsObject;

public class Child : BaseObject
{
    public string name { get; set; }
    public string geometry { get; set; }
    public string material { get; set; }
    public double[] matrix { get; set; }
    public int[] up => [0, 0, 1];

    public const string MESH_TYPE = "Mesh";
}
