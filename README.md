QcloudSmsSharp: 非官方腾讯云短信接口封装
===

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/JoyMoe/QcloudSmsSharp/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/QcloudSmsSharp.svg)](https://www.nuget.org/packages/QcloudSmsSharp)
![net451](https://img.shields.io/badge/.Net-4.5.1-brightgreen.svg)
![net462](https://img.shields.io/badge/.Net-4.6.2-brightgreen.svg)
![netstandard1.3](https://img.shields.io/badge/.Net-netstandard1.3-brightgreen.svg)
![netstandard2.0](https://img.shields.io/badge/.Net-netstandard2.0-brightgreen.svg)

### 安装
使用 Package Manager Console 或 Nuget.
```powershell
PM> Install-Package QcloudSmsSharp
```

### 范例
```csharp
using QcloudSmsSharp;

var client = new QcloudSmsClient {
    AppId: "xxx",
    AppKey: "xxx",
};

var message = new QcloudSmsMessage {
    Tel: "+8613788888888",
    Msg: "你的验证码是1234",
};

var result = await client.SendAsync(message);
```

## 待办

* [x] SendISMS
* [ ] SendSMS

## 协议

MIT 协议

详见 [LICENSE](LICENSE).
