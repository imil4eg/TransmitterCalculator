using System.Collections.Generic;
using System.Drawing;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public interface ICoordinateSystemDrawer
    {
        void Initialize(IEnumerable<Transmitter> transmitters, RadioTransmitter radioTransmitter, int width, int height);
        void Draw(Graphics graphics);
        void DrawLineToTransmitters(Graphics graphics);
    }
}
