namespace Electric
{
    partial class from_partner_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(from_partner_list));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.boolBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolBtnModify = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolBtnClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtOrgCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUP = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boolBtnAdd,
            this.toolBtnModify,
            this.toolBtnSave,
            this.toolBtnDelete,
            this.toolBtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(997, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // boolBtnAdd
            // 
            this.boolBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("boolBtnAdd.Image")));
            this.boolBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boolBtnAdd.Name = "boolBtnAdd";
            this.boolBtnAdd.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.boolBtnAdd.Size = new System.Drawing.Size(72, 22);
            this.boolBtnAdd.Text = "增加";
            this.boolBtnAdd.Click += new System.EventHandler(this.boolBtnAdd_Click);
            // 
            // toolBtnModify
            // 
            this.toolBtnModify.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnModify.Image")));
            this.toolBtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnModify.Name = "toolBtnModify";
            this.toolBtnModify.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolBtnModify.Size = new System.Drawing.Size(72, 22);
            this.toolBtnModify.Text = "修改";
            this.toolBtnModify.Click += new System.EventHandler(this.toolBtnModify_Click);
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSave.Image")));
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolBtnSave.Size = new System.Drawing.Size(72, 22);
            this.toolBtnSave.Text = "保存";
            this.toolBtnSave.Visible = false;
            // 
            // toolBtnDelete
            // 
            this.toolBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnDelete.Image")));
            this.toolBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDelete.Name = "toolBtnDelete";
            this.toolBtnDelete.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolBtnDelete.Size = new System.Drawing.Size(72, 22);
            this.toolBtnDelete.Text = "删除";
            this.toolBtnDelete.Click += new System.EventHandler(this.toolBtnDelete_Click);
            // 
            // toolBtnClose
            // 
            this.toolBtnClose.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnClose.Image")));
            this.toolBtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnClose.Name = "toolBtnClose";
            this.toolBtnClose.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolBtnClose.Size = new System.Drawing.Size(72, 22);
            this.toolBtnClose.Text = "关闭";
            this.toolBtnClose.ToolTipText = "关闭当前窗口";
            this.toolBtnClose.Click += new System.EventHandler(this.toolBtnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtOrgCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(997, 68);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtOrgCode
            // 
            this.txtOrgCode.Location = new System.Drawing.Point(439, 27);
            this.txtOrgCode.Name = "txtOrgCode";
            this.txtOrgCode.Size = new System.Drawing.Size(100, 21);
            this.txtOrgCode.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "组织机构代码";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(242, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "名称";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(66, 27);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 21);
            this.txtCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代码";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 99);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(973, 340);
            this.dgv.TabIndex = 9;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(910, 445);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "下一页";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUP
            // 
            this.btnUP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUP.Location = new System.Drawing.Point(829, 445);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(75, 23);
            this.btnUP.TabIndex = 12;
            this.btnUP.Text = "上一页";
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // from_partner_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 469);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUP);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "from_partner_list";
            this.Text = "from_partner_list";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton boolBtnAdd;
        protected System.Windows.Forms.ToolStripButton toolBtnModify;
        protected System.Windows.Forms.ToolStripButton toolBtnSave;
        protected System.Windows.Forms.ToolStripButton toolBtnDelete;
        private System.Windows.Forms.ToolStripButton toolBtnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtOrgCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUP;
    }
}