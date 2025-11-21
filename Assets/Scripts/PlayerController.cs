using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Stick m_stick;

        [SerializeField] private EventTrigger m_hitButton;

        private bool m_isDown;
        private void Update()
        {
            if (m_isDown)
            {
                m_stick.Down();
            }
            else
            {
                m_stick.Up();
            }
        }
        private void Start()
        {
            var entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;

            var entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;

            entryUp.callback.AddListener(OnPointUp);
            entryDown.callback.AddListener(OnPointDown);

            m_hitButton.triggers.Add(entryUp);
            m_hitButton.triggers.Add(entryDown);
        }

        private void OnPointDown(BaseEventData arg0)
        {
            Down();
            Debug.Log("PointDown");
        }
        private void OnPointUp(BaseEventData arg0)
        {
            Up();
            Debug.Log("PointUp");
        }
        private void Up() => m_isDown = false; 
        
        private void Down() => m_isDown = true;
    }
}
