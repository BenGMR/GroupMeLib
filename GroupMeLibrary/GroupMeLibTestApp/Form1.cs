using GroupMeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupMeLibTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoGrabber info = new InfoGrabber("G8ASG3y6qqityZLznv5vQAhFH5Vgmwnj6fVgytsV");

            try
            {
                //Group[] groups = info.GetGroups();
                //Group group = info.GetGroupByID(2449248);

                //MessageResponse msg = info.GetGroupMessages(2449248);

                //MessageBox.Show(msg.Messages.Count.ToString());

                //GroupResponse grp = info.GetFormerGroups();

                info.CreateGroup("DELETEME");
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


