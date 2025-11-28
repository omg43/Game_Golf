using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public event Action Finished;
    public event Action<int> HealthChanged;
    public event Action Hit;
    public event Action Missed;

    [Header("Spawn")]
    [SerializeField] private int m_healthCount;
    [SerializeField] private ScoreMeneger m_scoreMeneger;
    [SerializeField] private StomeSpawner m_stoneSpawner;
    [Min(0)] public float m_spanwRate = 0.5f;

    [Min(1)] [SerializeField] private int m_maxHealth = 2;
    private int m_currentHealthCount;
    public int currentHealthCount
    {
        get => m_currentHealthCount;
        private set
        {
            m_currentHealthCount = value;
            if(m_currentHealthCount > m_maxHealth)
            {
                m_currentHealthCount = m_maxHealth;
            }
            HealthChanged?.Invoke(value);
        }
    }
    private float m_time;
    private List<Stone> m_stones;

    private void Awake()
    {
        m_stones = new List<Stone>();
    }

    public void Initialize()
    {
        m_currentHealthCount = m_healthCount;
    }

    public void ChangeMaxHealt()
    {
        m_maxHealth++;
    }

    public void IncreaseHealth(int heal)
    {
        currentHealthCount += heal;
    }

    public void DecreaseHealth(int damage)
    {
        currentHealthCount -= damage;
        if (currentHealthCount <= 0)
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

    public void RemoveStone(Stone stone)
    {
        m_stones.Remove(stone); 
    }

    private void Update()
    {
        m_time += Time.deltaTime;

        if (m_time >= m_spanwRate)
        {
            Stone stone = m_stoneSpawner.Spawn();
            m_stones.Add(stone);
            
            stone.levelController = this;
            stone.AddScore += OnAddScore;
            stone.RemoveHp += OnDecreseHealth;

            m_time = 0;
        }
    }

    private void OnAddScore(Stone stone)
    {
        Unsubscribe(stone);
        m_scoreMeneger.Increase(stone.score);
    }

    private void OnDecreseHealth(Stone stone)
    {
        Unsubscribe(stone);
        DecreaseHealth(stone.projectile.damage);
    }

    private void Unsubscribe(Stone stone)
    {
        stone.RemoveHp -= OnAddScore;
        stone.AddScore -= OnDecreseHealth;
    }
}
