using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreMeneger : MonoBehaviour
{
    private int m_score;
    public int score {  
        get =>  m_score;
        private set
        {
            m_score = value;
            Debug.Log($"Score: {score}");
            ScoreChanger?.Invoke(value);
        }
    }
    public event Action<int> ScoreChanger;
    public void Increase()
    {
        score++;
    }
}
