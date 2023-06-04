﻿using Markdig;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.ChatCompletion;

namespace BuildJapanAIHandsonDay1_1.Logic
{
    public class SemanticKernelLogic: ISemanticKernelLogic
    {
        private readonly ILogger<SemanticKernelLogic> _logger;
        private readonly IConfiguration _configuration;
        private OpenAIChatHistory chatHistory;
        public IChatCompletion ChatCompletion { get; set; }
        public string GeneratedHtml { get; set; } = string.Empty;

        public SemanticKernelLogic(ILogger<SemanticKernelLogic> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            // OpenAIChatCompletionServiceを使用するための設定を行います。
            // 以下の値はappsettings.jsonに追加してください
            string deploymentName = _configuration.GetValue<string>("DeploymentName") ?? string.Empty;
            string baseUrl = _configuration.GetValue<string>("BaseUrl") ?? string.Empty;
            string key = _configuration.GetValue<string>("Key") ?? string.Empty;

            // IKernelをインスタンス化します。
            
            IKernel kernel = new KernelBuilder()
                .WithLogger(_logger)
                // ChatCompletionServiceを使用するための設定を行います。
                
                .Build();

            // IChatCompletionをインスタンス化します。
            ChatCompletion = kernel.GetService<TODO>();

            // 引数にはプロンプトメッセージを記述します。：型はstring
            chatHistory = new OpenAIChatHistory();

        }

        public void ClearChatHistory()
        {
            // 引数にはプロンプトメッセージを記述します。：型はstring
            chatHistory = new OpenAIChatHistory();
        }

        public IList<ChatHistory.Message> GetChatHistory()
        {
            return chatHistory.Messages;
        }

        public async Task StreamRun(string input)
        {
            // chatHistoryにユーザーメッセージを追加します。

            // ChatReauestSettingsをインスタンス化しMaxTokensの値を設定します。
            // MaxTokensは生成されるテキストの長さを指定します。
            ChatRequestSettings settings = new ChatRequestSettings();



            string fullMessage = string.Empty;
            GeneratedHtml = string.Empty;
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseAutoLinks().UseBootstrap().UseDiagrams().UseGridTables().Build();

            // ChatCompletion.GenerateMessageStreamAsyncを使用して、生成されたテキストを取得します。
            await foreach (string message in  TODO)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    // fullMessageに生成されたテキストを追加します。


                    // 表示用のHTMLを生成します。
                    GeneratedHtml = Markdown.ToHtml(fullMessage, pipeline);
                    // 表示更新します
                    NotifyStateChanged();
                }
            }
            // chatHistoryに生成されたテキストを追加します。

        }

        private void NotifyStateChanged() => OnChange?.Invoke();
        public event Action? OnChange;
    }
}
