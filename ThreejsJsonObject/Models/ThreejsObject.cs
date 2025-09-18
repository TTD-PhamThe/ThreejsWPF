using Newtonsoft.Json;

namespace ThreejsJsonObject.Models;


/// <summary>
/// Root object
/// </summary>
public class RootObject
{
    public readonly Metadata metadata = new Metadata();
    public Geometry[] geometries { get; set; } = [];
    public Material[] materials { get; set; } = [];

    [JsonProperty(PropertyName = "object")]
    public Scene Scene { get; set; }
}

/// <summary>
/// Metadata
/// </summary>
public class Metadata
{
    const double version = 4.5f;
    const string type = "Object";
    const string generator = "By TTD deveploper";
}

/// <summary>
/// Là 1 scene chính chứa các đối tượng con
/// </summary>
public class Scene
{
    public string uuid { get; set; }
    const string type = "Scene";
    public Child[] children { get; set; } = [];
}

/// <summary>
/// Là 1 instacne được hiển thị trong scene, type được lấy từ Geometry và vật liệu được lấy từ Materials
/// </summary>
public class Child
{
    public string uuid { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public string geometry { get; set; }
    public string material { get; set; }
    public int[] matrix { get; set; }
}

/// <summary>
/// Là type của hình học
/// </summary>
public class Geometry
{
    public string uuid { get; set; }
    public virtual string type { get; set;  }
}

/// <summary>
/// Type của vật liệu
/// </summary>
public class Material
{
    public string uuid { get; set; }
    public string type { get; set; }
    public string color { get; set; }
    public string name { get; set; }
    public double roughness { get; set; }
}
