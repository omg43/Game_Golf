using UnityEngine;
using UnityEngine.UI;

public class ExperienceController : MonoBehaviour
{
    [SerializeField] private int m_experience;
    [SerializeField] private int m_currentExperience;

    [SerializeField] private Image m_expBar;

    [SerializeField] private float m_rationExperience;
    [SerializeField] private int m_amountAddExperience;

    [SerializeField] private int level;

    [SerializeField] private GameObject m_upgradeButton;
    [SerializeField] private GameObject Bar;
    [SerializeField] private bool canUp;
    public void ExperienceUpdate(int score)
    {
        if (!canUp) { return; }
        m_currentExperience += score;
        Debug.Log($"Update level: {(float)m_currentExperience / (float)m_experience}");
        m_expBar.fillAmount = (float)m_currentExperience / (float)m_experience;
        if(m_currentExperience >= m_experience)
        {
            NewcurrentExperience();
            level++;
        }
    }
    public void NewcurrentExperience()
    {
        m_currentExperience = 0;

        m_experience += (int)Mathf.Round(m_experience * m_rationExperience);
        canUp = false;
        Bar.SetActive(false);
        m_upgradeButton.SetActive(true);
        Debug.Log($"New Need exp for next level: {m_experience}");
        Debug.Log($"Level: {level}");
        ExperienceUpdate(0);
    }

    public void Set()
    {
        Bar.SetActive(true);
        m_upgradeButton.SetActive(false);
        canUp = true;
    }
}
