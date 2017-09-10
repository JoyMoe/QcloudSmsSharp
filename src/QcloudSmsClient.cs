using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace QcloudSmsSharp
{
    public class QcloudSmsClient
    {
        private const string endpoint = "https://yun.tim.qq.com/v5/tlssmssvr/{0}?sdkappid={1}&random={2}";

        private string _appId;
        private string _appKey;

        public string AppId { set { _appId = value; } }

        public string AppKey { set { _appKey = value; } }

        public QcloudSmsClient() { }

        public QcloudSmsClient(string appId, string appKey)
        {
            _appId = appId;
            _appKey = appKey;
        }

        public async Task<QcloudSmsResult> SendAsync(QcloudSmsMessage message)
        {
#if NET451
            var time = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).Ticks / TimeSpan.TicksPerSecond;
#else
            var time = DateTimeOffset.Now.ToUnixTimeSeconds();
#endif
            var random = RandomString(10);

            message.Time = time;
            message.Sig = Sign($"random={random}&time={time}&tel={message.Tel}");

            var msg = message.ToString();

            var content = new StringContent(msg, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var query = await client.PostAsync(string.Format(endpoint, "sendisms", _appId, random), content);
                var result = await query.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QcloudSmsResult>(result);
            }
        }

        private string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string Sign(string data)
        {
            data = $"appkey={_appKey}&{data}";
            using (var hashAlgorithm = SHA256.Create())
            {
                var hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
