using ForceCalculation.Library;
using Microsoft.Extensions.Logging;
using System.Drawing.Printing;
using System.Numerics;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ForceCalculation.WinApp
{
    public partial class Form1 : Form
    {
        private ForceSystem? _forceSystem;
        private DrawingSystem? _drawingSystem;
        private const int MARGIN = 10;
        private const int SCALE = 10;
        private int _forceNameSequence;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetPictureBox();
            SetRichTextBox();
            SetGroupBox();
            SetForceSystem();
            SetDrawingSystem();
        }
        private void SetDrawingSystem()
        {
            _drawingSystem = new DrawingSystem(pictureBox1);
        }
        private void SetForceSystem()
        {
            _forceSystem = new ForceSystem(CreateRichBoxLogger());
            _forceNameSequence = 0;
            SetForceOnCreate();
        }
        private void AddComboBoxItem()
        {
            comboBox1.Items.Add(GetNextForceName());
            _forceNameSequence++;
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }
        private void SetPictureBox()
        {
            pictureBox1.Size = new Size() { Height = ClientSize.Height / 2 - 4 * MARGIN };
        }
        private void SetRichTextBox()
        {
            richTextBox1.Location = new Point(MARGIN, ClientSize.Height / 2 + MARGIN);
            richTextBox1.Size = new Size(ClientSize.Width / 2 - 2 * MARGIN, ClientSize.Height / 2 - 2 * MARGIN);
        }
        private void SetGroupBox()
        {
            groupBox1.Location = new Point(ClientSize.Width / 2 + MARGIN, ClientSize.Height / 2 + MARGIN);
            groupBox1.Size = new Size(ClientSize.Width / 2 - 2 * MARGIN, ClientSize.Height / 2 - 2 * MARGIN);
        }
        private ILogger CreateRichBoxLogger()
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddRichTextBox(richTextBox1));
            return factory.CreateLogger<Form1>();
        }
        private void AddForce(Vector3 start, Vector3 end, int mod)
        {
            if (_forceNameSequence == 1) _drawingSystem?.DrawAxis();
            Force force = new Force(GetLastForceName()!, start, end, mod);
            _forceSystem?.AddForce(force);
            //DrawForce(force);
            SetForceOnCreate();
        }
        private void DrawForce(Force force)
        {
            SharpDX.Vector3 start = new SharpDX.Vector3(force.StartPoint.X / SCALE, force.StartPoint.Y / SCALE, force.StartPoint.Z / SCALE);
            SharpDX.Vector3 end = new SharpDX.Vector3(force.EndPoint.X / SCALE, force.EndPoint.Y / SCALE, force.EndPoint.Z / SCALE);
            _drawingSystem?.DrawVector(start, end, force.Name);
        }
        private void SetForceOnCreate()
        {
            AddComboBoxItem();
            SedDefaultForce();
        }
        private string GetNextForceName() => "F" + _forceNameSequence;
        private string? GetLastForceName() => comboBox1?.Items?[comboBox1.Items.Count - 1]?.ToString();
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SetForceSystem();
        }
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            _forceSystem?.GetDynamic();//..GetMomentum();
        }
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SetForceSystem();
            const int a = 30, b = 40, c = 20, modP1 = 8, modP2 = 4, modP3 = 6, modP4 = 20;
            AddForce(new Vector3(a, 0, 0), new Vector3(0, 0, 0), modP1);
            AddForce(new Vector3(a, 0, c), new Vector3(a, b, c), modP2);
            AddForce(new Vector3(a, b, c), new Vector3(a, b, 0), modP3);
            AddForce(new Vector3(0, 0, c), new Vector3(a, b, c), modP4);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? forceName = comboBox1?.SelectedItem?.ToString();
            if (forceName == null) return;
            Force? force = _forceSystem?.Find(forceName);
            if (force == null)
            {
                SedDefaultForce();
                buttonDelete.Enabled = false;
            }
            else
            {
                SetPoint(textBoxX1, textBoxY1, textBoxZ1, force.StartPoint);
                SetPoint(textBoxX2, textBoxY2, textBoxZ2, force.EndPoint);
                textBoxMod.Text = force.ForceValue.ToString();
                buttonDelete.Enabled = true;
            }
        }
        private void SedDefaultForce()
        {
            SetPoint(textBoxX1, textBoxY1, textBoxZ1, new Vector3(0, 0, 0));
            SetPoint(textBoxX2, textBoxY2, textBoxZ2, new Vector3(0, 0, 0));
            textBoxMod.Text = "0";
        }
        private void SetPoint(TextBox textBoxX, TextBox textBoxY, TextBox textBoxZ, Vector3 point)
        {
            textBoxX.Text = point.X.ToString();
            textBoxY.Text = point.Y.ToString();
            textBoxZ.Text = point.Z.ToString();
        }
        private Vector3 GetPoint(TextBox textBoxX, TextBox textBoxY, TextBox textBoxZ)
        {
            Vector3 point = new Vector3();
            point.X = float.Parse(textBoxX.Text);
            point.Y = float.Parse(textBoxY.Text);
            point.Z = float.Parse(textBoxZ.Text);
            return point;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string name = comboBox1.SelectedItem!.ToString()!;
            _forceSystem?.RemoveForce(name);
            comboBox1.Items.Remove(name);
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Vector3 start = GetPoint(textBoxX1, textBoxY1, textBoxZ1);
            Vector3 end = GetPoint(textBoxX2, textBoxY2, textBoxZ2);
            int mod = int.Parse(textBoxMod.Text);
            AddForce(start, end, mod);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //вперед
                case Keys.Up:
                    _drawingSystem?.MoveCameraUp();
                    break;
                //назад
                case Keys.Down:
                    _drawingSystem?.MoveCameraDown();
                    break;
                case Keys.Left:
                    _drawingSystem?.MoveCameraLeft();
                    break;
                case Keys.Right:
                    _drawingSystem?.MoveCameraRight();
                    break;
                //вращение влево
                case Keys.A:
                    _drawingSystem?.RotateCameraLeft();
                    break;
                //вращение вправо
                case Keys.D:
                    _drawingSystem?.RotateCameraRight();
                    break;
                    //case Keys.W:
                    //    rotationX = 0.1f;
                    //    break;
                    //case Keys.S:
                    //    rotationX = -0.1f;
                    //    break;
            }
        }
    }
}
