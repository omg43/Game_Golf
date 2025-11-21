using UnityEngine;

public class GameStateMashine : MonoBehaviour
{
    [SerializeField] private MainMenuState m_MainMenuState;
    [SerializeField] private BootstrapState m_boostrapState;
    [SerializeField] private GamePlayState m_gamePlayState;
    [SerializeField] private GameOverState m_gameOverState;
    private void Awake()
    {
        m_boostrapState.Initisialize(this);
        m_MainMenuState.Inicialize(this);
        m_gamePlayState.Initisialize(this);
        m_gameOverState.Initisialize(this);
    }
    private void Start()
    {
        Enter<BootstrapState>();
    }
    public void Enter<T>()
    {
        if(typeof(T) == typeof(GamePlayState))
        {
            m_MainMenuState.Exit();
            m_gamePlayState.Enter();
        }
        if (typeof(T) == typeof(MainMenuState))
        {
            m_boostrapState.Exit();

            m_gameOverState.Exit();

            m_MainMenuState.Enter();
        }
        if (typeof(T) == typeof(GameOverState))
        {
            m_gamePlayState.Exit();
            m_gameOverState.Enter();
        }
        if (typeof(T) == typeof(BootstrapState))
        {
            m_boostrapState.Enter();
        }
    }
}
