using Newtonsoft.Json;
using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.Material;

namespace ThreejsJsonObject.Models.ThreejsObject;

public class RootObject
{
    public readonly Metadata metadata = new Metadata();
    public BaseGeometry[] geometries { get; set; } = [];
    public BaseMaterial[] materials { get; set; } = [];
    public Shape.Shape[] shapes { get; set; } = [];

    [JsonProperty(PropertyName = "object")]
    public Scene Scene { get; set; }
}
