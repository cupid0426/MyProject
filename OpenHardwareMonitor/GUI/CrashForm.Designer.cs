﻿/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2010 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/


namespace OpenHardwareMonitor.GUI {
  partial class CrashForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.sendButton = new System.Windows.Forms.Button();
        this.exitButton = new System.Windows.Forms.Button();
        this.commentTextBox = new System.Windows.Forms.TextBox();
        this.titleLabel = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.commentPanel = new System.Windows.Forms.Panel();
        this.reportPanel = new System.Windows.Forms.Panel();
        this.reportTextBox = new System.Windows.Forms.TextBox();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.emailTextBox = new System.Windows.Forms.TextBox();
        this.commentPanel.SuspendLayout();
        this.reportPanel.SuspendLayout();
        this.SuspendLayout();
        // 
        // sendButton
        // 
        this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.sendButton.Location = new System.Drawing.Point(449, 433);
        this.sendButton.Name = "sendButton";
        this.sendButton.Size = new System.Drawing.Size(75, 21);
        this.sendButton.TabIndex = 2;
        this.sendButton.Text = "发送";
        this.sendButton.UseVisualStyleBackColor = true;
        this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
        // 
        // exitButton
        // 
        this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.exitButton.Location = new System.Drawing.Point(530, 433);
        this.exitButton.Name = "exitButton";
        this.exitButton.Size = new System.Drawing.Size(75, 21);
        this.exitButton.TabIndex = 3;
        this.exitButton.Text = "退出";
        this.exitButton.UseVisualStyleBackColor = true;
        // 
        // commentTextBox
        // 
        this.commentTextBox.AcceptsReturn = true;
        this.commentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.commentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.commentTextBox.Location = new System.Drawing.Point(4, 4);
        this.commentTextBox.Multiline = true;
        this.commentTextBox.Name = "commentTextBox";
        this.commentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.commentTextBox.Size = new System.Drawing.Size(586, 70);
        this.commentTextBox.TabIndex = 1;
        // 
        // titleLabel
        // 
        this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.titleLabel.BackColor = System.Drawing.SystemColors.Window;
        this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.titleLabel.Location = new System.Drawing.Point(-1, -1);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
        this.titleLabel.Size = new System.Drawing.Size(619, 48);
        this.titleLabel.TabIndex = 4;
        this.titleLabel.Text = "Open Hardware Monitor 遇到了问题，需要关闭。我们很抱歉给您带来不便。";
        // 
        // label3
        // 
        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.label3.AutoEllipsis = true;
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(9, 58);
        this.label3.Margin = new System.Windows.Forms.Padding(3, 11, 3, 7);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(425, 12);
        this.label3.TabIndex = 5;
        this.label3.Text = "为了帮助诊断和解决问题，你可以发送崩溃报告。下面的报告中已经自动创建：";
        // 
        // label1
        // 
        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.label1.AutoEllipsis = true;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(9, 320);
        this.label1.Margin = new System.Windows.Forms.Padding(3, 11, 3, 7);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(209, 12);
        this.label1.TabIndex = 6;
        this.label1.Text = "您可以添加额外的信息报告（可选）：";
        // 
        // commentPanel
        // 
        this.commentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.commentPanel.BackColor = System.Drawing.SystemColors.Window;
        this.commentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.commentPanel.Controls.Add(this.commentTextBox);
        this.commentPanel.Location = new System.Drawing.Point(12, 342);
        this.commentPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
        this.commentPanel.Name = "commentPanel";
        this.commentPanel.Padding = new System.Windows.Forms.Padding(4, 4, 1, 4);
        this.commentPanel.Size = new System.Drawing.Size(593, 80);
        this.commentPanel.TabIndex = 1;
        this.commentPanel.TabStop = true;
        // 
        // reportPanel
        // 
        this.reportPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.reportPanel.BackColor = System.Drawing.SystemColors.Window;
        this.reportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.reportPanel.Controls.Add(this.reportTextBox);
        this.reportPanel.Controls.Add(this.textBox1);
        this.reportPanel.Location = new System.Drawing.Point(12, 80);
        this.reportPanel.Name = "reportPanel";
        this.reportPanel.Padding = new System.Windows.Forms.Padding(4, 4, 1, 4);
        this.reportPanel.Size = new System.Drawing.Size(593, 196);
        this.reportPanel.TabIndex = 8;
        // 
        // reportTextBox
        // 
        this.reportTextBox.BackColor = System.Drawing.SystemColors.Window;
        this.reportTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.reportTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.reportTextBox.Location = new System.Drawing.Point(4, 4);
        this.reportTextBox.Multiline = true;
        this.reportTextBox.Name = "reportTextBox";
        this.reportTextBox.ReadOnly = true;
        this.reportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.reportTextBox.Size = new System.Drawing.Size(586, 186);
        this.reportTextBox.TabIndex = 9;
        this.reportTextBox.TabStop = false;
        // 
        // textBox1
        // 
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBox1.Location = new System.Drawing.Point(4, 4);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(586, 186);
        this.textBox1.TabIndex = 2;
        // 
        // label2
        // 
        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.label2.AutoEllipsis = true;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(9, 294);
        this.label2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 7);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(197, 12);
        this.label2.TabIndex = 9;
        this.label2.Text = "请输入您的电子邮件地址（可选）：";
        // 
        // emailTextBox
        // 
        this.emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.emailTextBox.Location = new System.Drawing.Point(188, 291);
        this.emailTextBox.Name = "emailTextBox";
        this.emailTextBox.Size = new System.Drawing.Size(417, 21);
        this.emailTextBox.TabIndex = 0;
        // 
        // CrashForm
        // 
        this.AcceptButton = this.sendButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.exitButton;
        this.ClientSize = new System.Drawing.Size(617, 465);
        this.ControlBox = false;
        this.Controls.Add(this.emailTextBox);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.reportPanel);
        this.Controls.Add(this.commentPanel);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.titleLabel);
        this.Controls.Add(this.exitButton);
        this.Controls.Add(this.sendButton);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CrashForm";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Open Hardware Monitor";
        this.commentPanel.ResumeLayout(false);
        this.commentPanel.PerformLayout();
        this.reportPanel.ResumeLayout(false);
        this.reportPanel.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button sendButton;
    private System.Windows.Forms.Button exitButton;
    private System.Windows.Forms.TextBox commentTextBox;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel commentPanel;
    private System.Windows.Forms.Panel reportPanel;
    private System.Windows.Forms.TextBox reportTextBox;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox emailTextBox;
  }
}