using Assets.Scripts;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class ScoreMeneger : MonoBehaviour
{
    public event Action<int> ScoreChanged;
    public event Action<int> RecordChanged;

    private int m_score;
    public int record
    {
        get => PlayerPrefs.GetInt(GlobalContants.Record, 0);
        private set
        {
            var temp = PlayerPrefs.GetInt(GlobalContants.Record, 0);
            if (temp < value) {
                PlayerPrefs.SetInt(GlobalContants.Record, score);
                RecordChanged?.Invoke(value);
            }
        }
    }
    public int score {  
        get =>  m_score;
        private set
        {
            m_score = value;
            Debug.Log($"Score: {score}");
            ScoreChanged?.Invoke(value);
        }
    }
    public void UpdateRecord()
    {
        var record = PlayerPrefs.GetInt(GlobalContants.Record, 0); // 0 в данном случае дефолтное состояние(если ничего достать не вышло)
        if (record < score)
        {
            PlayerPrefs.SetInt(GlobalContants.Record, score);
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
