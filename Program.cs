using System.Text;

var headers = new Dictionary<string, string>
{
    { "Host", "cat-match.easygame2021.com" },
    { "Connection", "keep-alive" },
    { "t", "抓包t" },
    { "ContentType", "application/json" },
    { "UserAgent", "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 MicroMessenger/8.0.26(0x18001a34) NetType/WIFI Language/zh_CN" },
    { "Referer", "https://servicewechat.com/wx141bfb9b73c970a9/15/page-frame.html" },
};

var num = 100;
for (int i = 0; i < num; i++)
{
   var response=  Get("https://cat-match.easygame2021.com/sheep/v1/game/game_over?rank_score=1&rank_state=1&rank_time=10&rank_role=1&skin=1", headers);

    Console.WriteLine(response);
}


string Get(string url, Dictionary<string, string> headers)
{
    string result = "";
    try
    {
        var httpclient = new HttpClient();
        if (headers != null && headers.Any())
        {
            foreach (var item in headers)
            {
                httpclient.DefaultRequestHeaders.Add(item.Key, item.Value);
            }
        }


        var response = httpclient.GetAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            Stream myResponseStream = response.Content.ReadAsStreamAsync().Result;
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            result = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
        }
    }
    catch (Exception ex)
    {
        throw ex;
    }
    return result;
}
