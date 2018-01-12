using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using System.Speech.Synthesis;
using System.IO;

namespace OCR_Tessaract
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speechSynthesiz;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                speechSynthesiz = new SpeechSynthesizer();
                //var img = new Bitmap(openfile.FileName);
                //var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                //var page = ocr.Process(img);
                pictureBox1.Image = Image.FromFile(openfile.FileName);

                var img = new Bitmap(openfile.FileName);
                var ocr = new TesseractEngine("./tessdata", "ben", EngineMode.Default);
                var page = ocr.Process(img);

                textBox1.Text = page.GetText();
                speechSynthesiz.SelectVoiceByHints(VoiceGender.Female);
                speechSynthesiz.SpeakAsync(textBox1.Text);
            }
    
        }
    }
}
