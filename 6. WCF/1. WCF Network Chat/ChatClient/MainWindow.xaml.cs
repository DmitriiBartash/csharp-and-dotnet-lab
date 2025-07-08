using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using ChatClient.ServiceChat;

namespace ChatClient
{
    public partial class MainWindow : Window, IServiceChatCallback
    {
        private ServiceChatClient client;
        private int userId = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Connect button
        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            try
            {
                string username = tbName.Text; 
                var callback = new InstanceContext(this);
                client = new ServiceChatClient(callback);

                userId = await Task.Run(() => client.Connect(username));

                Dispatcher.Invoke(() =>
                {
                    btnConnect.IsEnabled = false;
                    btnDisconnect.IsEnabled = true;
                    btnSend.IsEnabled = true;
                    tbName.IsEnabled = false;
                    lbChat.Items.Add("You are connected.");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }


        // Disconnect button
        private async void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client != null && userId != -1)
                {
                    await Task.Run(() => client.Disconnect(userId));
                    client.Close();
                    userId = -1;
                }

                Dispatcher.Invoke(() =>
                {
                    btnConnect.IsEnabled = true;
                    btnDisconnect.IsEnabled = false;
                    btnSend.IsEnabled = false;
                    tbName.IsEnabled = true;
                    lbChat.Items.Add("You are disconnected.");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnection failed: " + ex.Message);
            }
        }

        // Send message button
        private async void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string message = tbMessage.Text;

            if (string.IsNullOrWhiteSpace(message))
                return;

            tbMessage.Clear();

            try
            {
                await Task.Run(() => client.SendMessage(message, userId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send message: " + ex.Message);
            }
        }

        // Callback from server
        public void MessageCallBack(string message)
        {
            Dispatcher.Invoke(() =>
            {
                lbChat.Items.Add(message);
                lbChat.ScrollIntoView(message);
            });
        }

        // Handle graceful disconnect on window close
        protected override async void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            try
            {
                if (client != null && userId != -1)
                {
                    await Task.Run(() => client.Disconnect(userId));
                    client.Close();
                }
            }
            catch { }
        }
    }
}
