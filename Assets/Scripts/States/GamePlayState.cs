using Assets.Scripts;
using Assets.Scripts.States;
using Golf;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayState : StateBase
{
    [SerializeField] private GameStateMashine m_gameStateMashine;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private LevelController m_levelController;
    [SerializeField] private ScoreMeneger m_scoreMeneger;
    [SerializeField] private ExperienceController m_experienceController;
    [SerializeField] private CardController m_cardController;

    [SerializeField] private GameObject m_cardPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_scoreAddText;
    [SerializeField] private GameObject m_gamePanel;
    [SerializeField] private Animator m_scoreAddTextAnim;
    [SerializeField] private AnimationClip m_scoreAddTextClip;

    [SerializeField] private TextMeshProUGUI m_healthText;
    [SerializeField] private Button m_levelUpButton;

    public override void Initialize(GameStateMashine gameStateMashine)
    {
        m_gamePanel.SetActive(false);
        m_gamePanel.SetActive(false);
        m_gameStateMashine = gameStateMashine;
    }

    public override void Enter ()
    {
        m_scoreMeneger.Reset();
        m_scoreMeneger.ScoreChanged += OnScoreChanged;
        m_scoreMeneger.ScoreIncrease += m_experienceController.ExperienceUpdate;
        m_scoreMeneger.ScoreIncrease += OnScoreAddAnimate;
        m_levelUpButton.onClick.AddListener(OnCardPanel);

        m_levelController.HealthChanged += OnHealthChanged;

        OnScoreChanged(m_scoreMeneger.score);
        m_gamePanel.SetActive(true);
        m_cardPanel.SetActive(false);

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

    private void OnCardPanel()
    {
        m_cardController.BuildCard();
        m_gamePanel.SetActive(false);
        m_cardPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnCardClick(Card card)
    {
        Time.timeScale = 1;
        m_gamePanel.SetActive(true);
        m_levelUpButton.gameObject.SetActive(false);
        m_cardPanel.SetActive(false);
        m_experienceController.Set();
    }

    private void OnScoreAddAnimate(int score)
    {
        m_scoreAddText.text = "+" + score.ToString();
        m_scoreAddTextAnim.SetTrigger("AddScore");
    }

    private void OnHealthChanged(int health)
    {
        m_healthText.text = "X" + health.ToString();
    }

    public override void Exit ()
    {
        m_levelController.enabled = false;
        m_player.enabled = false;
        m_gamePanel.SetActive(false);
        m_levelController.Finished -= OnFinished;
    }
}
