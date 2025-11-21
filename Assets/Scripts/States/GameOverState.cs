using TMPro;
using UnityEngine;
using Golf;
using UnityEngine.UI;
public class GameOverState : MonoBehaviour
{
    [SerializeField] private GameStateMashine m_gameStateMashine;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private GameStateMashine m_gameMashine;
    [SerializeField] private LevelController m_levelController;

    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private Button m_backOnMenu;
    [SerializeField] private ScoreMeneger m_scoreMeneger;

    public void Initisialize(GameStateMashine gameStateMashine)
    {
        m_gameOverPanel.SetActive(false);
        m_gameStateMashine = gameStateMashine;
    }

    public void Enter()
    {
        m_scoreText.text = m_scoreMeneger.score.ToString();
        m_backOnMenu.onClick.AddListener(OnClicked);
        m_gameOverPanel.SetActive(true);   
    }

    public void Exit()
    {
        m_gameOverPanel.SetActive(false);
    }

    public void OnClicked() => m_gameStateMashine.Enter<MainMenuState>();
}
