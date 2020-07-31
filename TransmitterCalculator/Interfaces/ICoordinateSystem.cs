using System;
using System.Collections.Generic;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public interface ICoordinateSystem
    {
        void Initialize(IList<Transmitter> transmitters, RadioTransmitter radioTransmitter, int windowWidth, int windowHeight);
        void ProcessInputFile(string inputFile);
        string GetRadioTransmitterLocationsAsString();
        void CalculateRadioTransmitterLocationEvent(object sender, EventArgs e);
    }
}
