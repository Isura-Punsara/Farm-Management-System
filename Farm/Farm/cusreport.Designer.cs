namespace Farm
{
    partial class cusreport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uclink = new System.Windows.Forms.LinkLabel();
            this.hislink = new System.Windows.Forms.LinkLabel();
            this.costs = new System.Windows.Forms.LinkLabel();
            this.fdlink = new System.Windows.Forms.LinkLabel();
            this.replink = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.loadbtn = new System.Windows.Forms.Button();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.srep = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.erep = new System.Windows.Forms.LinkLabel();
            this.frep = new System.Windows.Forms.LinkLabel();
            this.cdgv = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1344, 120);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(331, 74);
            this.label3.TabIndex = 7;
            this.label3.Text = "Eastern Agro\r\nProducts Developers\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Honeydew;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Farm.Properties.Resources.Long_image_11_24_2024_16_19__2_;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(2, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 543);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.uclink);
            this.panel3.Controls.Add(this.hislink);
            this.panel3.Controls.Add(this.costs);
            this.panel3.Controls.Add(this.fdlink);
            this.panel3.Controls.Add(this.replink);
            this.panel3.Location = new System.Drawing.Point(4, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 478);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // uclink
            // 
            this.uclink.AutoSize = true;
            this.uclink.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uclink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.uclink.LinkColor = System.Drawing.Color.Black;
            this.uclink.Location = new System.Drawing.Point(18, 402);
            this.uclink.Name = "uclink";
            this.uclink.Size = new System.Drawing.Size(125, 19);
            this.uclink.TabIndex = 4;
            this.uclink.TabStop = true;
            this.uclink.Text = " • User Controls";
            this.uclink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.uclink_LinkClicked);
            // 
            // hislink
            // 
            this.hislink.AutoSize = true;
            this.hislink.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hislink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.hislink.LinkColor = System.Drawing.Color.Black;
            this.hislink.Location = new System.Drawing.Point(18, 314);
            this.hislink.Name = "hislink";
            this.hislink.Size = new System.Drawing.Size(134, 19);
            this.hislink.TabIndex = 3;
            this.hislink.TabStop = true;
            this.hislink.Text = " • Historical Data";
            this.hislink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hislink_LinkClicked);
            // 
            // costs
            // 
            this.costs.AutoSize = true;
            this.costs.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.costs.LinkColor = System.Drawing.Color.Black;
            this.costs.Location = new System.Drawing.Point(18, 225);
            this.costs.Name = "costs";
            this.costs.Size = new System.Drawing.Size(129, 19);
            this.costs.TabIndex = 2;
            this.costs.TabStop = true;
            this.costs.Text = " • Monitor Costs";
            this.costs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.costs_LinkClicked);
            // 
            // fdlink
            // 
            this.fdlink.AutoSize = true;
            this.fdlink.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdlink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.fdlink.LinkColor = System.Drawing.Color.Black;
            this.fdlink.Location = new System.Drawing.Point(18, 137);
            this.fdlink.Name = "fdlink";
            this.fdlink.Size = new System.Drawing.Size(130, 19);
            this.fdlink.TabIndex = 1;
            this.fdlink.TabStop = true;
            this.fdlink.Text = " • Financial Data";
            this.fdlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.fdlink_LinkClicked);
            // 
            // replink
            // 
            this.replink.AutoSize = true;
            this.replink.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.replink.LinkColor = System.Drawing.Color.Black;
            this.replink.Location = new System.Drawing.Point(18, 54);
            this.replink.Name = "replink";
            this.replink.Size = new System.Drawing.Size(82, 19);
            this.replink.TabIndex = 0;
            this.replink.TabStop = true;
            this.replink.Text = " • Reports";
            this.replink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.replink_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(311, 127);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1021, 542);
            this.panel4.TabIndex = 11;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.loadbtn);
            this.panel5.Controls.Add(this.cb1);
            this.panel5.Controls.Add(this.srep);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.erep);
            this.panel5.Controls.Add(this.frep);
            this.panel5.Controls.Add(this.cdgv);
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1014, 535);
            this.panel5.TabIndex = 0;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // loadbtn
            // 
            this.loadbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.loadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadbtn.Location = new System.Drawing.Point(254, 49);
            this.loadbtn.Name = "loadbtn";
            this.loadbtn.Size = new System.Drawing.Size(155, 29);
            this.loadbtn.TabIndex = 34;
            this.loadbtn.Text = "Load Report";
            this.loadbtn.UseVisualStyleBackColor = false;
            this.loadbtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // cb1
            // 
            this.cb1.FormattingEnabled = true;
            this.cb1.Items.AddRange(new object[] {
            "Environmental Report",
            "Breeding Report",
            "Inventory Report",
            "Health Report",
            "Feed Report"});
            this.cb1.Location = new System.Drawing.Point(52, 54);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(196, 21);
            this.cb1.TabIndex = 33;
            // 
            // srep
            // 
            this.srep.AutoSize = true;
            this.srep.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srep.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.srep.LinkColor = System.Drawing.Color.Black;
            this.srep.Location = new System.Drawing.Point(334, 12);
            this.srep.Name = "srep";
            this.srep.Size = new System.Drawing.Size(126, 19);
            this.srep.TabIndex = 32;
            this.srep.TabStop = true;
            this.srep.Text = "Supplier Report";
            this.srep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.srep_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(314, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "|";
            // 
            // erep
            // 
            this.erep.AutoSize = true;
            this.erep.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erep.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.erep.LinkColor = System.Drawing.Color.Black;
            this.erep.Location = new System.Drawing.Point(169, 12);
            this.erep.Name = "erep";
            this.erep.Size = new System.Drawing.Size(139, 19);
            this.erep.TabIndex = 29;
            this.erep.TabStop = true;
            this.erep.Text = "Employee Report";
            this.erep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.erep_LinkClicked);
            // 
            // frep
            // 
            this.frep.AutoSize = true;
            this.frep.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frep.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.frep.LinkColor = System.Drawing.Color.Black;
            this.frep.Location = new System.Drawing.Point(13, 12);
            this.frep.Name = "frep";
            this.frep.Size = new System.Drawing.Size(130, 19);
            this.frep.TabIndex = 28;
            this.frep.TabStop = true;
            this.frep.Text = "Financial Report";
            this.frep.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.frep_LinkClicked);
            // 
            // cdgv
            // 
            this.cdgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdgv.BackgroundColor = System.Drawing.Color.Gray;
            this.cdgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cdgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cdgv.Location = new System.Drawing.Point(52, 81);
            this.cdgv.Name = "cdgv";
            this.cdgv.Size = new System.Drawing.Size(908, 439);
            this.cdgv.TabIndex = 11;
            this.cdgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cdgv_CellClick);
            // 
            // cusreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Farm.Properties.Resources._1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1344, 681);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "cusreport";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.cusreport_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel uclink;
        private System.Windows.Forms.LinkLabel hislink;
        private System.Windows.Forms.LinkLabel costs;
        private System.Windows.Forms.LinkLabel fdlink;
        private System.Windows.Forms.LinkLabel replink;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView cdgv;
        private System.Windows.Forms.LinkLabel srep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel erep;
        private System.Windows.Forms.LinkLabel frep;
        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.Button loadbtn;
    }
}