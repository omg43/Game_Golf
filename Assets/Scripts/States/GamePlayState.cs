using Golf;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayState : MonoBehaviour
{
    [SerializeField] private GameStateMashine m_gameStateMashine;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private GameStateMashine m_gameMashine;
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private ScoreMeneger m_scoreMeneger;

    [SerializeField] private TextMeshProUGUI m_scoreText;

    public void Initisialize(GameStateMashine gameStateMashine)
    {
        m_scoreText.gameObject.SetActive(false);
        m_gameStateMashine = gameStateMashine;
    }

    public void Enter ()
    {
        m_scoreMeneger.Reset();
        m_scoreMeneger.ScoreChanged += OnScoreChanged;

        OnScoreChanged(m_scoreMeneger.score);
        m_scoreText.gameObject.SetActive(true);

        m_levelController.enabled = true;
        m_player.enabled = true;
        m_levelController.Initialize();

        m_levelController.Finished += OnFinished;
    }

    private void OnFinished() => m_gameStateMashine.Enter<GameOverState>();

    private void OnScoreChanged(int score)
    {
        m_scoreText.text = score.ToString();
    }

    public void Exit ()
    {
        m_levelController.enabled = false;
        m_player.enabled = false;
        m_scoreText.gameObject.SetActive(false);
        m_levelController.Finished -= OnFinished;
    }
}
