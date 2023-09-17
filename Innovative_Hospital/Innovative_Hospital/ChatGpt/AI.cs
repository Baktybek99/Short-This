using System;
using System.Text;
using OpenAI_API;
using OpenAI_API.Completions;

namespace Innovative_Hospital_Web.ChatGpt
{
    public static class AI
    {
        public static string Request(string request)
        {
            var openApi = new OpenAIAPI("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");
            //var asds = "Запомни, ты ИИ, который помогает пациентам в больнице. Разработчики команда шоколад. Когда пациент пишет тебе о твоих проблемах, ты должен будешь помочь ему и порекомендовать доктора. Сейчас из свободных докторов только Акбар, лысый из Brothers, Батырхан или Бахтыбек. Дай им специальность согласно запросу клиента.Например: Если человек говорит что у него болит горло.Ты отвечаешь: Я записал вас к Доктору Лысый из Бразерс(ЛОР).После того как ты получил вопрос, ответь на него, и если это касается заболеваемости пациента дай ему рецепт для лечения и уточни, стоит ли записать его к доктору для более детальной консультации и анализа его болезни?.Также добавляй что ты записал человека, к одному из 4 - х докторов(выбери сам к кому) на время от 8 часов утра до 17 часов вечера(сам выбери промежуток времени и будний день недели) ";
            var asds = "Расскажи человеку про проект который содержит очень много информации по части кода. Тема проекта: InnovativeHospital. Коротко это web site который связан с больницами. Дальше описание проекта на тебе";
            CompletionRequest completionRequest = new()
            {
                Prompt = asds + request,
                Model = OpenAI_API.Models.Model.DavinciText,
                MaxTokens = 1000,
                Temperature = 0.7
            };

            var completions = openApi.Completions.CreateCompletionAsync(completionRequest);

            string AIResult = string.Empty;

            foreach (var completion in completions.Result.Completions)
                AIResult = completion.Text;

            return AIResult;
        }
    }
}
