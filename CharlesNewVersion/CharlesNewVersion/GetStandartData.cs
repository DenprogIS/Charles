using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CharlesNewVersion
{
    class GetStandartData
    {
        public string getWeather()
        {
            try
            {
                WebRequest request = WebRequest.Create(@"http://www.meteoservice.ru/weather/now/zlatoust.html");
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                string data = reader.ReadToEnd();
                data = data.Substring(data.IndexOf("Температура воздуха") + 50, 100);
                data = data.Substring(data.IndexOf("<td>") + 4, data.IndexOf("&") - data.IndexOf("<td>") - 4);
                if ((data[0] == '+') && (Convert.ToInt32(data) > 15))
                    data = "Сегодня довольно таи жарко сэр " + Convert.ToInt32(data) + " градусов тепла";
                else if (data[0] == '+')
                    data = "Сегодня холодновато сэр советую одеться потеплее" + Convert.ToInt32(data) + " градусов тепла";
                else
                    data = "На улице достаточно холодно" + Convert.ToInt32(data) + " градусов ниже ноля";
                return data;
            }catch(Exception ex)
            {
                return "К сожалению не могу подключится к сайту от которого я получаю погоду";
            }
        }
    }
}
