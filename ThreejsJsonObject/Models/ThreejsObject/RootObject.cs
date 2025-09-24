using Newtonsoft.Json;
using ThreejsJsonObject.Models.Geometry;

namespace ThreejsJsonObject.Models.ThreejsObject;

public class RootObject
{
    public readonly Metadata metadata = new Metadata();
    public BaseGeometry[] geometries { get; set; } = [];
    public Material[] materials { get; set; } = [];
    public Shape[] shapes { get; set; } = [];

    [JsonProperty(PropertyName = "object")]
    public Scene Scene { get; set; }
}
