using TMPro;
using UnityEngine;
using Golf;
using UnityEngine.UI;
using Assets.Scripts.States;
using Assets.Scripts;
public class GameOverState : StateBase
{
    [SerializeField] private GameStateMashine m_gameStateMashine;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private GameStateMashine m_gameMashine;
    [SerializeField] private LevelController m_levelController;

    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private Button m_backOnMenu;
    [SerializeField] private ScoreMeneger m_scoreMeneger;

    public override void Initialize(GameStateMashine gameStateMashine)
    {
        m_gameOverPanel.SetActive(false);
        m_gameStateMashine = gameStateMashine;
    }

    public override void Enter()
    {
        m_scoreText.text = m_scoreMeneger.score.ToString();
        m_scoreMeneger.UpdateRecord();
       
        m_backOnMenu.onClick.AddListener(OnClicked);
        m_gameOverPanel.SetActive(true);   
    }

    public override void Exit()
    {
        m_gameOverPanel.SetActive(false);
    }

    public void OnClicked() => m_gameStateMashine.Enter<MainMenuState>();
}
