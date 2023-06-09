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

![image](https://github.com/tomokusaba/BuildJapanAIHandsonDay1-1/assets/46523924/9df68407-6cd6-4985-b2df-47396037d139)
Azure OpenAI Studioのデプロイ名の欄に表示されているテキストを設定する。

### BaseUrl,Key

![image](https://github.com/tomokusaba/BuildJapanAIHandsonDay1-1/assets/46523924/6ec07df4-b2d8-4d4d-99b5-dc92ab5635a3)
Azure PortalのAzureOpenAIのリソース内のキーとエンドポイントにあるエンドポイント及びキー（どちらでもOK）を設定する。


### BingKey

![image](https://github.com/tomokusaba/BuildJapanAIHandsonDay1-1/assets/46523924/8b5220c3-7dee-4fb0-8410-4db5c6a33ceb)
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
