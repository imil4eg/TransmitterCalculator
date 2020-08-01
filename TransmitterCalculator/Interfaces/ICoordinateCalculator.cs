using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public interface ICoordinateCalculator
    {
        Point CoordinateToFormLocation(string x, string y, Control control);
        Point CoordinateToFormLocation(double x, double y, Control control);
        PointD CalculateRadioTransmitterOnBoardCoordinates(IList<float> time, IList<Transmitter> transmitters);
        float CalculateRange(float time);
        Point CalculateControlMiddle(Control control);
    }
}
