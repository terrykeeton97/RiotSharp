﻿namespace RiotForm;

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
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        button4 = new Button();
        listBox1 = new ListBox();
        comboBox1 = new ComboBox();
        comboBox2 = new ComboBox();
        labelRoleSelection = new Label();
        button5 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(34, 21);
        button1.Name = "button1";
        button1.Size = new Size(138, 23);
        button1.TabIndex = 0;
        button1.Text = "Account Session";
        button1.UseVisualStyleBackColor = true;
        button1.Click += Button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(34, 50);
        button2.Name = "button2";
        button2.Size = new Size(138, 23);
        button2.TabIndex = 1;
        button2.Text = "Get Summoner Name";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(34, 79);
        button3.Name = "button3";
        button3.Size = new Size(138, 23);
        button3.TabIndex = 2;
        button3.Text = "Get Summoner Id";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.Location = new Point(34, 108);
        button4.Name = "button4";
        button4.Size = new Size(138, 23);
        button4.TabIndex = 3;
        button4.Text = "Get All Champions";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new Point(34, 137);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(138, 154);
        listBox1.TabIndex = 4;
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "UNSELECTED", "TOP", "JUNGLE", "MIDDLE", "BOTTOM", "UTILITY", "FILL" });
        comboBox1.Location = new Point(287, 22);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 23);
        comboBox1.TabIndex = 5;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.Items.AddRange(new object[] { "UNSELECTED", "TOP", "JUNGLE", "MIDDLE", "BOTTOM", "UTILITY", "FILL" });
        comboBox2.Location = new Point(414, 22);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(121, 23);
        comboBox2.TabIndex = 6;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        // 
        // labelRoleSelection
        // 
        labelRoleSelection.AutoSize = true;
        labelRoleSelection.Location = new Point(197, 25);
        labelRoleSelection.Name = "labelRoleSelection";
        labelRoleSelection.Size = new Size(84, 15);
        labelRoleSelection.TabIndex = 7;
        labelRoleSelection.Text = "Role Selection:";
        // 
        // button5
        // 
        button5.Location = new Point(34, 297);
        button5.Name = "button5";
        button5.Size = new Size(138, 23);
        button5.TabIndex = 8;
        button5.Text = "Accept Friend Requests";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(822, 544);
        Controls.Add(button5);
        Controls.Add(labelRoleSelection);
        Controls.Add(comboBox2);
        Controls.Add(comboBox1);
        Controls.Add(listBox1);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private ListBox listBox1;
    private ComboBox comboBox1;
    private ComboBox comboBox2;
    private Label labelRoleSelection;
    private Button button5;
}
