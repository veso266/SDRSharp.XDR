using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;

namespace SDRSharp.Diagnostics
{
    // Token: 0x02000004 RID: 4
    public class ProcessorPanel : UserControl
    {
        // Token: 0x06000011 RID: 17 RVA: 0x0000227B File Offset: 0x0000047B
        public ProcessorPanel(ISharpControl control)
        {
            this._control = control;
            this.InitializeComponent();
            this.sourceComboBox.SelectedIndex = 0;
        }

        // Token: 0x06000019 RID: 25 RVA: 0x0000247B File Offset: 0x0000067B
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x0600001A RID: 26 RVA: 0x0000249C File Offset: 0x0000069C
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.acquireButton = new System.Windows.Forms.Button();
            this.integrationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rebuildButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.82609F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.17391F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.enableCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sourceComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.referenceTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.acquireButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.integrationNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rebuildButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 121);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reference";
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Location = new System.Drawing.Point(3, 5);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(65, 17);
            this.enableCheckBox.TabIndex = 0;
            this.enableCheckBox.Text = "Enabled";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.sourceComboBox, 2);
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Items.AddRange(new object[] {
            "Filtered IF",
            "Full IQ",
            "Demodulator"});
            this.sourceComboBox.Location = new System.Drawing.Point(92, 31);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(109, 21);
            this.sourceComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Integration (sec)";
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceTextBox.Location = new System.Drawing.Point(92, 59);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.ReadOnly = true;
            this.referenceTextBox.Size = new System.Drawing.Size(49, 20);
            this.referenceTextBox.TabIndex = 11;
            this.referenceTextBox.Text = "0.00 dB";
            this.referenceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // acquireButton
            // 
            this.acquireButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.acquireButton.Location = new System.Drawing.Point(147, 58);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(54, 22);
            this.acquireButton.TabIndex = 10;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.UseVisualStyleBackColor = true;
            // 
            // integrationNumericUpDown
            // 
            this.integrationNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.integrationNumericUpDown.Location = new System.Drawing.Point(92, 92);
            this.integrationNumericUpDown.Name = "integrationNumericUpDown";
            this.integrationNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.integrationNumericUpDown.TabIndex = 13;
            this.integrationNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rebuildButton
            // 
            this.rebuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rebuildButton.Location = new System.Drawing.Point(147, 90);
            this.rebuildButton.Name = "rebuildButton";
            this.rebuildButton.Size = new System.Drawing.Size(54, 23);
            this.rebuildButton.TabIndex = 17;
            this.rebuildButton.Text = "Rebuild";
            this.rebuildButton.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.resetButton, 2);
            this.resetButton.Location = new System.Drawing.Point(92, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(109, 22);
            this.resetButton.TabIndex = 16;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 500;
            // 
            // ProcessorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcessorPanel";
            this.Size = new System.Drawing.Size(204, 121);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Token: 0x0400000D RID: 13
        private float _reference;

        // Token: 0x0400000E RID: 14
        private ISharpControl _control;

        // Token: 0x04000010 RID: 16
        private IContainer components;

        // Token: 0x04000011 RID: 17
        private TableLayoutPanel tableLayoutPanel1;

        // Token: 0x04000012 RID: 18
        private Label label4;

        // Token: 0x04000014 RID: 20
        private ComboBox sourceComboBox;

        // Token: 0x04000015 RID: 21
        private Label label3;

        // Token: 0x04000016 RID: 22
        private Button acquireButton;

        // Token: 0x04000017 RID: 23
        private TextBox referenceTextBox;

        // Token: 0x04000018 RID: 24
        private Label label5;

        // Token: 0x04000019 RID: 25
        private NumericUpDown integrationNumericUpDown;

        // Token: 0x0400001B RID: 27
        private Timer refreshTimer;

        // Token: 0x0400001D RID: 29
        private Button resetButton;

        // Token: 0x0400001E RID: 30
        private Button rebuildButton;
        private CheckBox enableCheckBox;
    }
}