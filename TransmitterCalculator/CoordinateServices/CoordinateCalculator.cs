using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TransmitterCalculator.Controls;
using TransmitterCalculator.Settings;

namespace TransmitterCalculator
{
    public sealed class CoordinateCalculator : ICoordinateCalculator
    {
        private const int SIGNAL_SPEED = 1000000;
        private const int ARRIVAL_TIME_PER_LINE_IN_INPUT_FILE_COUNT = 3;

        public Point CoordinateToFormLocation(string x, string y, Control control)
        {
            if (string.IsNullOrEmpty(x))
            {
                throw new ArgumentNullException(nameof(x));
            }

            if (string.IsNullOrEmpty(y))
            {

                throw new ArgumentNullException(nameof(y));
            }

            double xF;
            if (!double.TryParse(x, out xF))
            {
                throw new ArgumentException("Аргумент x не целочисленного типа");
            }

            double yF;
            if (!double.TryParse(y, out yF))
            {
                throw new ArgumentException("Аргумент y не целочисленного типа");
            }

            return CoordinateToFormLocation(xF, yF, control);
        }

        public Point CoordinateToFormLocation(double x, double y, Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            int xCoordinateZeroPoint = CoordinateSystemSettings.Instance.BoardWidth / 2;
            int yCoordinateZeroPoint = CoordinateSystemSettings.Instance.BoardHeight / 2;
            
            var location = new Point
            {
                X = (int)(xCoordinateZeroPoint + (x * UnitSize.UNIT_WIDTH) - (control.Width / 2)),
                Y = (int)(yCoordinateZeroPoint - (y * UnitSize.UNIT_WIDTH)) - (control.Height / 2)
            };

            return location;
        }

        public PointD CalculateRadioTransmitterOnBoardCoordinates(IList<float> time, IList<Transmitter> transmitters)
        {
            if (time == null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            if (time.Count != ARRIVAL_TIME_PER_LINE_IN_INPUT_FILE_COUNT)
            {
                throw new ArgumentException("Неверное количество времен за которые сигнал дошел до радиоприемников.");
            }

            if (transmitters == null)
            {
                throw new ArgumentNullException(nameof(transmitters));
            }

            if (transmitters.Count != ApplicationItemsCount.TRANSMITTERS_COUNT)
            {
                throw new ArgumentException("Неверное количество радиоприемников.");
            }

            double r1 = CalculateRange(time[0]);
            double r2 = CalculateRange(time[1]);
            double r3 = CalculateRange(time[2]);

            double x1 = transmitters[0].OnBoardLocation.X;
            double y1 = transmitters[0].OnBoardLocation.Y;
            double x2 = transmitters[1].OnBoardLocation.X;
            double y2 = transmitters[1].OnBoardLocation.Y;
            double x3 = transmitters[2].OnBoardLocation.X;
            double y3 = transmitters[2].OnBoardLocation.Y;
            double x = ((y2 - y1) * (r2 * r2 - r3 * r3 - y2 * y2 + y3 * y3 - x2 * x2 + x3 * x3) - (y3 - y2) * (r1 * r1 - r2 * r2 - y1 * y1 + y2 * y2 - x1 * x1 + x2 * x2)) / (2 * ((y3 - y2) * (x1 - x2) - (y2 - y1) * (x2 - x3)));
            double y = ((x2 - x1) * (r2 * r2 - r3 * r3 - x2 * x2 + x3 * x3 - y2 * y2 + y3 * y3) - (x3 - x2) * (r1 * r1 - r2 * r2 - x1 * x1 + x2 * x2 - y1 * y1 + y2 * y2)) / (2 * ((x3 - x2) * (y1 - y2) - (x2 - x1) * (y2 - y3)));

            return new PointD(x, y);
        }

        public float CalculateRange(float time)
        {
            return time * SIGNAL_SPEED;
        }

        public Point CalculateControlMiddle(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            var point = new Point
            {
                X = control.Location.X + (control.Width / 2),
                Y = control.Location.Y + (control.Height / 2)
            };

            return point;
        }
    }
}
