using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Fotone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/explore/tags/playakabbalah/");
            //label1.Text = myReq.HaveResponse.ToString();



            //HttpWebRequest request = WebRequest.Create("https://www.instagram.com/ajax/bz") as HttpWebRequest;

            ////request.Accept = "application/xrds+xml";  
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //WebHeaderCollection header = response.Headers;

            //var encoding = ASCIIEncoding.ASCII;
            //using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            //{
            //    Console.WriteLine(reader.ReadToEnd());
            //    //label1.Text = reader.ReadToEnd();
            //}

            pictureBox1.Load("https://instagram.fybz2-1.fna.fbcdn.net/v/t51.2885-15/sh0.08/e35/p640x640/271504351_308103961244040_1522017175046928482_n.jpg?_nc_ht=instagram.fybz2-1.fna.fbcdn.net&_nc_cat=100&_nc_ohc=uSn-SLk2WIIAX-zwKS6&edm=AABBvjUBAAAA&ccb=7-4&oh=00_AT_QhrCYs2KG9bFWzbODFJi7thBv67NgPuIatVyH77kfsQ&oe=61E4B013&_nc_sid=83d603");
            pictureBox2.Load("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c0.180.1440.1440a/s320x320/271707888_4436707746441197_8127476869909200540_n.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=105&_nc_ohc=Ch_EwjJ70bsAX_hx7Tf&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT95omRmHk0wLfdrYZS3eTBVvm8hKuULjen60KWiM0UbAg&oe=61E67EC7&_nc_sid=4efc9f");
            pictureBox3.Load("https://scontent-ort2-1.cdninstagram.com/v/t51.2885-15/e35/c0.180.1440.1440a/s320x320/271685323_877231649621326_3411743587545147676_n.jpg?_nc_ht=scontent-ort2-1.cdninstagram.com&_nc_cat=110&_nc_ohc=QvSAd3DQXh0AX94AGKS&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT8F3B4FrNHaLK0R6P9meSIzyb1rosauU4ilnfAcjNh1jQ&oe=61E7072B&_nc_sid=4efc9f");
            pictureBox4.Load("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c206.0.1027.1027a/s320x320/271699102_341378500921311_8191562311863249144_n.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=103&_nc_ohc=keJKoa3jqToAX--P0tM&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT8mCT25_eIUB9Yl23MiS0a6ATscKfPznbZ0R8ei-uyiCQ&oe=61E66DF4&_nc_sid=4efc9f");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox5.Load("https://instagram.fybz2-1.fna.fbcdn.net/v/t51.2885-15/sh0.08/e35/p640x640/271504351_308103961244040_1522017175046928482_n.jpg?_nc_ht=instagram.fybz2-1.fna.fbcdn.net&_nc_cat=100&_nc_ohc=uSn-SLk2WIIAX-zwKS6&edm=AABBvjUBAAAA&ccb=7-4&oh=00_AT_QhrCYs2KG9bFWzbODFJi7thBv67NgPuIatVyH77kfsQ&oe=61E4B013&_nc_sid=83d603");
            pictureBox5.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
