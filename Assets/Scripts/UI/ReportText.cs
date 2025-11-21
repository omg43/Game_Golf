using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ReportText: MonoBehaviour
    {
        [SerializeField] private TMP_Text m_text;

        [SerializeField] private ScoreMeneger m_scoreManager;

        [SerializeField] private string m_format;

        private void OnValidate()
        {
            if (!m_text) { m_text = GetComponent<TMP_Text>(); } 
        }
        private void OnEnable()
        {
            m_scoreManager.RecordChanged += OnRecordChange;
        }

        private void OnRecordChange(int value)
        {
            m_format ??= string.Empty;
            m_text.text = value.ToString();
        }

        private void OnDisable()
        {
            m_scoreManager.RecordChanged -= OnRecordChange;
        }
    }
}
