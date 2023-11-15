using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public struct ScoreLine
    {
        public int score;
        public string name;
        public ScoreLine(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
        public string asString()
        {
            return score.ToString() + " - " + name;
        }
        public struct Comparer : IComparer<ScoreLine>
        {
            public int Compare(ScoreLine x, ScoreLine y)
            {
                return y.score - x.score;
            }
        }
    }
    private static UIManager _instance;

    private string defPlayerName = "Anonymous";
    private GameDataScript gameData;

    public List<ScoreLine> bestScores;
    public bool showQuitButton;

    public string playerName
    {
        get { return gameData.playerName; }
    }
    public UIManager()
    {
        bestScores = new List<ScoreLine>();
        bestScores.Add(new ScoreLine(99999999, "God"));
        bestScores.Add(new ScoreLine(152, "George"));
        bestScores.Add(new ScoreLine(53, "Alice"));
        bestScores.Add(new ScoreLine(22, "Andrew"));
        bestScores.Add(new ScoreLine(1, "Idk"));
        bestScores.Sort(new ScoreLine.Comparer());

        gameData = (GameDataScript) ScriptableObject.CreateInstance("GameDataScript");
        gameData.LoadPlayerName();
        SetPlayerName(gameData.playerName);

        showQuitButton = false;
    }
    public void AddScoreLine(int score)
    {
        bestScores.Add(new ScoreLine(score, gameData.playerName));
        bestScores.Sort(new ScoreLine.Comparer());
        if (bestScores.Count > 5)
        {
            bestScores.RemoveAt(bestScores.Count - 1);
        }
    }
    public void SetPlayerName(string text)
    {
        string checkText = text.Replace(" ", "");
        gameData.playerName = text;
        if (checkText.Length < 2)
        {
            gameData.playerName = defPlayerName;
        }
        gameData.SavePlayerName();
    }
    public static UIManager Instance()
    {
        if (_instance == null)
        {
            _instance = new UIManager();
        }
        return _instance;
    }
}