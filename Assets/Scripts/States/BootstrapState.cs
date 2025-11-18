using Golf;
using UnityEngine;

public class BootstrapState : MonoBehaviour
{
    [SerializeField]private PlayerController m_player;
    [SerializeField]private GameStateMashine m_gameMashine;
    [SerializeField] private LevelController m_levelController;
    public void Enter() 
    {
        m_gameMashine.Enter<MainMenuState>();
    }
    public void Exit() { }
    public void Initisialize(GameStateMashine gameStateMashine) 
    {
        m_levelController.enabled = false;
        m_player.enabled = false;

        m_gameMashine = gameStateMashine;
    }

}
