using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SeaBattle.Extensions;
using SeaBattle.Models;

namespace SeaBattle.Data;

public static class QuestionProcessor
{
    private const string QuestionFileName = "questions.json";

    private static readonly List<Question> UsedQuestions = new();

    public static Question GetRandomQuestion()
    {
        var allQuestions = GetQuestions();
        Question targetQuestion;
        try
        {
            targetQuestion = allQuestions.Where(x => !UsedQuestions.Contains(x)).ToList().GetRandom();
        }
        catch (Exception)
        {
            UsedQuestions.Clear();
            targetQuestion = allQuestions.GetRandom();
        }

        UsedQuestions.Add(targetQuestion);
        return targetQuestion;
    }

    public static void Init()
    {
        if (File.Exists(QuestionFileName)) return;
        var questionOne = new Question
        {
            Name = "Вопрос 1",
            Answer = "Ответ 1",
            Score = 10
        };
        var questionTwo = new Question
        {
            Name = "Вопрос 2",
            Answer = "Ответ 2",
            Score = 15
        };
        SaveQuestions(new[] {questionOne, questionTwo});
    }

    public static List<Question> GetQuestions()
    {
        return JsonConvert.DeserializeObject<List<Question>>(File.ReadAllText(QuestionFileName));
    }

    public static void SaveQuestions(IEnumerable<Question> questions)
    {
        File.WriteAllText(QuestionFileName,
            JsonConvert.SerializeObject(questions, new JsonSerializerSettings {Formatting = Formatting.Indented}));
    }
}
