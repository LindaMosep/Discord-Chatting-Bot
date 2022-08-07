
using System;
using System.Windows.Forms;


namespace RoguelandsDiscordBot.Forms
{
    public partial class Form1 : Form
    {

        #region Values
        public bool focusedFirstTime;
        #endregion


        #region Update
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Form1()
        {
            InitializeComponent();


        }
        #endregion


        #region Chat Panel
        [STAThread]
        private void OpenChatPanelBut_click(object sender, EventArgs e)
        {
            SendMessageForm sendMessage = new SendMessageForm();
            sendMessage.Visible = true;
            CheckForIllegalCrossThreadCalls = false;



        }
        #endregion


        #region Start Discord API
        private async void StartBotBut_click(object sender, EventArgs e)
        {

            if (!Program.isLogged)
            {
                if (Program._client != null)
                {
                    if (Program._client.LoginState != Discord.LoginState.LoggingIn && Program._client.LoginState != Discord.LoginState.LoggedIn)
                    {
                        await Program.MainAsync();

                    }
                    else
                    {
                        StartBotServiceBut.Enabled = true;
                    }

                }
                else
                {
                    await Program.MainAsync();

                }

            }
            else
            {
                StartBotServiceBut.Enabled = false;
            }



        }
        #endregion


  
    }
}
