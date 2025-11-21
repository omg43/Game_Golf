using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class ScoreMeneger : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    private int m_score;
    public int score {  
        get =>  m_score;
        private set
        {
            m_score = value;
            Debug.Log($"Score: {score}");
            ScoreChanged?.Invoke(value);
        }
    }
    public void Increase()
    {
        score++;
    }
    public void Reset()
    {
        score = 0;
    }
}
