using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        const string APPID = "f60c8bef270c9daafabf72106d01a008";
        string cityName = "Colombo";
        public Form1()
        {
            InitializeComponent();
            getWeather("Surabaya");
            getForecast("Surabaya");
        }
        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6",city,APPID);
                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<weatherInfo.Root>(json);
                weatherInfo.Root outPut = result;
                label1.Text = string.Format("{0}", outPut.name);
                label2.Text = string.Format("{0}", outPut.sys.country);
                label3.Text = string.Format("{0} \u00B0C", outPut.main.temp);

                picture_Main.Image = setIcon(outPut.weather[0].icon);
            }

        }
        void getForecast(string city)
        {
            int day = 5;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt={1}&APPID=542ffd081e67f4512b705f89d2a611b2", city, day, APPID);
            using (WebClient web = new WebClient())
            {
                
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<weatherForcast>(json);

                weatherForcast forcast = Object;
                //tomorrow
                label4.Text = string.Format("{0}", getDate(forcast.list[1].dt).DayOfWeek);//returning date
                label5.Text = string.Format("{0}", forcast.list[1].weather[0].main);//weather condition
                label6.Text = string.Format("{0}", forcast.list[1].weather[0].description);//weather description
                label8.Text = string.Format("{0} \u00B0C", forcast.list[1].temp.day);//weather temp
                label7.Text = string.Format("{0} km/h", forcast.list[1].speed);//weather speed
                

                //aftertomorrow
                label14.Text = string.Format("{0}", getDate(forcast.list[2].dt).DayOfWeek);//returning date
                label13.Text = string.Format("{0}", forcast.list[2].weather[0].main);//weather condition
                label12.Text = string.Format("{0}", forcast.list[2].weather[0].description);//weather description
                label10.Text = string.Format("{0} \u00B0C", forcast.list[2].temp.day);//weather temp
                label11.Text = string.Format("{0} km/h", forcast.list[2].speed);//weather speed

                //aftertomorrowwww
                label19.Text = string.Format("{0}", getDate(forcast.list[3].dt).DayOfWeek);//returning date
                label18.Text = string.Format("{0}", forcast.list[3].weather[0].main);//weather condition
                label17.Text = string.Format("{0}", forcast.list[3].weather[0].description);//weather description
                label15.Text = string.Format("{0} \u00B0C", forcast.list[3].temp.day);//weather temp
                label16.Text = string.Format("{0} km/h", forcast.list[3].speed);//weather speed

                //aftertomorrowwww
                label24.Text = string.Format("{0}", getDate(forcast.list[4].dt).DayOfWeek);//returning date
                label23.Text = string.Format("{0}", forcast.list[4].weather[0].main);//weather condition
                label22.Text = string.Format("{0}", forcast.list[4].weather[0].description);//weather description
                label20.Text = string.Format("{0} \u00B0C", forcast.list[4].temp.day);//weather temp
                label21.Text = string.Format("{0} km/h", forcast.list[4].speed);//weather speed


                //weather Icon Forecast
                pic_1.Image = setIcon(forcast.list[1].weather[0].icon);
                pic_2.Image = setIcon(forcast.list[2].weather[0].icon);
                pic_3.Image = setIcon(forcast.list[3].weather[0].icon);
                pic_4.Image = setIcon(forcast.list[4].weather[0].icon);
             
            }
        }

        DateTime getDate(double millisecound)
        {

            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecound).ToLocalTime();

            return day;
        }

        Image setIcon(string iconID)
        {
            string url = string.Format("http://openweathermap.org/img/w/{0}.png",iconID);//weather ison resource
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
                using (var weatherIcon=response.GetResponseStream())
            {
                Image weatherImg = Bitmap.FromStream(weatherIcon);
                return weatherImg;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.Text = "Digital Clock"; //To set the title
            timer1.Start(); //starting the timer
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txt_cityname.Text != "")
            {
                getWeather(txt_cityname.Text);
                getForecast(txt_cityname.Text);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txt_cityname.Text != "")
            {
                getWeather(txt_cityname.Text);
                getForecast(txt_cityname.Text);
            }
        }

        private void txt_cityname_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //to display the time in the label
           clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
