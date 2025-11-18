using UnityEngine;

public class GameStateMashine : MonoBehaviour
{
    [SerializeField] private MainMenuState m_MainMenuState;
    [SerializeField] private BootstrapState m_boostrapState;
    [SerializeField] private GamePlayState m_gamePlayState;
    private void Awake()
    {
        m_boostrapState.Initisialize(this);
        m_MainMenuState.Inicialize(this);
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
            m_MainMenuState.Enter();
        }
        if (typeof(T) == typeof(BootstrapState))
        {
            m_boostrapState.Enter();
        }
    }
}
