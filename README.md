# BuildJapanAIHandsonDay1-1

## appsettings.jsonの記述について
```json:appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "DeploymentName": "",
  "BaseUrl": "",
  "Key": "",
  "BingKey": ""

}
```
### DeploymentName

![image](https://github.com/tomokusaba/BuildJapanAIHandsonDay1-1/assets/46523924/682f6b24-e816-4ea5-b38e-c95a83c65a1b)

Azure OpenAI Studioのデプロイ名の欄に表示されているテキストを設定する。

### BaseUrl,Key

![image](https://github.com/tomokusaba/BuildJapanAIHandsonDay1-1/assets/46523924/f227ed48-d987-4c9b-ad93-2adad8723a1e)

Azure PortalのAzureOpenAIのリソース内のキーとエンドポイントにあるエンドポイント及びキー（どちらでもOK）を設定する。


### BingKey

![image](https://github.com/tomokusaba/BuildJapanAIHandsonDay1-1/assets/46523924/6b744147-c31e-4fda-922f-b90c07acb217)

Azure PortalのBing Searchのリソース内のキーとエンドポイントにあるキー（どちらでもOK）を設定する。

## 参考コード

https://github.com/microsoft/semantic-kernel/blob/main/samples/dotnet/kernel-syntax-examples/Example33_StreamingChat.cs


# 追加演習(Bing Search)

Bing Searchの検索結果をプロンプトに追加することでAIに最新の情報を与え回答を補正することができます。

## 手順

- Microsoft.SemanticKernel.Skills.WebをNugetで追加
- BingConnectorをインスタンス化。引数はAPI Key
- SearchAsyncメソッドでbing検索。第一引数が検索キーワード、第二引数が検索件数
- 検索結果を1つの文字列にまとめてシステムメッセージとしてChatHistoryに追加
- 以下通常通りGenerateMessage

このとき、Bing検索したシステムメッセージが会話ごとに追加されるのはよろしくないので一時的なChatHistoryを作成しそれでGenerateしたほうが良さそう。
