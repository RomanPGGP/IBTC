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
using HtmlAgilityPack;
using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            /********************************************* WEB SCRAPING ***************************************/
            string url = $"https://instagram.com/explore/tags/{this.hashtag}/";

            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");

            IWebDriver dr = new ChromeDriver(options);
            dr.Navigate().GoToUrl(url);
            var res = dr.FindElements(By.ClassName("FFVAD"));
            string finalUrl;

            foreach (var el in res)
            {
                var fUrl = el.GetAttribute("srcset").ToString();
                finalUrl = fUrl.Substring((fUrl.LastIndexOf(',')+1), (fUrl.LastIndexOf(' ')-(fUrl.LastIndexOf(',') + 1)) );
                URLList.Add(finalUrl);

            }

            /***************************************** END WEB SCRAPING ***************************************/
            
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
