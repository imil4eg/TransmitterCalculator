using System;
using System.Collections.Generic;
using System.Drawing;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public sealed class TransmitterService : ITransmitterService
    {
        private const int COORDINATES_ON_LINE_COUNT = 6;

        private readonly ICoordinateCalculator _coordinateCalculator;

        private IList<Transmitter> _transmitters;

        public TransmitterService(ICoordinateCalculator coordinateCalculator)
        {
            _coordinateCalculator = coordinateCalculator ?? throw new ArgumentNullException(nameof(coordinateCalculator));
        }

        public void SetTransmittersLocations(string coordinatesLine)
        {
            if (string.IsNullOrEmpty(coordinatesLine))
            {
                throw new ArgumentNullException(nameof(coordinatesLine));
            }

            string[] coordinatesLineSplitted = coordinatesLine.Split(',');

            if (coordinatesLineSplitted.Length != COORDINATES_ON_LINE_COUNT)
            {
                throw new ArgumentException("Неверное количество координат.");
            }

            for (int coordinateIndex = 0, transmitterIndex = 0; coordinateIndex < coordinatesLineSplitted.Length; coordinateIndex += 2, transmitterIndex++)
            {
                _transmitters[transmitterIndex].OnBoardLocation = new PointF(float.Parse(coordinatesLineSplitted[coordinateIndex]), float.Parse(coordinatesLineSplitted[coordinateIndex + 1]));
                _transmitters[transmitterIndex].Location =
                    _coordinateCalculator.CoordinateToFormLocation(coordinatesLineSplitted[coordinateIndex], coordinatesLineSplitted[coordinateIndex + 1], _transmitters[transmitterIndex]);
            }
        }

        public void SetTransmitters(IList<Transmitter> transmitters)
        {
            if (transmitters == null)
            {
                throw new ArgumentNullException(nameof(transmitters));
            }

            if (transmitters.Count != ApplicationItemsCount.TRANSMITTERS_COUNT)
            {
                throw new ArgumentException("Количество радиоприемников не равно трем.");
            }

            _transmitters = transmitters;
        }

        public IList<Transmitter> GetTransmitters()
        {
            return _transmitters;
        }
    }
}
