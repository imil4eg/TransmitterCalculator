using System.Drawing;
using System.Windows.Forms;

namespace TransmitterCalculator.Controls
{
    public partial class RadioTransmitter : UserControl, IBoardCoordinate
    {
        public PointD OnBoardLocation { get; set; }

        public RadioTransmitter()
        {
            InitializeComponent();
        }
    }
}
