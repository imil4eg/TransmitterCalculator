using System.Drawing;
using System.Windows.Forms;

namespace TransmitterCalculator.Controls
{
    public partial class Transmitter : UserControl, IBoardCoordinate
    {
        public PointF OnBoardLocation { get; set; }

        public Transmitter()
        {
            InitializeComponent();
        }
        private void Transmitter_MouseDown_1(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Move | DragDropEffects.Copy);
        }
    }
}
