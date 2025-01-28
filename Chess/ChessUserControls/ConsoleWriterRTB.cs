using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Reflection.Emit;

namespace ChessUserControls
{
    public partial class ConsoleWriterRTB : UserControl
    {
        private RichTextBox richTextBox1;

        public ConsoleWriterRTB()
        {
            InitializeComponent();
            Console.SetOut(new ControlWriter(this.richTextBox1));
            this.richTextBox1.TextChanged += new EventHandler(RichTextBox_TextChanged);
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ensure that the scroll moves down when the text is updated
            this.richTextBox1.ScrollToCaret();
        }
        class ControlWriter : TextWriter
        {
            RichTextBox output = null;

            public ControlWriter(RichTextBox output)
            {
                this.output = output;
            }

            public override void Write(char value)
            {
                base.Write(value);
                output.AppendText(value.ToString());
            }

            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }
        }

        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Arial", 10F);
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(286, 563);
            richTextBox1.TabIndex = 0;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = "GAME BEGINS\n\nWhite player, make your move.\n\n";
            // 
            // ConsoleWriterRTB
            // 
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(richTextBox1);
            Name = "ConsoleWriterRTB";
            Size = new Size(286, 563);
            ResumeLayout(false);
        }
    }
}
