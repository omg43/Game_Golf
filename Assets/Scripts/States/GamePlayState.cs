using Golf;
using TMPro;
using UnityEngine;

public class GamePlayState : MonoBehaviour
{
    [SerializeField] private GameStateMashine m_gameStateMashine;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private GameStateMashine m_gameMashine;
    [SerializeField] private LevelController m_levelController;

    [SerializeField] private TextMeshPro m_scoreText;
    public void Enter ()
    {
        m_scoreText
    }
    public void Exit ()
    {
        m_levelController.enabled = true;
        m_player.enabled = true;
    }
    public void Initisialize(GameStateMashine gameStateMashine)
    {
        m_scoreText.gameObject.SetActive(false);
        m_gameStateMashine = gameStateMashine;
    }
}
