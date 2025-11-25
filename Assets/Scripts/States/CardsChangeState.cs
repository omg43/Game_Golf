using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.States
{
    public class CardsChangeState : StateBase
    {
        [SerializeField] private GameStateMashine m_gameStateMashine;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private ScoreMeneger m_scoreMeneger;
        [SerializeField] private ExperienceController m_experienceController;
        [SerializeField] private CardController m_cardController;

        [SerializeField] private GameObject m_gamePanel;
        

        public override void Enter()
        {
            m_gamePanel.SetActive(true);
            m_cardController.BuildCard();
        }

        public override void Exit()
        {
            
        }

        public override void Initialize(GameStateMashine gameStateMashine)
        {
            m_gamePanel.SetActive(false);
            m_gameStateMashine = gameStateMashine;
        }

        public void OnClicked()
        {
 
        }

    }
}
