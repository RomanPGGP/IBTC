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

        public List<string> URLList;
        public List<PictureBox> mpictureBoxList;
        public bool menuButtonStatus;
        public int picCount;
        public int startIdxMultiplePic;
        private DataEntry nf;
        private string hashtag;

        public Form1()
        {
            InitializeComponent();

            URLList = new List<string>();
            mpictureBoxList = new List<PictureBox>();
            menuButtonStatus = false;
            picCount = 0;
            startIdxMultiplePic = 0;
            nf = new DataEntry();
            nf.ShowDialog();
            hashtag = nf.hashtag;

        }

        private async void PictureRun()
        {
            pictureBox5.Visible = true;

            foreach(var x in mpictureBoxList)
            {
                x.Visible = false;
            }

            while(true)
            {
                pictureBox5.Load(URLList[picCount]);
                await Task.Delay(3000);

                if (picCount < URLList.Count - 1) picCount++;
                else picCount = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            URLList.Add("https://instagram.fybz2-1.fna.fbcdn.net/v/t51.2885-15/sh0.08/e35/p640x640/271504351_308103961244040_1522017175046928482_n.jpg?_nc_ht=instagram.fybz2-1.fna.fbcdn.net&_nc_cat=100&_nc_ohc=uSn-SLk2WIIAX-zwKS6&edm=AABBvjUBAAAA&ccb=7-4&oh=00_AT_QhrCYs2KG9bFWzbODFJi7thBv67NgPuIatVyH77kfsQ&oe=61E4B013&_nc_sid=83d603");
            URLList.Add("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c0.180.1440.1440a/s320x320/271707888_4436707746441197_8127476869909200540_n.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=105&_nc_ohc=Ch_EwjJ70bsAX_hx7Tf&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT95omRmHk0wLfdrYZS3eTBVvm8hKuULjen60KWiM0UbAg&oe=61E67EC7&_nc_sid=4efc9f");
            URLList.Add("https://scontent-ort2-1.cdninstagram.com/v/t51.2885-15/e35/c0.180.1440.1440a/s320x320/271685323_877231649621326_3411743587545147676_n.jpg?_nc_ht=scontent-ort2-1.cdninstagram.com&_nc_cat=110&_nc_ohc=QvSAd3DQXh0AX94AGKS&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT8F3B4FrNHaLK0R6P9meSIzyb1rosauU4ilnfAcjNh1jQ&oe=61E7072B&_nc_sid=4efc9f");
            URLList.Add("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c206.0.1027.1027a/s320x320/271699102_341378500921311_8191562311863249144_n.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=103&_nc_ohc=keJKoa3jqToAX--P0tM&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT8mCT25_eIUB9Yl23MiS0a6ATscKfPznbZ0R8ei-uyiCQ&oe=61E66DF4&_nc_sid=4efc9f");
            URLList.Add("https://scontent-ort2-1.cdninstagram.com/v/t51.2885-15/e15/s150x150/271698907_1142288066307095_1317717531748329506_n.jpg?_nc_ht=scontent-ort2-1.cdninstagram.com&_nc_cat=111&_nc_ohc=1Ud-rMRkC0wAX-KKwl3&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT9dpah_abGBExpJ6rqJfEBT7qc4EfZTKTednjO4RH-FTQ&oe=61E97920&_nc_sid=4efc9f");
            URLList.Add("https://scontent-ort2-1.cdninstagram.com/v/t51.2885-15/e35/s240x240/271823702_875638209786500_3542777999052915078_n.jpg?_nc_ht=scontent-ort2-1.cdninstagram.com&_nc_cat=108&_nc_ohc=xh89scwbC4kAX-_73h2&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT_zkw1rS77ZBpWn2e92QBOBBsTgZts3yktvHwO1O8QwLQ&oe=61E854A4&_nc_sid=4efc9f");
            URLList.Add("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c0.135.1080.1080a/s240x240/271821942_639101990741618_3772260340532783282_n.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=102&_nc_ohc=oRTXVYz8ePgAX8APFx9&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT-atx2w3fKYNdSzjpSPIdLn0LQ8L39pH_ovG7KCbqREzg&oe=61E9D676&_nc_sid=4efc9f");
            URLList.Add("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c0.135.1080.1080a/s240x240/271786653_1113765986106147_1955750903485021845_n.webp.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=103&_nc_ohc=jl3K3lQAuTIAX9NlcKP&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT9_unxpxDLtkDTfLMpVXwOEw1SBhD4hYA3HX00EpJ42_g&oe=61E8660E&_nc_sid=4efc9f");
            URLList.Add("https://instagram.fybz2-2.fna.fbcdn.net/v/t51.2885-15/e35/c91.0.898.898a/s240x240/271701270_1548170918873751_6726203783489082744_n.webp.jpg?_nc_ht=instagram.fybz2-2.fna.fbcdn.net&_nc_cat=103&_nc_ohc=Aid_-JGcFCQAX8kN85Q&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT_jeNLvVx679xhA5Ni1OvJwhGeylxAqU5P5Fxn83WRTTA&oe=61E847DE&_nc_sid=4efc9f");
            URLList.Add("https://scontent-ort2-1.cdninstagram.com/v/t51.2885-15/e35/c0.180.1440.1440a/s240x240/271863312_922140421820070_2754568721239939887_n.jpg?_nc_ht=scontent-ort2-1.cdninstagram.com&_nc_cat=106&_nc_ohc=Dog9wdob0YYAX_yapWY&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT914dF_v4dSvVq9jp9o8wC8xs3XTf0M-kK5cROpNlhaDQ&oe=61E99509&_nc_sid=4efc9f");
            URLList.Add("https://instagram.fybz2-1.fna.fbcdn.net/v/t51.2885-15/e35/c0.180.1440.1440a/s240x240/271787352_294796442673181_7643525998340185751_n.jpg?_nc_ht=instagram.fybz2-1.fna.fbcdn.net&_nc_cat=101&_nc_ohc=mHspJ2qcb6EAX8YUxAN&edm=ABZsPhsBAAAA&ccb=7-4&oh=00_AT9jz-hVedqnXE_UWJrEEGwqnrmpNG9pZFaZ82I8CuBnwg&oe=61E91FB6&_nc_sid=4efc9f");

            mpictureBoxList.Add(pictureBox1);
            mpictureBoxList.Add(pictureBox2);
            mpictureBoxList.Add(pictureBox3);
            mpictureBoxList.Add(pictureBox4);
           
            Shown += Form1_Show;

        }

        private void Form1_Show(object sender, EventArgs e)
        {
            PictureRun();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!menuButtonStatus)
            {
                if (picCount < URLList.Count-1) picCount++;
                else picCount = 0;

                pictureBox5.Load(URLList[picCount]);
            }
            else
            {
                foreach (var x in mpictureBoxList)
                {
                    if (startIdxMultiplePic < URLList.Count-1) startIdxMultiplePic++;
                    else startIdxMultiplePic = 0;
                    x.Load(URLList[startIdxMultiplePic]);
                }
            }


        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (!menuButtonStatus)
            {
                if (picCount > 0) picCount--;
                else picCount = URLList.Count - 1;

                pictureBox5.Load(URLList[picCount]);
            }
            else
            {
                foreach (var x in mpictureBoxList)
                {
                    x.Load(URLList[startIdxMultiplePic]);
                    if (startIdxMultiplePic > 0) startIdxMultiplePic--;
                    else startIdxMultiplePic = URLList.Count - 1;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            menuButtonStatus = !menuButtonStatus;

            if(menuButtonStatus)
            {
                pictureBox5.Visible = false;

                foreach (var x in mpictureBoxList)
                {
                    x.Visible = true;
                    x.Load(URLList[startIdxMultiplePic]);
                    if(startIdxMultiplePic < URLList.Count) startIdxMultiplePic++;
                    else startIdxMultiplePic = 0;
                }
            }
            else
            {
                pictureBox5.Visible = true;
                foreach (var x in mpictureBoxList)
                {
                    x.Visible = false;
                }
            }
        }
    }
}
