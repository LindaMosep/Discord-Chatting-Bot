using System.Linq;

namespace RoguelandsDiscordBot.Forms
{
    partial class SendMessageForm
    {
        #region Not Necesseary
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
        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.discordImageLabel = new System.Windows.Forms.Label();
            this.TempImageLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guildNuserFoundedLabel = new System.Windows.Forms.Label();
            this.guildChannelListBox = new System.Windows.Forms.ListBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.channelIDtextBox = new System.Windows.Forms.TextBox();
            this.selectTypeDropdown = new System.Windows.Forms.ComboBox();
            this.userNchannelList = new System.Windows.Forms.ListBox();
            this.sendMessageBut = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.discordAvatarPicture = new System.Windows.Forms.PictureBox();
            this.ChatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discordAvatarPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatPanel
            // 
            this.ChatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ChatPanel.Controls.Add(this.discordImageLabel);
            this.ChatPanel.Controls.Add(this.TempImageLabel);
            this.ChatPanel.Controls.Add(this.pictureBox3);
            this.ChatPanel.Controls.Add(this.pictureBox2);
            this.ChatPanel.Controls.Add(this.pictureBox1);
            this.ChatPanel.Controls.Add(this.flowLayoutPanel1);
            this.ChatPanel.Controls.Add(this.guildNuserFoundedLabel);
            this.ChatPanel.Controls.Add(this.guildChannelListBox);
            this.ChatPanel.Controls.Add(this.userNameLabel);
            this.ChatPanel.Controls.Add(this.channelIDtextBox);
            this.ChatPanel.Controls.Add(this.selectTypeDropdown);
            this.ChatPanel.Controls.Add(this.userNchannelList);
            this.ChatPanel.Controls.Add(this.sendMessageBut);
            this.ChatPanel.Controls.Add(this.MessageBox);
            this.ChatPanel.Controls.Add(this.discordAvatarPicture);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatPanel.Location = new System.Drawing.Point(0, 0);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(1024, 602);
            this.ChatPanel.TabIndex = 5;

            // 
            // discordImageLabel
            // 
            this.discordImageLabel.AutoSize = true;
            this.discordImageLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.discordImageLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.discordImageLabel.Location = new System.Drawing.Point(146, 562);
            this.discordImageLabel.MaximumSize = new System.Drawing.Size(680, 1000);
            this.discordImageLabel.Name = "discordImageLabel";
            this.discordImageLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.discordImageLabel.Size = new System.Drawing.Size(18, 28);
            this.discordImageLabel.TabIndex = 22;
            this.discordImageLabel.Text = " ";
            // 
            // TempImageLabel
            // 
            this.TempImageLabel.AutoSize = true;
            this.TempImageLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TempImageLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TempImageLabel.Location = new System.Drawing.Point(465, 419);
            this.TempImageLabel.MaximumSize = new System.Drawing.Size(500, 500);
            this.TempImageLabel.Name = "TempImageLabel";
            this.TempImageLabel.Size = new System.Drawing.Size(0, 28);
            this.TempImageLabel.TabIndex = 21;
            this.TempImageLabel.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(0, 128);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 63);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 353);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(728, 356);
            this.flowLayoutPanel1.TabIndex = 17;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // guildNuserFoundedLabel
            // 
            this.guildNuserFoundedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guildNuserFoundedLabel.AutoSize = true;
            this.guildNuserFoundedLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guildNuserFoundedLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guildNuserFoundedLabel.Location = new System.Drawing.Point(816, 542);
            this.guildNuserFoundedLabel.MaximumSize = new System.Drawing.Size(500, 500);
            this.guildNuserFoundedLabel.Name = "guildNuserFoundedLabel";
            this.guildNuserFoundedLabel.Size = new System.Drawing.Size(146, 28);
            this.guildNuserFoundedLabel.TabIndex = 13;
            this.guildNuserFoundedLabel.Text = "User founded!";
            this.guildNuserFoundedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.guildNuserFoundedLabel.Visible = false;
            // 
            // guildChannelListBox
            // 
            this.guildChannelListBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guildChannelListBox.FormattingEnabled = true;
            this.guildChannelListBox.ItemHeight = 37;
            this.guildChannelListBox.Location = new System.Drawing.Point(764, 12);
            this.guildChannelListBox.Name = "guildChannelListBox";
            this.guildChannelListBox.Size = new System.Drawing.Size(248, 411);
            this.guildChannelListBox.TabIndex = 12;
            this.guildChannelListBox.Visible = false;
            this.guildChannelListBox.SelectedIndexChanged += new System.EventHandler(this.guildChannelListBox_changed);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.userNameLabel.Location = new System.Drawing.Point(11, 422);
            this.userNameLabel.MaximumSize = new System.Drawing.Size(500, 500);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(110, 28);
            this.userNameLabel.TabIndex = 11;
            this.userNameLabel.Text = "UserName";
            this.userNameLabel.Visible = false;
            // 
            // channelIDtextBox
            // 
            this.channelIDtextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.channelIDtextBox.Location = new System.Drawing.Point(764, 488);
            this.channelIDtextBox.MaximumSize = new System.Drawing.Size(500, 35);
            this.channelIDtextBox.MaxLength = 18;
            this.channelIDtextBox.MinimumSize = new System.Drawing.Size(4, 40);
            this.channelIDtextBox.Multiline = true;
            this.channelIDtextBox.Name = "channelIDtextBox";
            this.channelIDtextBox.Size = new System.Drawing.Size(248, 40);
            this.channelIDtextBox.TabIndex = 7;
            this.channelIDtextBox.Text = "Enter ID here...";
            this.channelIDtextBox.UseSystemPasswordChar = true;
            this.channelIDtextBox.Visible = false;
            this.channelIDtextBox.TextChanged += new System.EventHandler(this.ChannelIDtextBox_TextChanged);
            this.channelIDtextBox.GotFocus += new System.EventHandler(this.ChannelIDtextBox_CleanDefault);
            this.channelIDtextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChannelIDTextBox_KeyDownAsync);
            this.channelIDtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChannelIDtextBox_KeyPress);
            // 
            // selectTypeDropdown
            // 
            this.selectTypeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTypeDropdown.FormattingEnabled = true;
            this.selectTypeDropdown.Items.AddRange(new object[] {
            "User.",
            "Server Text Channel.",
            "Null."});
            this.selectTypeDropdown.Location = new System.Drawing.Point(764, 445);
            this.selectTypeDropdown.Name = "selectTypeDropdown";
            this.selectTypeDropdown.Size = new System.Drawing.Size(248, 23);
            this.selectTypeDropdown.TabIndex = 6;
            this.selectTypeDropdown.SelectedIndexChanged += new System.EventHandler(this.selectTypeDropdown_changed);
            // 
            // userNchannelList
            // 
            this.userNchannelList.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userNchannelList.FormattingEnabled = true;
            this.userNchannelList.ItemHeight = 37;
            this.userNchannelList.Location = new System.Drawing.Point(764, 12);
            this.userNchannelList.Name = "userNchannelList";
            this.userNchannelList.Size = new System.Drawing.Size(248, 411);
            this.userNchannelList.TabIndex = 4;
            this.userNchannelList.SelectedIndexChanged += new System.EventHandler(this.userNchannelList_SelectedIndexChanged);
            // 
            // sendMessageBut
            // 
            this.sendMessageBut.BackColor = System.Drawing.Color.DimGray;
            this.sendMessageBut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendMessageBut.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.sendMessageBut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sendMessageBut.Location = new System.Drawing.Point(529, 17);
            this.sendMessageBut.Name = "sendMessageBut";
            this.sendMessageBut.Size = new System.Drawing.Size(52, 40);
            this.sendMessageBut.TabIndex = 3;
            this.sendMessageBut.Text = "Send";
            this.sendMessageBut.UseVisualStyleBackColor = false;
            this.sendMessageBut.Click += new System.EventHandler(this.SendMessageBut_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MessageBox.Location = new System.Drawing.Point(11, 17);
            this.MessageBox.MaximumSize = new System.Drawing.Size(500, 35);
            this.MessageBox.MaxLength = 1999;
            this.MessageBox.MinimumSize = new System.Drawing.Size(4, 40);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(500, 40);
            this.MessageBox.TabIndex = 2;
            this.MessageBox.Text = "Enter Your Message Here...";
            this.MessageBox.GotFocus += new System.EventHandler(this.MessageBox_CleanDefault);
            this.MessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageBox_Keydown);
            // 
            // discordAvatarPicture
            // 
            this.discordAvatarPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discordAvatarPicture.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.discordAvatarPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.discordAvatarPicture.Location = new System.Drawing.Point(12, 462);
            this.discordAvatarPicture.MaximumSize = new System.Drawing.Size(128, 128);
            this.discordAvatarPicture.Name = "discordAvatarPicture";
            this.discordAvatarPicture.Size = new System.Drawing.Size(128, 128);
            this.discordAvatarPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.discordAvatarPicture.TabIndex = 10;
            this.discordAvatarPicture.TabStop = false;
            // 
            // SendMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 602);
            this.Controls.Add(this.ChatPanel);
            this.Name = "SendMessageForm";
            this.Text = "SendMessageForm";
            this.Load += new System.EventHandler(this.SendMessageForm_Load);
            this.ChatPanel.ResumeLayout(false);
            this.ChatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discordAvatarPicture)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        #region Items
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Button sendMessageBut;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.ListBox userNchannelList;
        private System.Windows.Forms.TextBox channelIDtextBox;
        private System.Windows.Forms.ComboBox selectTypeDropdown;
        private System.Windows.Forms.PictureBox discordAvatarPicture;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.ListBox guildChannelListBox;
        private System.Windows.Forms.Label guildNuserFoundedLabel;
        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label discordImageLabel;
        private System.Windows.Forms.Label TempImageLabel;
    }
}