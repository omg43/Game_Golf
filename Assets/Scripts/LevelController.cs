using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public event Action Finished;

    [Header("Spawn")]
    [SerializeField] private int m_misseCount;
    [SerializeField] [Min(0)] private float m_spanwRate = 0.5f;
    [SerializeField] private ScoreMeneger m_scoreMeneger;
    [SerializeField] private StomeSpawner m_stoneSpawner;

    private int m_currentMisseCount;
    private float m_time;
    private List<Stone> m_stones;

    [Header("Score")]
    [SerializeField] private Text m_scoreText;
    private int m_score = 0;

    private void Awake()
    {
        m_stones = new List<Stone>();
        ScoreUp(0);
    }

    public void Initialize()
    {
        m_currentMisseCount = m_misseCount;
    }

    private void Update()
    {
        m_time += Time.deltaTime;

        if (m_time >= m_spanwRate)
        {
            Stone stone = m_stoneSpawner.Spawn();
            m_stones.Add(stone);

            stone.Hit += OnHitStone;
            stone.Missed += OnMissed;

            m_time = 0;
        }
    }

    private void OnHitStone(Stone stone)
    {
        Unsibscribe(stone);

        m_scoreMeneger.Increase();
    }

    private void OnMissed(Stone stone)
    {
        Unsibscribe(stone);

        m_currentMisseCount--;
        if (m_currentMisseCount <= 0)
        {
            Debug.Log("Game over");

            Finished?.Invoke();

            foreach (var item in m_stones)
            {
                Destroy(item.gameObject);
            }

            m_stones.Clear();
        }
    }

    private void Unsibscribe(Stone stone)
    {
        stone.Missed -= OnMissed;
        stone.Hit -= OnHitStone;
    }

    public void ScoreUp(int _score)
    {
        m_score += _score;

        m_scoreText.text = $"Score: {m_score}";
    }
}
