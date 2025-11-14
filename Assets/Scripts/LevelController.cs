using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int m_misseCount;
    [SerializeField] private StomeSpawner spawner;
    [SerializeField] [Min(0)] private float m_spanwRate = 0.5f;

    private int m_currentMisseCount;
    private float m_time;

    private void Awake()
    {
        m_currentMisseCount = m_misseCount;
    }
    private void Update()
    {
        if(m_time >= m_spanwRate)
        {
            Stone stone = spawner.Spawn();

            stone.Hit += OnHitStone;
            stone.Missed += OnMissed;

            m_time = 0;
        }
        m_time += Time.deltaTime;
    }
    private void OnHitStone(Stone stone)
    {
        stone.Hit -= OnHitStone;
        stone.Missed -= OnMissed;

        Debug.Log("Score");
    }
    private void OnMissed(Stone stone)
    {
        stone.Hit -= OnHitStone;
        stone.Missed -= OnMissed;
        m_currentMisseCount--;
        if(m_currentMisseCount <= 0)
        {
            Debug.Log("Game over");
        }
    }
}
