using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

using SDRSharp.Radio;

namespace SDRSharp.XDR
{
	public partial class SettingsPanel : UserControl
	{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //When SettingsPanel starts it will call this
        public void InitializeComponent()
        {
            this.enableXdrCheckBox = new System.Windows.Forms.CheckBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comPortsBox = new System.Windows.Forms.ComboBox();
            this.BaudrateBox = new System.Windows.Forms.ComboBox();
            this.AdvancedRDS = new System.Windows.Forms.Button();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableXdrCheckBox
            // 
            this.enableXdrCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.enableXdrCheckBox.AutoSize = true;
            this.enableXdrCheckBox.Location = new System.Drawing.Point(3, 3);
            this.enableXdrCheckBox.Name = "enableXdrCheckBox";
            this.enableXdrCheckBox.Size = new System.Drawing.Size(85, 17);
            this.enableXdrCheckBox.TabIndex = 0;
            this.enableXdrCheckBox.Text = "Enable XDR";
            this.enableXdrCheckBox.UseVisualStyleBackColor = true;
            this.enableXdrCheckBox.CheckedChanged += new System.EventHandler(this.enableXdrCheckBox_CheckedChanged);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainTableLayoutPanel.Controls.Add(this.enableXdrCheckBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.label2, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.comPortsBox, 1, 2);
            this.mainTableLayoutPanel.Controls.Add(this.BaudrateBox, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.AdvancedRDS, 0, 3);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 4;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(204, 153);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM Port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baudrate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comPortsBox
            // 
            this.comPortsBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comPortsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortsBox.FormattingEnabled = true;
            this.comPortsBox.Location = new System.Drawing.Point(105, 39);
            this.comPortsBox.Name = "comPortsBox";
            this.comPortsBox.Size = new System.Drawing.Size(96, 21);
            this.comPortsBox.TabIndex = 2;
            this.comPortsBox.SelectedIndexChanged += new System.EventHandler(this.XdrComPortChanged_CheckedChanged);
            // 
            // BaudrateBox
            // 
            this.BaudrateBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BaudrateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudrateBox.FormattingEnabled = true;
            this.BaudrateBox.Location = new System.Drawing.Point(3, 39);
            this.BaudrateBox.Name = "BaudrateBox";
            this.BaudrateBox.Size = new System.Drawing.Size(96, 21);
            this.BaudrateBox.TabIndex = 3;
            this.BaudrateBox.SelectedIndexChanged += new System.EventHandler(this.BaudrateBox_SelectedIndexChanged);
            // 
            // AdvancedRDS
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.AdvancedRDS, 2); //This will draw Advanced RDS over 2 cluums
            this.AdvancedRDS.Location = new System.Drawing.Point(3, 66);
            this.AdvancedRDS.Name = "AdvancedRDS";
            this.AdvancedRDS.Size = new System.Drawing.Size(198, 23);
            this.AdvancedRDS.TabIndex = 2;
            this.AdvancedRDS.Text = "Advanced RDS";
            this.AdvancedRDS.UseVisualStyleBackColor = true;
            // 
            // SettingsPanel
            // 
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(204, 153);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
