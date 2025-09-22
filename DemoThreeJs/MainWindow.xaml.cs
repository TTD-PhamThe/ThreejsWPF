using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.Windows;
using ThreejsJsonObject.Creator;
using ThreejsJsonObject.Models;

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
        //create geometries
        var geometries = new List<Geometry>();
        var typeBox = PileCreator.GeneratePileGeometry(400, 400, 20000);
        geometries.Add(typeBox);
        var typeBearing = BearingCreator.GenerateBearingGeometry(400, 400);
        geometries.Add(typeBearing);
        var typeBeam = BeamCreator.GenerateBeamGeometry(400, 400, 10000);
        geometries.Add(typeBeam);
        var typeL = BraceCreator.GenerateLBraceGeometry(4000, 200, 40);
        geometries.Add(typeL);

        //create materials
        var mat = MaterialCreator.Generate("Red", "0xff0000");

        //create objects
        var instances = new List<Child>();
        for (int i = 0; i < 5; i++)
        {
            instances.Add(PileCreator.GeneratePileObject($"Pile-{i + 1}", typeBox, mat, new System.Numerics.Vector3(0, i * 2000, 0)));
            instances.Add(BearingCreator.GenerateBearingObject($"Bearing-{i + 1}", typeBearing, mat, new System.Numerics.Vector3(0, i * 2000, 0)));
        }
        instances.Add(BeamCreator.GenerateBeamObject($"Beam", typeBeam, mat, new System.Numerics.Vector3(0, 0, 0)));
        instances.Add(BraceCreator.GenerateLBraceObject($"Beam", typeL, mat, 
            new System.Numerics.Vector3(2000, 0, 0), 
            new System.Numerics.Vector3(2000, 2000, -2000), 
            new System.Numerics.Vector3(1, 0, 0)));

        //create scene
        var scene = SceneCreator.Generate(instances.ToArray());
        var root = RootObjectCreator.Generate(geometries.ToArray(), [mat], scene);
        var jsonString = JsonConvert.SerializeObject(root);

        //send to web viewer
        string script = $"window.loadObjectFromJsonString(`{jsonString}`);";
        await Webviewer.CoreWebView2.ExecuteScriptAsync(script);
    }

    private void ButtonReload_Click(object sender, RoutedEventArgs e)
    {
        _ = ReloadViewAsync();
    }
}