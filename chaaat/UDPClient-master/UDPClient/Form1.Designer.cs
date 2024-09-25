namespace udpClient
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
            button1 = new Button();
            Text = new TextBox();
            IpToBox = new TextBox();
            Command = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(518, 98);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Text
            // 
            Text.Location = new Point(252, 83);
            Text.Multiline = true;
            Text.Name = "Text";
            Text.Size = new Size(247, 47);
            Text.TabIndex = 1;
            // 
            // IpToBox
            // 
            IpToBox.Location = new Point(47, 43);
            IpToBox.Name = "IpToBox";
            IpToBox.Size = new Size(100, 23);
            IpToBox.TabIndex = 2;
            // 
            // Command
            // 
            Command.Location = new Point(47, 143);
            Command.Name = "Command";
            Command.Size = new Size(100, 23);
            Command.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(361, 65);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 4;
            label1.Text = "Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 25);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 5;
            label2.Text = "IpTo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 125);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 6;
            label3.Text = "Command";
            // 
            // button2
            // 
            button2.Location = new Point(164, 43);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Connect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 223);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(529, 217);
            textBox1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 196);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 9;
            label4.Text = "Message_log:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(628, 471);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Command);
            Controls.Add(IpToBox);
            Controls.Add(Text);
            Controls.Add(button1);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox Text;
        private TextBox IpToBox;
        private TextBox Command;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button2;
        private TextBox textBox1;
        private Label label4;
    }
}
