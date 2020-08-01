using System;
using System.Collections.Generic;
using TransmitterCalculator.Controls;
using TransmitterCalculator.Settings;

namespace TransmitterCalculator
{
    public sealed class TransmitterService : ITransmitterService
    {
        private const int COORDINATES_ON_LINE_COUNT = 6;

        private readonly ICoordinateCalculator _coordinateCalculator;

        private IList<Transmitter> _transmitters;
        private RadioTransmitter _radioTransmitter;

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
                throw new ArgumentException($"Неверное количество координат. Было предоставлено {coordinatesLineSplitted.Length}, а должно быть {COORDINATES_ON_LINE_COUNT}.");
            }

            for (int coordinateIndex = 0, transmitterIndex = 0; coordinateIndex < coordinatesLineSplitted.Length; coordinateIndex += 2, transmitterIndex++)
            {
                double xD;
                if (!double.TryParse(coordinatesLineSplitted[coordinateIndex], out xD))
                {
                    throw new ArgumentException($"Неверный формат координаты {coordinatesLineSplitted[coordinateIndex]}");
                }
                else if (xD > CoordinateSystemSettings.Instance.MaxXCoordinate || xD < CoordinateSystemSettings.Instance.MinXCoordinate)
                {
                    throw new ArgumentOutOfRangeException($"{xD} не входит в диапозон допустимых значений для координаты Х." +
                        $" Значение для X координат должно быть от {CoordinateSystemSettings.Instance.MinXCoordinate} до {CoordinateSystemSettings.Instance.MaxXCoordinate}");
                }

                double yD;
                if (!double.TryParse(coordinatesLineSplitted[coordinateIndex + 1], out yD))
                {
                    throw new ArgumentException($"Неверный формат координаты {coordinatesLineSplitted[coordinateIndex + 1]}");
                }
                else if (yD > CoordinateSystemSettings.Instance.MaxYCoordiante || yD < CoordinateSystemSettings.Instance.MinYCoordinate)
                {
                    throw new ArgumentOutOfRangeException($"{yD} не входит в диапозон допустимых значений для координаты Y. " +
                        $"Значение для Y координат должно быть от {CoordinateSystemSettings.Instance.MinYCoordinate} до {CoordinateSystemSettings.Instance.MaxYCoordiante}");
                }

                _transmitters[transmitterIndex].OnBoardLocation = new PointD(xD, yD);
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

        public void SetRadioTransmitter(RadioTransmitter radioTransmitter)
        {
            if (radioTransmitter == null)
            {
                throw new ArgumentNullException(nameof(radioTransmitter));
            }

            _radioTransmitter = radioTransmitter;
        }

        public RadioTransmitter GetRadioTransmitter()
        {
            return _radioTransmitter;
        }
    }
}
