using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator
{
    public class CoordinateSystem : ICoordinateSystem
    {
        private const string RADIO_TRANSMITTER_COORDINATE_FORMAT = "0.00000000";
        private const int TRANSMITTERS_COORDINATES_IN_INPUT_FILE_LINE_INDEX = 0;
        private const int TRANSMITTERS_COORDINATES_IN_INPUT_FILE_COUNT = 1;

        private readonly ICoordinateCalculator _coordinateCalculator;
        private readonly ITransmitterService _transmitterService;
        private readonly Queue<IList<float>> _inputTime;
        private readonly Queue<PointD> _radioTransmitterCoordinates;

        private RadioTransmitter _radioTransmitter;

        public CoordinateSystem(ITransmitterService transmitterService,
            ICoordinateCalculator coordinateCalculator)
        {
            _transmitterService = transmitterService ?? throw new ArgumentNullException(nameof(transmitterService));
            _coordinateCalculator = coordinateCalculator ?? throw new ArgumentNullException(nameof(coordinateCalculator));

            _inputTime = new Queue<IList<float>>();
            _radioTransmitterCoordinates = new Queue<PointD>();
        }

        public void Initialize(IList<Transmitter> transmitters, RadioTransmitter radioTransmitter, int windowWidth, int windowHeight)
        {
            if (transmitters == null)
            {
                throw new ArgumentNullException(nameof(transmitters));
            }

            if (radioTransmitter == null)
            {
                throw new ArgumentNullException(nameof(radioTransmitter));
            }

            if (transmitters.Count != ApplicationItemsCount.TRANSMITTERS_COUNT)
            {
                throw new ArgumentException("Количество радиоприемников не равно трем.");
            }

            _transmitterService.SetTransmitters(transmitters);
            _coordinateCalculator.SetWindowParameters(windowWidth, windowHeight);
            _radioTransmitter = radioTransmitter;
        }

        public void ProcessInputFile(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException($"Файл {inputFile} не найден.");
            }

            string[] fileLines = File.ReadAllLines(inputFile);

            if (fileLines.Length == 0)
            {
                throw new FileLoadException("Файл не содержит данных.");
            }

            _transmitterService.SetTransmittersLocations(fileLines[TRANSMITTERS_COORDINATES_IN_INPUT_FILE_LINE_INDEX]);
            SetSignalArrivalTimes(fileLines.Skip(TRANSMITTERS_COORDINATES_IN_INPUT_FILE_COUNT));
        }

        public void CalculateRadioTransmitterLocationEvent(object sender, EventArgs e)
        {
            if (_inputTime.Count == 0)
            {
                return;
            }

            IList<Transmitter> transmitters = _transmitterService.GetTransmitters();
            IList<float> times = _inputTime.Dequeue();

            PointD radioTransmitterOnBoardLocation = _coordinateCalculator.CalculateRadioTransmitterOnBoardCoordinates(times, transmitters);
            _radioTransmitterCoordinates.Enqueue(radioTransmitterOnBoardLocation);

            _radioTransmitter.Location =
                _coordinateCalculator.CoordinateToFormLocation(radioTransmitterOnBoardLocation.X, radioTransmitterOnBoardLocation.Y, _radioTransmitter);
        }

        public string GetRadioTransmitterLocationsAsString()
        {
            var sb = new StringBuilder();
            while (_radioTransmitterCoordinates.Count != 0)
            {
                var location = _radioTransmitterCoordinates.Dequeue();
                sb.AppendLine(location.X.ToString(RADIO_TRANSMITTER_COORDINATE_FORMAT) + "," + location.Y.ToString(RADIO_TRANSMITTER_COORDINATE_FORMAT));
            }

            return sb.ToString();
        }

        private void SetSignalArrivalTimes(IEnumerable<string> arrivalTimesLines)
        {
            foreach (string arrivalTimesLine in arrivalTimesLines)
            {
                _inputTime.Enqueue(arrivalTimesLine.Split(',').Select(t => float.Parse(t)).ToArray());
            }
        }
    }
}
