using Discord;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RoguelandsDiscordBot.Forms
{
    public partial class SendMessageForm : Form
    {

        #region Values
        string channelID = " ";
        string SelectedName = " ";

        bool focusedFirstTime = false;
        IUser detectedUser;
        ITextChannel detectedChannel;
        IGuild detectedGuild;

        List<ITextChannel> detectedChannelsList = new();

        int labelcount = 0;
        #endregion


        #region Update
        public SendMessageForm()
        {
            InitializeComponent();

        }
        private async void SendMessageForm_Load(object sender, EventArgs e)
        {
            if (userNchannelList.Items.Count == 0)
            {
                for (int i = 0; i < Datas.Channels.Count; i++)
                {
                    if (Datas.Channels[i].WhatType != ChannelList.Types.Server)
                    {
                        userNchannelList.Items.Add(Datas.Channels[i].name);
                    }

                }
            }

            PrivateFontCollection modernFont = new();

            modernFont.AddFontFile(resourcesPath + "Nexa\\NexaBold.otf");

            NexaBold = new Font(modernFont.Families[0], 15);

            await MessageTask();

        }



        private async Task MessageTask()
        {
            Program._client.MessageReceived += async (e) =>
            {
                ulong m = 0;

                try
                {

                    if (detectedChannel != null)
                    {

                        m = detectedChannel.Id;



                    }
                    else if (detectedUser != null)
                    {
                        var x = await detectedUser.CreateDMChannelAsync();
                        m = x.Id;
                    }
                    else
                    {
                        m = 0;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }




                if (e.Channel.Id == m)
                {

                    #region TempValues
                    var temp = e.Channel.GetUsersAsync();
                    var channelUsers = await temp.ToListAsync();
                    var mes_async = await e.Channel.GetMessagesAsync(1).ToListAsync();
                    var messages = mes_async[0];


                    LinkLabel Actuallabel = NewLinkLabel();
                    LinkLabel tempLabel = new();
                    tempLabel = Actuallabel;

                    string avatarurl = e.Author.GetAvatarUrl();
                    if (string.IsNullOrEmpty(avatarurl))
                    {
                        avatarurl = e.Author.GetDefaultAvatarUrl();
                    }
                    #endregion

                    for (int i = 0; i < messages.ToList().Count; i++)
                    {

                        var message = messages.ToList()[i];
                        var messageAuthor = message.Author.Username + "#" + message.Author.Discriminator + ":";
                        var content = message.Content;


                        string txt = content;


                        #region GetLinksInMessage

                        List<string> linksinmessage = new();
                        foreach (Match item in Regex.Matches(txt, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
                        {
                            linksinmessage.Add(item.Value);
                        }

                        if (linksinmessage.Count > 0)
                        {
                            List<string> substrings = new();
                            Console.WriteLine(linksinmessage.Count);
                            List<int> lastindexs = new();

                            for (int num = 0; num < linksinmessage.Count; num++)
                            {
                                try
                                {
                                    var link = linksinmessage[num];
                                    int linkstartindex = content.IndexOf(link);
                                    string substring;

                                    if (num == 0)
                                    {
                                        link = linksinmessage[num];
                                        linkstartindex = content.IndexOf(link);

                                    }
                                    else
                                    {
                                        link = linksinmessage[num];
                                        int getlowstartindex = content[lastindexs[num - 1]..].IndexOf(link);
                                        linkstartindex = getlowstartindex + lastindexs[num - 1];
                                        Console.WriteLine(linkstartindex);

                                    }


                                    if (linkstartindex >= 0)
                                    {

                                        if (num != 0)
                                        {
                                            if (num != linksinmessage.Count - 1)
                                            {
                                                substring =  content.Substring(lastindexs[num - 1], linkstartindex - lastindexs[num-1] + link.Length);
                                                Console.WriteLine(substring);
                                                substrings.Add(substring);
                                                lastindexs.Add(linkstartindex + link.Length);
                                            }
                                            else
                                            {
                                                substring =  content.Substring(lastindexs[num - 1]);
                                                Console.WriteLine(substring);
                                                substrings.Add(substring);

                                            }

                                        }
                                        else
                                        {

                                            lastindexs.Add(linkstartindex + link.Length);
                                            substring =  content[..(linkstartindex + link.Length)];
                                            Console.WriteLine(substring);
                                            substrings.Add(substring);
                                        }




                                    }


                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine("2: " + ex.Message);
                                }

                                tempLabel.Text = content;
                                string linkencrypt = "{Link}%&+_<2#4_>5½#>_z<|3#";

                                for (int subin = 0; subin < substrings.Count; subin++)
                                {
                                    var link = linksinmessage[subin];

                                    var substring = substrings[subin];

                                    //DiscordMSGLinkLabel.Text = DiscordMSGLinkLabel.Text.Replace(substring, substring.Replace(link, linkencrypt));
                                    tempLabel.Text = tempLabel.Text.Replace(substring, substring.Replace(link, linkencrypt));
                                    Console.WriteLine(subin);

                                }



                                for (int addlinks = 0; addlinks < substrings.Count; addlinks++)
                                {
                                    try
                                    {

                                        var linkstr = linkencrypt;
                                        tempLabel.Links.Add(tempLabel.Text.IndexOf(linkstr), 6, linksinmessage[addlinks]);
                                        tempLabel.Text = tempLabel.Text.Remove(tempLabel.Text.IndexOf(linkstr) + 6, "%&+_<2#4_>5½#>_z<|3#".Length);

                                        //DiscordMSGLinkLabel.Links.Add(DiscordMSGLinkLabel.Text.IndexOf(linkstr), 6, linksinmessage[addlinks]);
                                        //DiscordMSGLinkLabel.Text = DiscordMSGLinkLabel.Text.Remove(DiscordMSGLinkLabel.Text.IndexOf(linkstr) + 6,  "%&+_<2#4_>5½#>_z<|3#".Length);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("3: " + ex.Message);

                                    }

                                }


                            }





                        }
                        else
                        {
                            tempLabel.Text = content;


                        }
                        #endregion


                        #region GetAttachmentsInMessage


                        var attachments = message.Attachments.ToList();
                        var attachmentsImage = new List<IAttachment>();
                        string[] check = { ".png", ".jpg", ".jpeg", ".gif" };
                        if (attachments.Count != 0)
                        {
                            foreach (var file in attachments)
                            {
                                if (check.Any(x => file.Filename.EndsWith(x)))
                                {

                                    attachmentsImage.Add(file);
                                }


                            }


                        }


                        #endregion
                        Actuallabel = tempLabel;
                        string timestamp = e.Timestamp.ToLocalTime().ToString().Remove(e.Timestamp.ToLocalTime().ToString().IndexOf("+"), e.Timestamp.ToLocalTime().ToString()[e.Timestamp.ToLocalTime().ToString().IndexOf("+")..].Length);
                        bool contains = true;

                        try
                        {

                            contains =flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 2].Controls[0].Name.Contains(message.Author.Id.ToString());

                            if (!contains)
                            {
                                Console.WriteLine(flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 2].Controls[0].Name);
                            }

                        }
                        catch
                        {
                            contains = false;
                        }

                        string time = e.Timestamp.ToLocalTime().Day +"\\"+ e.Timestamp.ToLocalTime().Month + "\\" + e.Timestamp.ToLocalTime().Day + " " + e.Timestamp.ToLocalTime().Hour + ":"+ e.Timestamp.ToLocalTime().Minute + ":" + e.Timestamp.ToLocalTime().Second;
                        PictureBox p = NewPicture(e.Author.Username + "#" + e.Author.Discriminator + " - " +
                           timestamp, null, Actuallabel, contains, e.Author.Id.ToString(), attachmentsImage);



                        if (this.InvokeRequired)
                        {

                            this.Invoke((MethodInvoker)delegate ()
                            {



                                p.LoadAsync(avatarurl);



                            });

                        }



                    }




                }

            };

            await Task.Delay(-1);


        }
        #endregion


        #region Get User and Channel
        private async void GetUser(ulong id)
        {
            try
            {
                detectedUser =  await Program._client.GetUserAsync(id);

                if (detectedUser != null)
                {
                    detectedChannel = null;
                    string avatarurl = detectedUser.GetAvatarUrl();
                    if (string.IsNullOrEmpty(avatarurl))
                    {
                        avatarurl = detectedUser.GetDefaultAvatarUrl();
                    }
                    userNameLabel.Text = detectedUser.Username + "#" + detectedUser.Discriminator;
                    IDMChannel ba = await Program._client.GetDMChannelAsync(2);

                    ClearFlowLayoutPanel();

                    discordAvatarPicture.LoadAsync(avatarurl);
                    discordAvatarPicture.Visible = true;
                    userNameLabel.Visible = true;

                }
                else
                {
                    Console.WriteLine("there is no user with this ID");
                }

            }
            catch
            {
                Console.WriteLine("ERROR");
            }

        }
        private void GetChannel(ulong serverid, ulong id)
        {
            try
            {
                var detectedGuild = Program._client.GetGuild(serverid);

                if (detectedGuild != null)
                {
                    detectedChannel =  detectedGuild.GetTextChannel(id);
                    detectedUser = null;
                    if (detectedChannel != null)
                    {
                        string avatarurl = " ";
                        if (!string.IsNullOrEmpty(detectedGuild.IconUrl))
                        {
                            avatarurl = detectedGuild.IconUrl;
                        }
                        else
                        {
                            avatarurl = "https://st3.depositphotos.com/23594922/31822/v/600/depositphotos_318221368-stock-illustration-missing-picture-page-for-website.jpg";

                        }


                        ClearFlowLayoutPanel();
                        userNameLabel.Text = detectedGuild.Name + " #" + detectedChannel.Name;

                        discordAvatarPicture.LoadAsync(avatarurl);
                        Console.WriteLine(avatarurl);
                        discordAvatarPicture.Visible = true;
                        userNameLabel.Visible = true;

                    }
                    else
                    {

                    }
                }
                else
                {

                }


            }
            catch
            {
                Console.WriteLine("ERROR");
            }

        }
        #endregion


        #region Message Box and Message But
        private void MessageBox_Keydown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (MessageBox.Text.Length != 0)
                {

                    SendMessageBut_Click(sender, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;


                }
            }



        }
        private void MessageBox_CleanDefault(object sender, EventArgs e)
        {
            if (MessageBox.Focused)
            {
                if (!focusedFirstTime)
                {
                    MessageBox.Text = "";
                }
                focusedFirstTime = true;
            }
        }
        private async void SendMessageBut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Text.Length != 0)
            {
                var c = Datas.Channels.Find(m => m.name == SelectedName);


                if (detectedUser != null ||detectedChannel != null)
                {


                    if (detectedUser != null)
                    {


                        try
                        {

                            string message = MessageBox.Text;
                            MessageBox.Text = "";



                            await detectedUser.SendMessageAsync(message);
                        }
                        catch
                        {
                            Console.WriteLine("You cant send message to this user.");
                        }

                    }
                    else if (detectedChannel != null)
                    {
                        Console.WriteLine("XD4");

                        try
                        {

                            string message = MessageBox.Text;
                            MessageBox.Text = "";

                            await detectedChannel.SendMessageAsync(message);
                        }
                        catch
                        {
                            Console.WriteLine("You cant send message to this channel.");
                        }


                    }




                }




            }






        }
        #endregion


        #region User And Channel List
        private void userNchannelList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (selectTypeDropdown.SelectedIndex == 2 || selectTypeDropdown.SelectedIndex == -1)
            {

                var item = Datas.Channels.Find(m => m.name == userNchannelList.SelectedItem.ToString());
                if (item != null)
                {
                    if (item.WhatType == ChannelList.Types.User)
                    {
                        GetUser(item.id);
                    }
                    else if (item.WhatType == ChannelList.Types.Channel)
                    {
                        GetChannel(item.serverId, item.id);
                    }
                }
            }
        }
        #endregion


        #region ChannelID Text Box 
        private async void ChannelIDtextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (selectTypeDropdown.SelectedIndex == 0)
            {
                channelID = channelIDtextBox.Text;

                try
                {


                    if (channelID.Length == 18 || channelID.Length == 17)
                    {
                        IUser user = await Program._client.GetUserAsync(ulong.Parse(channelID));
                        if (user != null)
                        {
                            guildNuserFoundedLabel.Text = "User founded!";
                            guildNuserFoundedLabel.Location = new Point(816, 541);
                        }
                        else
                        {
                            guildNuserFoundedLabel.Text = "There is no user with this ID!";
                            guildNuserFoundedLabel.Location = new Point(738, 541);
                        }

                        GetUser(ulong.Parse(channelID));
                    }
                    else
                    {
                        guildNuserFoundedLabel.Text = "User ID has to be longer!";
                        guildNuserFoundedLabel.Location = new Point(764, 541);
                    }

                }
                catch
                {

                    Console.WriteLine("ERROR");
                }

            }
            else if (selectTypeDropdown.SelectedIndex == 1)
            {
                channelID = channelIDtextBox.Text;


                if (channelID.Length == 18 || channelID.Length == 17)
                {
                    try
                    {

                        detectedGuild = Program._client.GetGuild(ulong.Parse(channelID));

                        if (detectedGuild != null)
                        {
                            guildNuserFoundedLabel.Text = "Guild founded!";
                            guildNuserFoundedLabel.Location = new Point(813, 541);
                            var list = await detectedGuild.GetTextChannelsAsync();
                            detectedChannelsList = list.ToList();
                            guildChannelListBox.Items.Clear();

                            for (int i = 0; i < detectedChannelsList.Count; i++)
                            {
                                guildChannelListBox.Items.Add(detectedChannelsList[i].Name);
                            }


                        }
                        else
                        {
                            guildNuserFoundedLabel.Text = "There is no guild with this ID!";
                            guildNuserFoundedLabel.Location = new Point(727, 541);
                        }

                    }
                    catch
                    {
                        Console.WriteLine("ERROR");
                    }

                }
                else
                {

                    guildNuserFoundedLabel.Text = "Guild ID has to be longer!";
                    guildNuserFoundedLabel.Location = new Point(764, 541);

                }


            }



        }
        private void ChannelIDtextBox_CleanDefault(object sender, System.EventArgs e)
        {

            if (channelIDtextBox.Text.Contains("I"))
            {
                channelIDtextBox.Text = "";
            }

        }
        private void ChannelIDtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }


        }
        private async void ChannelIDTextBox_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (selectTypeDropdown.SelectedIndex == 0)
                {
                    channelID = channelIDtextBox.Text;

                    if (channelID.Length == 18 || channelID.Length == 17)
                    {
                        IUser user = await Program._client.GetUserAsync(ulong.Parse(channelID));
                        if (user != null)
                        {
                            guildNuserFoundedLabel.Text = "User founded!";
                            guildNuserFoundedLabel.Location = new Point(816, 541);
                        }
                        else
                        {
                            guildNuserFoundedLabel.Text = "There is no user with this ID!";
                            guildNuserFoundedLabel.Location = new Point(738, 541);
                        }
                        GetUser(ulong.Parse(channelID));
                    }
                    else
                    {
                        guildNuserFoundedLabel.Text = "User ID has to be longer!";
                        guildNuserFoundedLabel.Location = new Point(764, 541);

                    }
                }
                else if (selectTypeDropdown.SelectedIndex == 1)
                {
                    channelID = channelIDtextBox.Text;
                    if (channelID.Length == 18 || channelID.Length == 17)
                    {
                        detectedGuild = Program._client.GetGuild(ulong.Parse(channelID));

                        if (detectedGuild != null)
                        {
                            guildNuserFoundedLabel.Text = "Guild founded!";
                            guildNuserFoundedLabel.Location = new Point(813, 541);

                            var list = await detectedGuild.GetTextChannelsAsync();
                            detectedChannelsList = list.ToList();

                            guildChannelListBox.Items.Clear();
                            for (int i = 0; i < detectedChannelsList.Count; i++)
                            {
                                guildChannelListBox.Items.Add(detectedChannelsList[i].Name);
                            }


                        }
                        else
                        {
                            guildNuserFoundedLabel.Text = "There is no guild with this ID!";
                            guildNuserFoundedLabel.Location = new Point(727, 541);

                        }
                    }
                    else
                    {

                        guildNuserFoundedLabel.Text = "Guild ID has to be longer!";
                        guildNuserFoundedLabel.Location = new Point(764, 541);

                    }
                }
            }

        }
        #endregion


        #region Guild Channel List Box

        private void guildChannelListBox_changed(object sender, EventArgs e)
        {
            detectedChannel = detectedChannelsList.Find(m => m.Name == guildChannelListBox.SelectedItem.ToString());
            GetChannel(detectedGuild.Id, detectedChannel.Id);
            ClearFlowLayoutPanel();
        }
        #endregion


        #region Select Type Dropdown
        private void selectTypeDropdown_changed(object sender, EventArgs e)
        {
            if (selectTypeDropdown.SelectedIndex == 2)
            {
                channelIDtextBox.Visible = false;
                guildChannelListBox.Visible = false;
                detectedGuild = null;
                detectedChannel = null;
                discordAvatarPicture.Visible = false;
                userNameLabel.Text = "";
                detectedChannelsList.Clear();
                guildChannelListBox.Items.Clear();
                guildNuserFoundedLabel.Visible = false;
                channelIDtextBox.Text = "";
                ClearFlowLayoutPanel();



            }
            else if (selectTypeDropdown.SelectedIndex == 1)
            {
                channelIDtextBox.Visible = true;
                guildChannelListBox.Visible = true;
                detectedUser = null;
                discordAvatarPicture.Visible = false;
                userNameLabel.Text = "";
                guildChannelListBox.Items.Clear();
                guildNuserFoundedLabel.Visible = true;
                channelIDtextBox.Text = "Enter guild ID here...";
                ClearFlowLayoutPanel();

            }
            else if (selectTypeDropdown.SelectedIndex == 0)
            {
                channelIDtextBox.Visible = true;
                guildChannelListBox.Visible = true;
                detectedGuild = null;
                detectedChannel = null;
                discordAvatarPicture.Visible = false;
                userNameLabel.Text = "";
                detectedChannelsList.Clear();
                guildChannelListBox.Items.Clear();
                guildNuserFoundedLabel.Visible = true;
                channelIDtextBox.Text = "Enter user ID here...";
                ClearFlowLayoutPanel();


            }
        }
        #endregion


        #region Create Discord Layout

        #region Link Label


        public static Font NexaBold;
        readonly string redirect = "https://www.google.com/url?sa=i&url=";
        public static void UseCustomFont(string name, int size, Label label)
        {

            PrivateFontCollection modernFont = new();

            modernFont.AddFontFile(name);

            label.Font = new Font(modernFont.Families[0], size);


        }

        private void DiscordMSGLinkLabel_linkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {




            try
            {
                Process.Start(new ProcessStartInfo(redirect +e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }



        }


        public LinkLabel NewLinkLabel()
        {
            System.Windows.Forms.LinkLabel label = new();


            labelcount++;

            label.AutoSize = true;

            label.ForeColor = System.Drawing.Color.White;
            label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.Location = new System.Drawing.Point(51, 0);
            label.MaximumSize = new System.Drawing.Size(flowLayoutPanel1.Width - 40 - 47, 50000);
            label.Name = "DiscordMSGLinkLabel" + labelcount;
            label.Padding = new System.Windows.Forms.Padding(10);
            label.Size = new System.Drawing.Size(148, 48);
            label.TabIndex = 23;
            label.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(175)))), ((int)(((byte)244))));
            label.LinkArea = new LinkArea(0, 0);
            label.LinkBehavior = LinkBehavior.NeverUnderline;

            label.TabIndex = 23;
            label.LinkClicked += new LinkLabelLinkClickedEventHandler(DiscordMSGLinkLabel_linkClicked);
            label.Text = "";


            // label.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label.Font = NexaBold;


            // Program.UseCustomFont(resourcesPath + "Uni Sans Bold.otf", 15, label);

            return label;
        }


        #endregion

        readonly string resourcesPath = "";
        public void ClearFlowLayoutPanel()
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }
        }
        public PictureBox NewPicture(string userName, System.Drawing.Image picBox, LinkLabel msg, bool contains, string messageauthor, List<IAttachment> attachmentsImage)
        {
            #region Create Temp Objects
            System.Windows.Forms.PictureBox TempProfilePic = new();
            System.Windows.Forms.Label TempUserNameLabel = new();
            System.Windows.Forms.FlowLayoutPanel TempLayoutMessagePanel = new();
            System.Windows.Forms.FlowLayoutPanel TempLayoutUserNamePanel = new();
            System.Windows.Forms.FlowLayoutPanel TempLayoutImagePanel = new();
            #endregion

            #region TempLayoutMessagePanel
            TempLayoutMessagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            TempLayoutMessagePanel.Location = new System.Drawing.Point(471, 483);
            TempLayoutMessagePanel.Name = "Avatar and Name Box" + (labelcount + 1);
            TempLayoutMessagePanel.Size = new System.Drawing.Size(725, 47);
            TempLayoutMessagePanel.TabIndex = 23;
            TempLayoutMessagePanel.WrapContents = false;
            TempLayoutMessagePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            TempLayoutMessagePanel.AutoSize = true;
            TempLayoutMessagePanel.AutoScroll = true;
            TempLayoutMessagePanel.MinimumSize =  new Size(flowLayoutPanel1.Width - 25, msg.Height);
            TempLayoutMessagePanel.MaximumSize = new Size(flowLayoutPanel1.Width - 100000, 100000);
            TempLayoutMessagePanel.Margin = new Padding(0);
            #endregion

            #region TempLayoutUserNamePanel
            TempLayoutUserNamePanel.Location = new System.Drawing.Point(471, 483);
            TempLayoutUserNamePanel.Name = "Name Box Layout" + (labelcount + 1);
            TempLayoutUserNamePanel.Size = new System.Drawing.Size(725, 47);
            TempLayoutUserNamePanel.TabIndex = 23;
            TempLayoutUserNamePanel.WrapContents = false;
            TempLayoutUserNamePanel.BackColor = System.Drawing.Color.Red;
            TempLayoutUserNamePanel.AutoSize = true;
            TempLayoutUserNamePanel.AutoScroll = true;
            TempLayoutUserNamePanel.MinimumSize =  new Size(flowLayoutPanel1.Width - 25, 0);
            TempLayoutUserNamePanel.Margin = new System.Windows.Forms.Padding(0);
            #endregion

            #region TempLayoutImagePanel
            TempLayoutImagePanel.Location = new System.Drawing.Point(471, 483);
            TempLayoutImagePanel.Name = "Avatar and Name Box" + (labelcount + 1);
            TempLayoutImagePanel.TabIndex = 23;
            TempLayoutImagePanel.WrapContents = false;
            TempLayoutImagePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            TempLayoutImagePanel.AutoSize = true;
            TempLayoutImagePanel.AutoScroll = true;
            TempLayoutImagePanel.MaximumSize = new Size(100000, 100000);
            TempLayoutImagePanel.WrapContents = true;
            #endregion

            #region TempProfilePic
            TempProfilePic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            TempProfilePic.BackColor = System.Drawing.SystemColors.WindowFrame;
            TempProfilePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            TempProfilePic.Image = global::Discord_Chatting_Bot.Properties.Resources.closeBut;
            TempProfilePic.Location = new System.Drawing.Point(3, 3);
            TempProfilePic.MaximumSize = new System.Drawing.Size(42, 42);
            TempProfilePic.Name = "Temp Discord Avatar" + " " +  messageauthor +" "+(labelcount + 1);
            TempProfilePic.Size = new Size(42, 42);
            TempProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TempProfilePic.TabIndex = 22;
            TempProfilePic.TabStop = false;
            TempProfilePic.Visible = true;
            TempProfilePic.Image = picBox;
            #endregion

            #region TempUserNameLabel
            TempUserNameLabel.AutoSize = true;
            TempUserNameLabel.Font = NexaBold;
            TempUserNameLabel.ForeColor = System.Drawing.Color.White;
            TempUserNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TempUserNameLabel.Location = new System.Drawing.Point(51, 0);
            TempUserNameLabel.MaximumSize = new System.Drawing.Size(500, 500);
            TempUserNameLabel.Name = messageauthor +" "+(labelcount + 1);
            TempUserNameLabel.Padding = new System.Windows.Forms.Padding(10);
            TempUserNameLabel.Size = new System.Drawing.Size(148, 48);
            TempUserNameLabel.TabIndex = 23;
            TempUserNameLabel.Text = userName;
            TempUserNameLabel.Visible = true;
            TempUserNameLabel.Margin = new System.Windows.Forms.Padding(0);
            #endregion

            if (this.InvokeRequired)
            {

                this.Invoke((MethodInvoker)delegate ()
                {


                    TempLayoutUserNamePanel.Controls.Add(TempUserNameLabel);
                    TempLayoutMessagePanel.Controls.Add(TempProfilePic);
                    TempLayoutMessagePanel.Controls.Add(msg);


                    if (!contains)
                    {
                        flowLayoutPanel1.Controls.Add(TempLayoutUserNamePanel);
                    }
                    flowLayoutPanel1.Controls.Add(TempLayoutMessagePanel);

                    #region AttachmentsImage
                    if (attachmentsImage.Count > 0)
                    {
                        TempLayoutImagePanel.AutoSize = true;
                        for (int i = 0; i < attachmentsImage.Count; i++)
                        {
                            System.Windows.Forms.PictureBox tempAttachment = new();

                            tempAttachment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                            tempAttachment.Location = new System.Drawing.Point(3, 3);

                            tempAttachment.Name = attachmentsImage[i].Url;

                            double hkatfarki = (double)attachmentsImage[i].Height.Value / 260;
                            double wkatfarki = (double)attachmentsImage[i].Width.Value / 410;




                            if (attachmentsImage[i].Width.Value >= attachmentsImage[i].Height.Value)
                            {
                                if (wkatfarki > 1)
                                {
                                    tempAttachment.Width = (int)(attachmentsImage[i].Width.Value / wkatfarki);
                                    tempAttachment.Height = (int)(attachmentsImage[i].Height.Value / wkatfarki);
                                }
                                else
                                {
                                    tempAttachment.Width = attachmentsImage[i].Width.Value;
                                    tempAttachment.Height = attachmentsImage[i].Height.Value;
                                }
                            }
                            else
                            {
                                if (hkatfarki > 1)
                                {
                                    tempAttachment.Width = (int)(attachmentsImage[i].Width.Value / hkatfarki);
                                    tempAttachment.Height = (int)(attachmentsImage[i].Height.Value / hkatfarki);
                                }
                                else
                                {
                                    tempAttachment.Width = attachmentsImage[i].Width.Value;
                                    tempAttachment.Height = attachmentsImage[i].Height.Value;
                                }
                            }


                            tempAttachment.MouseDoubleClick += TempAttachmentImage_MouseDoubleClick;

                            tempAttachment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            tempAttachment.TabIndex = 27;
                            tempAttachment.TabStop = false;
                            tempAttachment.Visible = true;
                            tempAttachment.LoadAsync(attachmentsImage[i].Url);
                            TempLayoutImagePanel.Controls.Add(tempAttachment);
                            flowLayoutPanel1.Controls.Add(tempAttachment);

                        }

                        flowLayoutPanel1.Controls.Add(TempLayoutImagePanel);

                    }
                    #endregion

                    TempLayoutMessagePanel.Controls[0].Size = new Size(42, 42);



                });

            }


            return TempProfilePic;
        }

        #region TempAttachmentImage
        private void discordImageLabel_Changed(string txt)
        {
            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tempLabel.ForeColor = System.Drawing.Color.Firebrick;
            tempLabel.Location = new System.Drawing.Point(146, 562);
            tempLabel.MaximumSize = new System.Drawing.Size(680, 1000);
            tempLabel.Name = "discordImageLabel";
            tempLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            tempLabel.Size = new System.Drawing.Size(18, 28);
            tempLabel.TabIndex = 22;
            tempLabel.Text = "temp";
            ChatPanel.Controls.Add(tempLabel);
            tempLabel.TextChanged +=TempLabel_TextChanged;
            tempLabel.Text = txt;
        }
        private async void TempLabel_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            var label = (Label)sender;

            try
            {
                ChatPanel.Controls.Remove(label);
                label.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void DisposeTemp()
        {
            try
            {
                var m = ChatPanel.Controls.Find("discordImageLabel", true)[0];
                if (m != null)
                {
                    ChatPanel.Controls.Remove(m);
                    m.Dispose();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        private void TempAttachmentImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                var obj = (PictureBox)sender;

                int last = obj.Name.LastIndexOf('/');
                string name = obj.Name[(last + 1)..];

                if (e.Button == MouseButtons.Left)
                {
                    Process.Start(new ProcessStartInfo(obj.Name) { UseShellExecute = true });



                    DisposeTemp();
                    discordImageLabel_Changed(name + " opened.");


                }
                else if (e.Button == MouseButtons.Right)
                {
                    Clipboard.SetDataObject(obj.Image);

                    DisposeTemp();
                    discordImageLabel_Changed(name + " copied to clipboard.");

                }
                else if (e.Button == MouseButtons.Middle)
                {


                    if (!File.Exists(resourcesPath + "\\Discord Downloaded\\" + name))
                    {
                        obj.Image.Save(resourcesPath + "\\Discord Downloaded\\" + name);


                        DisposeTemp();
                        discordImageLabel_Changed(name + " saved.");
                        Console.WriteLine(name);
                    }
                    else
                    {
                        int num = 0;
                        string replacedName = name.Replace(Path.GetFileNameWithoutExtension(resourcesPath
                               +  "\\Discord Downloaded\\" + name), Path.GetFileNameWithoutExtension(resourcesPath + "\\Discord Downloaded\\" + name) + num);

                        while (File.Exists(resourcesPath + "\\Discord Downloaded\\" + replacedName))
                        {
                            num++;
                            replacedName = name.Replace(Path.GetFileNameWithoutExtension(resourcesPath
                               +  "\\Discord Downloaded\\" + name), Path.GetFileNameWithoutExtension(resourcesPath + "\\Discord Downloaded\\" + name) + num);
                        }



                        obj.Image.Save(resourcesPath + "\\Discord Downloaded\\" + replacedName);

                        DisposeTemp();
                        discordImageLabel_Changed(replacedName + " opened.");

                    }

                }

            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }

        }
        #endregion

        #endregion


    }
}
