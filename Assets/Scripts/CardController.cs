using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class CardController : MonoBehaviour 
    {
        [SerializeField] private Stone[] m_prefs;
        [SerializeField] private GameObject m_cardPref;
        [SerializeField] private StomeSpawner m_spawner;
        [SerializeField] private Transform m_panel;
        [SerializeField] private GamePlayState m_state;
        
        private List<Stone> m_currentPrefs = new();
        private List<Stone> m_newPrefs = new();
        private List<GameObject> m_Cards = new();

        public int countCards;
        private void Start()
        {
            //BuildCard();
        }
        public void BuildCard()
        {
            int count = 0;
            m_newPrefs?.Clear();
            for (int i = 0; i < m_prefs.Length; i++)
            {
                Projectile currentProjectile = m_prefs[i].projectile;
                if (currentProjectile.level < currentProjectile.maxLevel)
                {
                    m_newPrefs.Add(m_prefs[i]);
                }
            }
            while (count < countCards)
            {
                if (m_newPrefs != null)
                {
                    int rand = Random.Range(0, 10);
                    Debug.Log("rand" + rand);
                    if (rand > 5)
                    {
                        Stone stone = m_newPrefs[Random.Range(0, m_newPrefs.Count)];
                        var card = Instantiate(m_cardPref, m_panel.transform.position, m_panel.rotation);
                        card.transform.SetParent(m_panel);
                        Card _card = card.GetComponent<Card>();
                        _card.SetCard(stone, Card.CardType.LevelUp);
                        _card.Click += OnSetCard;
                        _card.Click += m_state.OnCardClick;
                        m_newPrefs.Remove(stone);
                        m_currentPrefs.Add(stone);
                        m_Cards.Add(card);
                    }
                    else
                    {
                        Stone stone = m_prefs[Random.Range(0, m_prefs.Length)];
                        var card = Instantiate(m_cardPref, m_panel.transform.position, m_panel.rotation);
                        card.transform.SetParent(m_panel);
                        Card _card = card.GetComponent<Card>();
                        _card.SetCard(stone, Card.CardType.Count);
                        _card.Click += OnSetCard;
                        _card.Click += m_state.OnCardClick;
                        m_currentPrefs.Add(stone);
                        m_Cards.Add(card);
                    }
                }
                else
                {
                    Stone stone = m_newPrefs[Random.Range(0, m_newPrefs.Count)];
                    var card = Instantiate(m_cardPref, m_panel.transform.position, m_panel.rotation);
                    card.transform.SetParent(m_panel);
                    Card _card = card.GetComponent<Card>();
                    _card.SetCard(stone, Card.CardType.Count);
                    _card.Click += OnSetCard;
                    _card.Click += m_state.OnCardClick;
                    m_currentPrefs.Add(stone);
                    m_Cards.Add(card);

                }
                m_spawner.SetPrefsList(m_currentPrefs);
                count++;
            }
            
        }
        private void OnSetCard(Card card)
        {
            if (card.Type == Card.CardType.Count)
            {
                m_currentPrefs.Add(card.currentStone);
            }
            else
            {
                card.currentStone.projectile.OnLevelUp();
            }
            for(int i = 0; i < m_Cards.Count; i++)
            {
                Destroy(m_Cards[i]);
            }
            m_Cards.Clear();
        }
    }
}
