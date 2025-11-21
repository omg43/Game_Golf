using Assets.Scripts.States;
using Golf;
using UnityEngine;

public class BootstrapState : StateBase
{
    [SerializeField]private PlayerController m_player;
    [SerializeField]private GameStateMashine m_gameMashine;
    [SerializeField] private LevelController m_levelController;

    public override void Initialize(GameStateMashine gameStateMashine)
    {
        m_levelController.enabled = false;
        m_player.enabled = false;

        m_gameMashine = gameStateMashine;
    }

    public override void Enter() 
    {
        m_gameMashine.Enter<MainMenuState>();
    }
    public override void Exit() { }

}
