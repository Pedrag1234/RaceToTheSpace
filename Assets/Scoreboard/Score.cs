using System;

[Serializable]
public class Score
{
    public string score;
    public int seconds;

    public Score(string score, int seconds)
    {
        this.seconds = seconds;
        this.score = score;
    }
}
