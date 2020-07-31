using System.Collections.Generic;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public interface ITransmitterService
    {
        IList<Transmitter> GetTransmitters();
        void SetTransmitters(IList<Transmitter> transmitters);
        void SetTransmittersLocations(string coordinatesLine);
    }
}
