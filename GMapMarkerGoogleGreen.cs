using GMap.NET;
using GMap.NET.WindowsForms.ToolTips;

namespace CompanyMailingList
{
    internal class GMapMarker
    {
        internal string ToolTipText;
        private PointLatLng pointLatLng;

        public GMapMarker(PointLatLng pointLatLng)
        {
            this.pointLatLng = pointLatLng;
        }

        public GMapRoundedToolTip ToolTip { get; internal set; }
    }
}