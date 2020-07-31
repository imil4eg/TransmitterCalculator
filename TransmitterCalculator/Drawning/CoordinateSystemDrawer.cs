using System;
using System.Collections.Generic;
using System.Drawing;
using TransmitterCalculator.Controls;

namespace TransmitterCalculator.Drawning
{
    public sealed class CoordinateSystemDrawer : ICoordinateSystemDrawer
    {
        private readonly ICoordinateCalculator _coordinateCalculator;

        private IEnumerable<Transmitter> _transmitters;
        private RadioTransmitter _radioTransmitter;
        private int _width;
        private int _height;

        public CoordinateSystemDrawer(ICoordinateCalculator coordinateCalculator)
        {
            _coordinateCalculator = coordinateCalculator;
        }

        public void Initialize(IEnumerable<Transmitter> transmitters, RadioTransmitter radioTransmitter, int width, int height)
        {
            if (transmitters == null)
            {
                throw new ArgumentNullException(nameof(transmitters));
            }

            if (radioTransmitter == null)
            {
                throw new ArgumentNullException(nameof(radioTransmitter));
            }

            _transmitters = transmitters;
            _radioTransmitter = radioTransmitter;
            _width = width;
            _height = height;
        }

        public void Draw(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            int widthMiddle = _width / 2;
            int heightMiddle = _height / 2;

            using (var grayPen = new Pen(Color.Gray, 3))
            {
                for (int i = 0; i < _width; i += UnitSize.UNIT_WIDTH)
                {
                    for (int j = widthMiddle; j > 0; j -= UnitSize.UNIT_WIDTH)
                    {
                        graphics.DrawRectangle(grayPen, j, i, UnitSize.UNIT_WIDTH, UnitSize.UNIT_WIDTH);
                    }
                }

                for (int i = 0; i < _height; i += UnitSize.UNIT_WIDTH)
                {
                    for (int j = widthMiddle; j < _width; j += UnitSize.UNIT_WIDTH)
                    {
                        graphics.DrawRectangle(grayPen, j, i, UnitSize.UNIT_WIDTH, UnitSize.UNIT_WIDTH);
                    }
                }
            }

            using (var redPen = new Pen(Color.Red, 3))
            {
                graphics.DrawLine(redPen, 0, heightMiddle, _width, heightMiddle);
                graphics.DrawLine(redPen, widthMiddle, 0, widthMiddle, _height);
            }

            DrawLineToTransmitters(graphics);
        }

        public void DrawLineToTransmitters(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            using (var bluePen = new Pen(Color.Blue, 3))
            {
                Point radioTransimitterLocation = _coordinateCalculator.CalculateControlMiddle(_radioTransmitter);
                foreach (var transmitter in _transmitters)
                {
                    Point transmitterLocation = _coordinateCalculator.CalculateControlMiddle(transmitter);
                    graphics.DrawLine(bluePen, radioTransimitterLocation, transmitterLocation);
                }
            }
        }
    }
}
