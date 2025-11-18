using Assets.Scripts.Old;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : MonoBehaviour
{
    [SerializeField] private Button m_playButton;
    
    [SerializeField] private GameObject m_GameRoot;
    private GameStateMashine m_gameStateMashine;

    public void Inicialize(GameStateMashine gameStateMashine) 
    {
        m_gameStateMashine = gameStateMashine;
    }

    public void Enter()
    {
        m_GameRoot.SetActive(true);
        m_playButton?.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        m_gameStateMashine.Enter<GameObject>();
    }

    public void Exit()
    {
        m_GameRoot?.SetActive(false);
        m_playButton?.onClick.RemoveListener(OnClicked);
    }
}
