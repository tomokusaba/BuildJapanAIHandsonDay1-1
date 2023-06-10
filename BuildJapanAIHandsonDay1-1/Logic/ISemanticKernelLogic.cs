using Microsoft.SemanticKernel.AI.ChatCompletion;

namespace BuildJapanAIHandsonDay1_1.Logic
{
    public interface ISemanticKernelLogic
    {
        public IChatCompletion ChatCompletion { get; set; }
        public string GeneratedHtml { get; set; }
        public event Action? OnChange;


        public void ClearChatHistory();
        public Task StreamRun(string message);
    }
}
