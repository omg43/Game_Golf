using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Card : MonoBehaviour
    {
        public event Action<Card> Click;

        public Stone currentStone;
        [SerializeField] private string m_cardDescription;
        [SerializeField] private string m_cardName;
        [SerializeField] private Image m_icon;

        [SerializeField] private TextMeshProUGUI m_typeText;
        [SerializeField] private TextMeshProUGUI m_nameText;
        [SerializeField] private TextMeshProUGUI m_descriptionText;
        [SerializeField] private Button m_button;

        public CardType Type;
        public enum CardType
        {
            Count,LevelUp   
        } 

        public void SetCard(Stone stone, CardType type)
        {
            Type = type;
            m_nameText.text = stone.projectile.ProjectileName;
            m_descriptionText.text = stone.projectile.ProjectileDescription;
            if (Type == Card.CardType.Count)
            {
                m_typeText.text = "Уведичивает шанс выпадения";
            }
            else { m_typeText.text = "Улучшает снаряд"; }
            currentStone = stone;

            m_button.onClick.AddListener(OnCardClick);
        }
        public void OnCardClick()
        {
            Click?.Invoke(this);
        }
    }
}
