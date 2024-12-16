
namespace CStat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            gbStatMode = new GroupBox();
            rbCeiling = new RadioButton();
            rbWall = new RadioButton();
            rbSprite = new RadioButton();
            gbEntryMode = new GroupBox();
            rbBinary = new RadioButton();
            rbHex = new RadioButton();
            rbDecimal = new RadioButton();
            tbValue = new TextBox();
            label1 = new Label();
            btCalc = new Button();
            LV = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            rtbInfo = new RichTextBox();
            toolTip1 = new ToolTip(components);
            btClear = new Button();
            gbStatMode.SuspendLayout();
            gbEntryMode.SuspendLayout();
            SuspendLayout();
            // 
            // gbStatMode
            // 
            gbStatMode.Controls.Add(rbCeiling);
            gbStatMode.Controls.Add(rbWall);
            gbStatMode.Controls.Add(rbSprite);
            gbStatMode.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbStatMode.Location = new Point(22, 26);
            gbStatMode.Name = "gbStatMode";
            gbStatMode.Size = new Size(249, 64);
            gbStatMode.TabIndex = 0;
            gbStatMode.TabStop = false;
            gbStatMode.Text = "Mode";
            // 
            // rbCeiling
            // 
            rbCeiling.AutoSize = true;
            rbCeiling.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbCeiling.Location = new Point(133, 28);
            rbCeiling.Name = "rbCeiling";
            rbCeiling.Size = new Size(105, 21);
            rbCeiling.TabIndex = 2;
            rbCeiling.TabStop = true;
            rbCeiling.Text = "Ceiling/floor";
            rbCeiling.UseVisualStyleBackColor = true;
            rbCeiling.CheckedChanged += rbCeiling_CheckedChanged;
            // 
            // rbWall
            // 
            rbWall.AutoSize = true;
            rbWall.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbWall.Location = new Point(74, 28);
            rbWall.Name = "rbWall";
            rbWall.Size = new Size(53, 21);
            rbWall.TabIndex = 1;
            rbWall.TabStop = true;
            rbWall.Text = "Wall";
            rbWall.UseVisualStyleBackColor = true;
            rbWall.CheckedChanged += rbWall_CheckedChanged;
            // 
            // rbSprite
            // 
            rbSprite.AutoSize = true;
            rbSprite.Checked = true;
            rbSprite.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbSprite.Location = new Point(6, 28);
            rbSprite.Name = "rbSprite";
            rbSprite.Size = new Size(62, 21);
            rbSprite.TabIndex = 0;
            rbSprite.TabStop = true;
            rbSprite.Text = "Sprite";
            rbSprite.UseVisualStyleBackColor = true;
            rbSprite.CheckedChanged += rbSprite_CheckedChanged;
            // 
            // gbEntryMode
            // 
            gbEntryMode.Controls.Add(rbBinary);
            gbEntryMode.Controls.Add(rbHex);
            gbEntryMode.Controls.Add(rbDecimal);
            gbEntryMode.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbEntryMode.Location = new Point(297, 26);
            gbEntryMode.Name = "gbEntryMode";
            gbEntryMode.Size = new Size(226, 64);
            gbEntryMode.TabIndex = 1;
            gbEntryMode.TabStop = false;
            gbEntryMode.Text = "Entry";
            // 
            // rbBinary
            // 
            rbBinary.AutoSize = true;
            rbBinary.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            rbBinary.Location = new Point(144, 28);
            rbBinary.Name = "rbBinary";
            rbBinary.Size = new Size(66, 21);
            rbBinary.TabIndex = 2;
            rbBinary.Text = "Binary";
            rbBinary.UseVisualStyleBackColor = true;
            rbBinary.CheckedChanged += rbBinary_CheckedChanged;
            // 
            // rbHex
            // 
            rbHex.AutoSize = true;
            rbHex.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            rbHex.Location = new Point(88, 28);
            rbHex.Name = "rbHex";
            rbHex.Size = new Size(50, 21);
            rbHex.TabIndex = 1;
            rbHex.Text = "Hex";
            rbHex.UseVisualStyleBackColor = true;
            rbHex.CheckedChanged += rbHex_CheckedChanged;
            // 
            // rbDecimal
            // 
            rbDecimal.AutoSize = true;
            rbDecimal.Checked = true;
            rbDecimal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            rbDecimal.Location = new Point(6, 28);
            rbDecimal.Name = "rbDecimal";
            rbDecimal.Size = new Size(76, 21);
            rbDecimal.TabIndex = 0;
            rbDecimal.TabStop = true;
            rbDecimal.Text = "Decimal";
            rbDecimal.UseVisualStyleBackColor = true;
            rbDecimal.CheckedChanged += rbDecimal_CheckedChanged;
            // 
            // tbValue
            // 
            tbValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbValue.Location = new Point(551, 54);
            tbValue.Name = "tbValue";
            tbValue.Size = new Size(163, 25);
            tbValue.TabIndex = 2;
            toolTip1.SetToolTip(tbValue, "Use 0x prefix for hex, 0b prefix for binary if desired (not required)\r\nUse spaces in binary input to improve readability if desired");
            tbValue.WordWrap = false;
            tbValue.MouseClick += tbValue_MouseClick;
            tbValue.Enter += tbValue_Enter;
            tbValue.KeyDown += tbValue_KeyDown;
            tbValue.MouseEnter += tbValue_MouseEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(551, 26);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 3;
            label1.Text = "Enter value";
            // 
            // btCalc
            // 
            btCalc.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCalc.Location = new Point(750, 26);
            btCalc.Name = "btCalc";
            btCalc.Size = new Size(271, 27);
            btCalc.TabIndex = 4;
            btCalc.Text = "Calculate from checkboxes";
            btCalc.UseVisualStyleBackColor = true;
            btCalc.Click += btCalc_Click;
            // 
            // LV
            // 
            LV.CheckBoxes = true;
            LV.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader6, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader7 });
            LV.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LV.FullRowSelect = true;
            LV.GridLines = true;
            LV.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            LV.LabelWrap = false;
            LV.Location = new Point(22, 110);
            LV.Name = "LV";
            LV.Scrollable = false;
            LV.Size = new Size(1046, 438);
            LV.TabIndex = 6;
            LV.UseCompatibleStateImageBehavior = false;
            LV.View = View.Details;
            LV.ItemChecked += LV_ItemChecked;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "On";
            columnHeader1.Width = 36;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Bit";
            columnHeader6.TextAlign = HorizontalAlignment.Right;
            columnHeader6.Width = 44;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Hex";
            columnHeader2.TextAlign = HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Dec";
            columnHeader3.TextAlign = HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Label";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Description";
            columnHeader5.Width = 580;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Key";
            columnHeader7.Width = 50;
            // 
            // rtbInfo
            // 
            rtbInfo.BackColor = SystemColors.Control;
            rtbInfo.BorderStyle = BorderStyle.None;
            rtbInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbInfo.Location = new Point(130, 563);
            rtbInfo.Name = "rtbInfo";
            rtbInfo.ReadOnly = true;
            rtbInfo.ScrollBars = RichTextBoxScrollBars.None;
            rtbInfo.Size = new Size(825, 58);
            rtbInfo.TabIndex = 6;
            rtbInfo.TabStop = false;
            rtbInfo.Text = "";
            rtbInfo.WordWrap = false;
            rtbInfo.LinkClicked += rtbInfo_LinkClicked;
            // 
            // btClear
            // 
            btClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btClear.Location = new Point(750, 67);
            btClear.Name = "btClear";
            btClear.Size = new Size(271, 23);
            btClear.TabIndex = 5;
            btClear.Text = "Clear checkboxes";
            btClear.UseVisualStyleBackColor = true;
            btClear.Click += btClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 644);
            Controls.Add(btClear);
            Controls.Add(rtbInfo);
            Controls.Add(LV);
            Controls.Add(btCalc);
            Controls.Add(label1);
            Controls.Add(tbValue);
            Controls.Add(gbEntryMode);
            Controls.Add(gbStatMode);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "CStat Calculator";
            Load += Form1_Load;
            gbStatMode.ResumeLayout(false);
            gbStatMode.PerformLayout();
            gbEntryMode.ResumeLayout(false);
            gbEntryMode.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e) {}

        #endregion

        private GroupBox gbStatMode;
        private RadioButton rbWall;
        private RadioButton rbSprite;
        private GroupBox gbEntryMode;
        private RadioButton rbBinary;
        private RadioButton rbHex;
        private RadioButton rbDecimal;
        private TextBox tbValue;
        private Label label1;
        private Button btCalc;
        private ListView LV;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private RadioButton rbCeiling;
        private RichTextBox rtbInfo;
        private ToolTip toolTip1;
        private Button btClear;
    }
}
