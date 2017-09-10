QcloudSmsSharp: 非官方腾讯云短信接口封装
===
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
