using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Geometry;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Map = Esri.ArcGISRuntime.Mapping.Map;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;

namespace AppComida.ViewModels
{
    public class AcercaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Map _map;
        public Map Map
        {
            get => _map;
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }

        private GraphicsOverlayCollection _graphicsOverlays;
        public GraphicsOverlayCollection GraphicsOverlays
        {
            get { return _graphicsOverlays; }
            set
            {
                _graphicsOverlays = value;
                OnPropertyChanged();
            }
        }

        private void SetupMap()
        {

            Map = new Map(BasemapStyle.OSMDarkGray);

            var mapCenterPoint = new MapPoint(-100.24548081805652, 25.664171173264066, SpatialReferences.Wgs84);
            Map.InitialViewpoint = new Viewpoint(mapCenterPoint, 5000);

        }

        private void CreateGraphics()
        {
            var malibuGraphicsOverlay = new GraphicsOverlay();

            GraphicsOverlayCollection overlays = new GraphicsOverlayCollection
            {
                malibuGraphicsOverlay
            };

            var dumeBeachPoint = new MapPoint(-100.24548081805652, 25.664171173264066, SpatialReferences.Wgs84);

            var pointSymbol = new SimpleMarkerSymbol
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = System.Drawing.Color.Orange,
                Size = 10.0
            };

            pointSymbol.Outline = new SimpleLineSymbol
            {
                Style = SimpleLineSymbolStyle.Solid,
                Color = System.Drawing.Color.Blue,
                Width = 2.0
            };

            var pointGraphic = new Graphic(dumeBeachPoint, pointSymbol);

            malibuGraphicsOverlay.Graphics.Add(pointGraphic);

            this.GraphicsOverlays = overlays;
        }

        public AcercaViewModel() 
        { 
            SetupMap();
            CreateGraphics();
        }

    }
}
