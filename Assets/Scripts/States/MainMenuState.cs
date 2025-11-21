using Assets.Scripts.Old;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : MonoBehaviour
{
    [SerializeField] private Button m_playButton;
    
    [SerializeField] private GameObject m_mainMenuRoot ;
    private GameStateMashine m_gameStateMashine;

    public void Inicialize(GameStateMashine gameStateMashine) 
    {
        m_mainMenuRoot.SetActive(false);
        m_gameStateMashine = gameStateMashine;
    }

    public void Enter()
    {
        m_mainMenuRoot.SetActive(true);
        m_playButton?.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        m_gameStateMashine.Enter<GamePlayState>();
    }

    public void Exit()
    {
        m_mainMenuRoot?.SetActive(false);
        m_playButton?.onClick.RemoveListener(OnClicked);
    }
}
