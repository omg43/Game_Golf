using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private StomeSpawner spawner;
    [SerializeField] [Min(0)] private float m_spanwRate = 0.5f;
    private float m_time;
    private void Update()
    {
        if(m_time >= m_spanwRate)
        {
            spawner.Spawn();
            m_time = 0;
        }
        m_time += Time.deltaTime;
    }
}
