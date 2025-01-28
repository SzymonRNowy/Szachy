using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessUserControls
{
    public partial class HorizontalFlowLayoutPanel : UserControl
    {
        public HorizontalFlowLayoutPanel()
        {
            InitializeComponent();
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label [8];
            this.Controls.Add(flowPanel);
            this.set_flowlayoutpanel_parameters(flowPanel);
            this.create_horizontal_flowlayoutpanel_of_labels(flowPanel);
        }

        public void set_label_parameters(System.Windows.Forms.Label label)
        {
            label.MinimumSize = new Size(80, 80);
            label.MaximumSize = new Size(80, 80);
            label.Text = label.Name.Substring(label.Name.Length - 1);
            label.Dock = DockStyle.Left;
            label.Font = new Font("Arial", 10, FontStyle.Regular);
            label.Visible = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.FixedSingle; // Optional
            label.BackColor = Color.White;
        }

        public void set_flowlayoutpanel_parameters(FlowLayoutPanel flowPanel)
        {
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.Size = new Size(600, 65);
        }
        public void create_horizontal_flowlayoutpanel_of_labels(FlowLayoutPanel flowPanel)
        {
            for (int i = 0; i < 8; i++)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();  
                label.Name = "Label " + (char)(i + 65);
                label.Margin = new Padding(0,0,3,0);
                this.set_label_parameters(label);
                flowPanel.Controls.Add(label);
            }
        }

    }
}
