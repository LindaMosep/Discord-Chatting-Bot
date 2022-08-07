
namespace RoguelandsDiscordBot.Forms
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
            if(disposing && (components != null))
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
            this.StartBotServiceBut = new System.Windows.Forms.Button();
            this.OpenChatBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartBotServiceBut
            // 
            this.StartBotServiceBut.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StartBotServiceBut.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.StartBotServiceBut.ForeColor = System.Drawing.Color.DarkBlue;
            this.StartBotServiceBut.Location = new System.Drawing.Point(664, 12);
            this.StartBotServiceBut.Name = "StartBotServiceBut";
            this.StartBotServiceBut.Size = new System.Drawing.Size(124, 30);
            this.StartBotServiceBut.TabIndex = 0;
            this.StartBotServiceBut.Text = "Start Bot Service";
            this.StartBotServiceBut.UseVisualStyleBackColor = false;
            this.StartBotServiceBut.Click += new System.EventHandler(this.StartBotBut_click);
            // 
            // OpenChatBut
            // 
            this.OpenChatBut.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.OpenChatBut.Font = new System.Drawing.Font("Segoe UI Emoji", 8.9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.OpenChatBut.ForeColor = System.Drawing.Color.DarkBlue;
            this.OpenChatBut.Location = new System.Drawing.Point(664, 48);
            this.OpenChatBut.Name = "OpenChatBut";
            this.OpenChatBut.Size = new System.Drawing.Size(124, 30);
            this.OpenChatBut.TabIndex = 3;
            this.OpenChatBut.Text = "Open Chat Panel";
            this.OpenChatBut.UseVisualStyleBackColor = false;
            this.OpenChatBut.Click += new System.EventHandler(this.OpenChatPanelBut_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenChatBut);
            this.Controls.Add(this.StartBotServiceBut);
            this.Name = "Form1";
            this.Text = "Discord Bot Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button StartBotServiceBut;
        public System.Windows.Forms.Button OpenChatBut;
    }
}

