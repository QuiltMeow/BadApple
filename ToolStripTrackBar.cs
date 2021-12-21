using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ToolStripExtend
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripTrackBar : ToolStripControlHost
    {
        public TrackBar trackBar
        {
            get;
            private set;
        }

        public ToolStripTrackBar() : base(new TrackBar())
        {
            trackBar = Control as TrackBar;
        }
    }
}