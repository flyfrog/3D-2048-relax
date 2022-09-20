using System;

public class ScoreController
{
    private int _score = 0;
    public event Action<int> onScoreChangedEvent; 
    
    public void AddScore(int scoreArg)
    {
        _score += scoreArg;
        ScoreChanged();
    }

 

    private void ScoreChanged()
    {
        onScoreChangedEvent?.Invoke(GetScore());
    }

    public int GetScore()
    {
        return _score;
    }

}