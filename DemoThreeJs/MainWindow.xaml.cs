using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ThreejsJsonObject;
using ThreejsJsonObject.Creator;

namespace DemoThreeJs
{
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
            //create json object
            var typeBox = BoxCreator.GenerateType(1, 1, 10);
            var mat = MaterialCreator.Generate("Red", "0xff0000");
            var instance = BoxCreator.GenerateInstance("Pile", typeBox, mat, new System.Numerics.Vector3(0, 0, 0));
            var scene = SceneCreator.Generate([instance]);
            var root = RootObjectCreator.Generate([typeBox], [mat], scene);
            var jsonString = JsonConvert.SerializeObject(root);

            string script = $"window.loadObjectFromJsonString(`{jsonString}`);";
            await Webviewer.CoreWebView2.ExecuteScriptAsync(script);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = LoadJsonObject();
        }
    }
}