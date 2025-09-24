using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.Numerics;
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

        //creator
        var pileCreator = new PileCreator(400, 400, 20000);
        var bearingCreator = new BearingCreator(400, 400);
        var beamCreator = new BeamCreator(400, 400, 10000);
        var braceCreator = new BraceExtrudeCreator(200, 400, 40, 3000);

        //create geometries
        BaseGeometry[] geometries = [pileCreator.Geometry, bearingCreator.Geometry, beamCreator.Geometry, braceCreator.Geometry];

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
            var p1Brace = new Vector3(200, i * spacing, 0);
            var p2Brace = new Vector3(200, (i + 1) * spacing, -spacing);
            var dirBrace = p2Brace - p1Brace;
            var yBrace = Vector3.UnitX;
            var xBrace = Vector3.Cross(dirBrace, yBrace);

            instances.Add(pileCreator.GenerateObject($"Pile-{i + 1}", matPile, new Vector3(0, i * spacing, 0), Vector3.UnitX, Vector3.UnitY));
            instances.Add(bearingCreator.GenerateObject($"Bearing-{i + 1}", matBearing, new Vector3(0, i * spacing, 0), Vector3.UnitX, Vector3.UnitY));
            instances.Add(braceCreator.GenerateObject($"Brace-{i + 1}", matBrace, p1Brace, xBrace, yBrace));
        }
        instances.Add(beamCreator.GenerateObject($"Beam", matBeam, new Vector3(0, 0, 0), Vector3.UnitX, Vector3.UnitY));

        //create scene
        var scene = SceneCreator.Generate(instances.ToArray());
        var root = RootObjectCreator.Generate(geometries, [braceCreator.Shape], mats, scene);
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