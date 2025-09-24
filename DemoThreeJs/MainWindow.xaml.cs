using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.Windows;
using ThreejsJsonObject.Creator;
using ThreejsJsonObject.Models.Geometry;
using ThreejsJsonObject.Models.ThreejsObject;

namespace DemoThreeJs;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        _ = ReloadViewAsync();
        Webviewer.NavigationCompleted += NavigationCompleted;
    }

    private void NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        _ = LoadJsonObject();
    }

    private async Task ReloadViewAsync()
    {
        var htmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"WebViewer\viewer.html");
        string url = $"file:///{htmlPath.Replace('\\', '/')}";
        await Webviewer.EnsureCoreWebView2Async();
        await Webviewer.CoreWebView2.Profile.ClearBrowsingDataAsync();
        Webviewer.CoreWebView2.Navigate(url);
    }

    private async Task LoadJsonObject()
    {
        var spacing = 2000;

        //create geometries
        var geometryPile = PileCreator.GeneratePileGeometry(400, 400, 20000);
        var geometryBearing = BearingCreator.GenerateBearingGeometry(400, 400);
        var geometryBeam = BeamCreator.GenerateBeamGeometry(400, 400, 10000);
        var geometryBrace = BraceCreator.GenerateLBraceGeometry(4000, 200, 40);
        BaseGeometry[] geometries = [geometryPile, geometryBearing, geometryBeam, geometryBrace];

        //create materials
        var matBearing = MaterialCreator.Generate("Red", "0x0000ff");
        var matBeam = MaterialCreator.Generate("Blue", "0x00ff00");
        var matPile = MaterialCreator.Generate("Yellow", "0xffff00");
        var matBrace = MaterialCreator.Generate("Orange", "0xff3300");
        Material[] mats = [matBearing, matBeam, matPile, matBrace];

        //create objects
        var instances = new List<Child>();
        for (int i = 0; i < 5; i++)
        {
            instances.Add(PileCreator.GeneratePileObject($"Pile-{i + 1}", geometryPile, matPile, new System.Numerics.Vector3(0, i * spacing, 0)));
            instances.Add(BearingCreator.GenerateBearingObject($"Bearing-{i + 1}", geometryBearing, matBearing, new System.Numerics.Vector3(0, i * spacing, 0)));
            instances.Add(BraceCreator.GenerateLBraceObject($"Brace-{i + 1}", geometryBrace, matBrace,
                new System.Numerics.Vector3(200, i * spacing, 0),
                new System.Numerics.Vector3(200, (i + 1) * spacing, -spacing),
                new System.Numerics.Vector3(1, 0, 0)));
            instances.Add(BraceCreator.GenerateLBraceObject($"Brace-{i + 1}(1)", geometryBrace, matBrace,
                new System.Numerics.Vector3(200, (i + 1) * spacing, 0),
                new System.Numerics.Vector3(200, i * spacing, -spacing),
                new System.Numerics.Vector3(1, 0, 0)));
        }
        instances.Add(BeamCreator.GenerateBeamObject($"Beam", geometryBeam, matBeam, new System.Numerics.Vector3(0, 0, 0)));

        //create scene
        var scene = SceneCreator.Generate(instances.ToArray());
        var root = RootObjectCreator.Generate(geometries, mats, scene);
        var jsonString = JsonConvert.SerializeObject(root, Formatting.Indented);

        //send to web viewer
        string script = $"window.loadObjectFromJsonString(`{jsonString}`);";
        await Webviewer.CoreWebView2.ExecuteScriptAsync(script);
    }

    private void ButtonReload_Click(object sender, RoutedEventArgs e)
    {
        _ = ReloadViewAsync();
    }
}