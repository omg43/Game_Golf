using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private int m_misseCount;
    [SerializeField] private StomeSpawner spawner;
    [SerializeField] [Min(0)] private float m_spanwRate = 0.5f;

    private int m_currentMisseCount;
    private float m_time;
    [SerializeField] private ScoreMeneger m_scoreMeneger;

    [Header("Score")]
    [SerializeField] private Text m_scoreText;
    private int m_score = 0;

    private void Awake()
    {
        m_currentMisseCount = m_misseCount;
        ScoreUp(0);
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
        Unsibscribe(stone);

        m_scoreMeneger.Increase();
    }

    private void OnMissed(Stone stone)
    {
        Unsibscribe(stone);
        if (m_currentMisseCount <= 0)
        {
            Debug.Log("Game over");
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
