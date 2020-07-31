using System.Windows.Forms;
using System.Linq;
using TransmitterCalculator.Controls;
using System;
using System.IO;
using TransmitterCalculator.Drawning;

namespace TransmitterCalculator
{
    public partial class MainForm : Form
    {
        private readonly ICoordinateSystem _coordinateSystem;
        private readonly Drawning.ICoordinateSystemDrawer _coordinateSystemDrawer;

        public MainForm(ICoordinateSystem coordinateSystem, Drawning.ICoordinateSystemDrawer coordinateSystemDrawer)
        {
            InitializeComponent();

            _coordinateSystemDrawer = coordinateSystemDrawer ?? throw new ArgumentNullException(nameof(coordinateSystemDrawer));
            _coordinateSystem = coordinateSystem ?? throw new ArgumentNullException(nameof(coordinateSystem));
            var transmitters = this.Controls.Cast<Control>().Where(c => c is Transmitter).Select(c => (Transmitter)c).ToArray();
            var radioTransmitter = (RadioTransmitter)this.Controls.Cast<Control>().FirstOrDefault(c => c is RadioTransmitter);
            _coordinateSystem.Initialize(transmitters, radioTransmitter, this.Width, this.Height);
            _coordinateSystemDrawer.Initialize(transmitters, radioTransmitter, this.Width, this.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!IsFullFormReload(e.ClipRectangle.Width))
            {
                this.Refresh();
            }

            _coordinateSystemDrawer.Draw(e.Graphics);
        }

        private bool IsFullFormReload(int width)
        {
            return width >= this.Width - 100;
        }

        private void SaveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransmitterTimer.Enabled = false;

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string result = _coordinateSystem.GetRadioTransmitterLocationsAsString();
                    File.WriteAllText(saveFileDialog.FileName, result);
                }
            }
        }

        private void UploadInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                openFileDialog.Title = "Выберите входной файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _coordinateSystem.ProcessInputFile(openFileDialog.FileName);
                }
            }
        }

        private void StartSignalTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TransmitterTimer.Enabled = true;
            this.TransmitterTimer.Tick += _coordinateSystem.CalculateRadioTransmitterLocationEvent;
        }
    }
}
