using System.Collections.Generic;
using System.Drawing;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public interface ICoordinateSystemDrawer
    {
        void Draw(Graphics graphics);
        void DrawLineToTransmitters(Graphics graphics);
    }
}
