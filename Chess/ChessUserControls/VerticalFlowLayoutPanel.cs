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

    
    public partial class VerticalFlowLayoutPanel : UserControl
    {
        public VerticalFlowLayoutPanel()
        {
            InitializeComponent();
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[8];
            this.Controls.Add(flowPanel);
            this.set_flowlayoutpanel_parameters(flowPanel);
            this.create_vertical_flowlayoutpanel_of_labels(flowPanel);
        }

        public void set_labels_parameters(System.Windows.Forms.Label label, string name)
        {
            label.MinimumSize = new Size(80, 80);
            label.MaximumSize = new Size(80, 80);
            label.Margin = new Padding(0, 0, 0, 1);
            label.Text = name;
            label.Font = new Font ("Arial",10,FontStyle.Regular);
            label.Dock = DockStyle.Fill;
            label.Visible = true;
            label.TextAlign = ContentAlignment.MiddleCenter; 
            label.BorderStyle = BorderStyle.FixedSingle;
            label.BackColor = Color.White;


        }
        public void set_flowlayoutpanel_parameters(FlowLayoutPanel flowPanel)
        {
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.Size = new Size(65, 600);
            flowPanel.WrapContents = false;
            flowPanel.BackColor = Color.Transparent;
        }
        public void create_vertical_flowlayoutpanel_of_labels(FlowLayoutPanel flowPanel)
        {
            for (int i = 0; i < 8; i++)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();              
                label.Margin = new Padding(0, 0, 0, 1);
                this.set_labels_parameters(label, (i+1).ToString());
                flowPanel.Controls.Add(label);
            }
        }

    }

}