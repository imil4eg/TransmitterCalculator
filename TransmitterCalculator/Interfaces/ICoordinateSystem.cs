using System;
using System.Collections.Generic;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public interface ICoordinateSystem
    {
        void ProcessInputFile(string inputFile);
        string GetRadioTransmitterLocationsAsString();
        void CalculateRadioTransmitterLocationEvent(object sender, EventArgs e);
    }
}
