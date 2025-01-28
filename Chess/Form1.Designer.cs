
namespace Chess
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            consoleWriterRTB1 = new ChessUserControls.ConsoleWriterRTB();
            chessBoard2 = new ChessUserControls.ChessBoard();
            verticalFlowLayoutPanel1 = new ChessUserControls.VerticalFlowLayoutPanel();
            horizontalFlowLayoutPanel1 = new ChessUserControls.HorizontalFlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.White;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Location = new System.Drawing.Point(30, 24);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.MaximumSize = new System.Drawing.Size(287, 75);
            label1.MinimumSize = new System.Drawing.Size(287, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(287, 75);
            label1.TabIndex = 3;
            label1.Text = "MOVEMENT LOG";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // consoleWriterRTB1
            // 
            consoleWriterRTB1.BackColor = System.Drawing.Color.White;
            consoleWriterRTB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            consoleWriterRTB1.Location = new System.Drawing.Point(30, 107);
            consoleWriterRTB1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            consoleWriterRTB1.Name = "consoleWriterRTB1";
            consoleWriterRTB1.Size = new System.Drawing.Size(286, 563);
            consoleWriterRTB1.TabIndex = 8;
            // 
            // chessBoard2
            // 
            chessBoard2.BackColor = System.Drawing.Color.White;
            chessBoard2.Location = new System.Drawing.Point(436, 22);
            chessBoard2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            chessBoard2.Name = "chessBoard2";
            chessBoard2.Size = new System.Drawing.Size(660, 648);
            chessBoard2.TabIndex = 7;
            // 
            // verticalFlowLayoutPanel1
            // 
            verticalFlowLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
            verticalFlowLayoutPanel1.Location = new System.Drawing.Point(337, 22);
            verticalFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            verticalFlowLayoutPanel1.Name = "verticalFlowLayoutPanel1";
            verticalFlowLayoutPanel1.Size = new System.Drawing.Size(83, 699);
            verticalFlowLayoutPanel1.TabIndex = 5;
            // 
            // horizontalFlowLayoutPanel1
            // 
            horizontalFlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            horizontalFlowLayoutPanel1.Location = new System.Drawing.Point(436, 687);
            horizontalFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            horizontalFlowLayoutPanel1.Name = "horizontalFlowLayoutPanel1";
            horizontalFlowLayoutPanel1.Size = new System.Drawing.Size(717, 92);
            horizontalFlowLayoutPanel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DimGray;
            ClientSize = new System.Drawing.Size(1136, 800);
            Controls.Add(consoleWriterRTB1);
            Controls.Add(chessBoard2);
            Controls.Add(verticalFlowLayoutPanel1);
            Controls.Add(horizontalFlowLayoutPanel1);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            Text = "ChessGame";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ChessUserControls.HorizontalFlowLayoutPanel horizontalFlowLayoutPanel1;
        private ChessUserControls.ChessBoard chessBoard2;
        private ChessUserControls.VerticalFlowLayoutPanel verticalFlowLayoutPanel1;
        private ChessUserControls.ConsoleWriterRTB consoleWriterRTB1;
    }
}

