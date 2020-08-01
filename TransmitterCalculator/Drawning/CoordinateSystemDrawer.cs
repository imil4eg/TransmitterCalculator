using System;
using System.Collections.Generic;
using System.Drawing;
using TransmitterCalculator.Controls;
using TransmitterCalculator.Settings;

namespace TransmitterCalculator.Drawning
{
    public sealed class CoordinateSystemDrawer : ICoordinateSystemDrawer
    {
        private readonly ICoordinateCalculator _coordinateCalculator;
        private readonly ITransmitterService _transmitterService;

        public CoordinateSystemDrawer(ICoordinateCalculator coordinateCalculator, 
            ITransmitterService transmitterService)
        {
            _coordinateCalculator = coordinateCalculator;
            _transmitterService = transmitterService;
        }

        public void Draw(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            using (var grayPen = new Pen(Color.Gray, 3))
            {
                for (int i = 0; i < CoordinateSystemSettings.Instance.BoardWidth; i += UnitSize.UNIT_WIDTH)
                {
                    for (int j = CoordinateSystemSettings.Instance.XZeroPointCooridnate; j > 0; j -= UnitSize.UNIT_WIDTH)
                    {
                        graphics.DrawRectangle(grayPen, j, i, UnitSize.UNIT_WIDTH, UnitSize.UNIT_WIDTH);
                    }
                }

                for (int i = 0; i < CoordinateSystemSettings.Instance.BoardHeight; i += UnitSize.UNIT_WIDTH)
                {
                    for (int j = CoordinateSystemSettings.Instance.XZeroPointCooridnate; j < CoordinateSystemSettings.Instance.BoardWidth; j += UnitSize.UNIT_WIDTH)
                    {
                        graphics.DrawRectangle(grayPen, j, i, UnitSize.UNIT_WIDTH, UnitSize.UNIT_WIDTH);
                    }
                }
            }

            using (var redPen = new Pen(Color.Red, 3))
            {
                graphics.DrawLine(redPen, 0, CoordinateSystemSettings.Instance.YZeroPointCoordinate, CoordinateSystemSettings.Instance.BoardWidth, CoordinateSystemSettings.Instance.YZeroPointCoordinate);
                graphics.DrawLine(redPen, CoordinateSystemSettings.Instance.XZeroPointCooridnate, 0, CoordinateSystemSettings.Instance.XZeroPointCooridnate, CoordinateSystemSettings.Instance.BoardHeight);
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
                RadioTransmitter radioTransmitter = _transmitterService.GetRadioTransmitter();
                Point radioTransimitterLocation = _coordinateCalculator.CalculateControlMiddle(radioTransmitter);
                foreach (var transmitter in _transmitterService.GetTransmitters())
                {
                    Point transmitterLocation = _coordinateCalculator.CalculateControlMiddle(transmitter);
                    graphics.DrawLine(bluePen, radioTransimitterLocation, transmitterLocation);
                }
            }
        }
    }
}
