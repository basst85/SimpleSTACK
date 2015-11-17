using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography;

namespace SimpleSTACK
{
    public partial class Form1 : Form
    {
        string userAgent = "SimpleSTACK v1.0 - info@nednu.nl";
        static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

        public Form1()
        {
            InitializeComponent();

            filesTree.AllowDrop = true;
            filesTree.DragEnter += filesTree_DragEnter;
            filesTree.DragDrop += filesTree_DragDrop;
            filesTree.MouseEnter += new System.EventHandler(filesTree_MouseEnter);
        }


        private void filesTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private async void filesTree_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (String file in files)
            {
                //Upload dropped file
                await UploadFileAsync(file);
            }
        }

        private void filesTree_MouseEnter(object sender, System.EventArgs e)
        {
                toolTip1.SetToolTip(this.filesTree, "Drop file(s) here to uploads");
        }

        private void ManipulateUI(Action action)
        {
            this.Invoke(action);
        }


        //Encrypt password in Config-file
        private string Crypt(string text)
        {
            return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.Unicode.GetBytes(text), s_aditionalEntropy, DataProtectionScope.CurrentUser));
        }
        //Decrypt password from Config-file
        private string Decrypt(string text)
        {
            return Encoding.Unicode.GetString(
                ProtectedData.Unprotect(
                     Convert.FromBase64String(text), s_aditionalEntropy, DataProtectionScope.CurrentUser));
        }

        public async Task<HttpResponseMessage> UploadFileAsync(string absoluteFilePath)
        {
            var length = new FileInfo(absoluteFilePath).Length;
            var fileName = new FileInfo(absoluteFilePath).Name;

            string url = stackUrl.Text + fileName;
            string credentials = userName.Text + ":" + password.Text;

            try
            {
                WebRequest uploadRequest = WebRequest.Create(url);
                uploadRequest.Headers["UserAgent"] = userAgent;
                uploadRequest.Method = "PUT";
                uploadRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
                uploadRequest.ContentLength = length;
                const int chunkSize = 2048;
                var buffer = new byte[chunkSize];
                TimeSpan elapsedTime = TimeSpan.Zero;

                using (var req = await uploadRequest.GetRequestStreamAsync())
                using (var readStream = File.OpenRead(absoluteFilePath))
                {
                    ManipulateUI(() => this.uploadProgress.Value = 0);
                    int read = 0;
                    DateTime started = DateTime.Now;
                    for (int i = 0; i < length; i += read)
                    {
                        read = await readStream.ReadAsync(buffer, 0, chunkSize);
                        await req.WriteAsync(buffer, 0, read);
                        await req.FlushAsync(); 
                        ManipulateUI(() => this.uploadProgress.Value = (int)(100.0 * i / length));
                    }
                    elapsedTime = DateTime.Now - started;
                    ManipulateUI(() => this.uploadProgress.Value = 0);
                    ManipulateUI(() => this.textUploadSpeed.Text = Convert.ToString(Math.Round((((length / 1024) / elapsedTime.TotalSeconds) / 1024),2)+" MB/s"));
                }

                var response = (HttpWebResponse)await uploadRequest.GetResponseAsync();
                var result = new HttpResponseMessage(response.StatusCode);
                result.Content = new StreamContent(response.GetResponseStream());
                getFiles();

                return result;

            }
            catch (WebException wEx)
            {
                MessageBox.Show(Convert.ToString(wEx.Status));
                return null;
            }catch (Exception Ex)
            {
                MessageBox.Show(Convert.ToString(Ex.Message));
                return null;
            }
        }

        private void getFiles()
        {
            string url = stackUrl.Text;
            string credentials = userName.Text + ":" + password.Text;
            toolTip1.Active = false;

            //Connect and get files
            try
            {
                WebRequest filesRequest = WebRequest.Create(url);
                filesRequest.Headers["UserAgent"] = userAgent;
                filesRequest.Method = "PROPFIND";
                filesRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
                filesRequest.Timeout = 10000; //10 seconds

           
                WebResponse wr = filesRequest.GetResponse();
                Stream receiveStream = wr.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                string content = reader.ReadToEnd();

                string filesPat = "(?<=<d:href>)(.*?)(?=</d:href>)";
                string availableBytesPat = "(?<=<d:quota-available-bytes>)(.*?)(?=</d:quota-available-bytes>)";
                MatchCollection matchFiles = Regex.Matches(content, filesPat);
                MatchCollection matchAvailableBytes = Regex.Matches(content, availableBytesPat);

                textFreeSpace.Text = Convert.ToString(Math.Round(((Convert.ToDouble(matchAvailableBytes[1].Value) / 1024) / 1024) / 1024));

                filesTree.Nodes.Clear();
                foreach (Match match in matchFiles)
                {
                    if (match.Value != "/remote.php/webdav/")
                    {
                        filesTree.BeginUpdate();
                        string fileParentNode;
                        fileParentNode = match.Value.Replace("/remote.php/webdav/", "").Trim();
                        filesTree.Nodes.Add(fileParentNode);
                        filesTree.EndUpdate();
                    }
                }

            }catch(WebException wEx)
            {
                MessageBox.Show(Convert.ToString(wEx.Status));
            }catch(Exception Ex)
            {
                MessageBox.Show(Convert.ToString(Ex.Message));
            }
}


        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Save settings in Config-file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Config.xml");

            XmlElement urlElement = (XmlElement)xmlDoc.SelectSingleNode("/config/url");
            XmlElement usernameElement = (XmlElement)xmlDoc.SelectSingleNode("/config/username");
            XmlElement passwordElement = (XmlElement)xmlDoc.SelectSingleNode("/config/password");

            if (urlElement != null && usernameElement != null && passwordElement != null)
            {
                usernameElement.SetAttribute("value", userName.Text); 
                passwordElement.SetAttribute("value", Crypt(password.Text));
                urlElement.SetAttribute("value", stackUrl.Text);
            }
            xmlDoc.Save("Config.xml");

            getFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load settings from Config-file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Config.xml");

            XmlElement urlElement = (XmlElement)xmlDoc.SelectSingleNode("/config/url");
            XmlElement usernameElement = (XmlElement)xmlDoc.SelectSingleNode("/config/username");
            XmlElement passwordElement = (XmlElement)xmlDoc.SelectSingleNode("/config/password");

            if (urlElement != null && usernameElement != null && passwordElement != null)
            {
                stackUrl.Text = urlElement.GetAttribute("value");
                userName.Text = usernameElement.GetAttribute("value");
                password.Text = Decrypt(passwordElement.GetAttribute("value"));
                
            }

        }

    }
}
