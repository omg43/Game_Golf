using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Scripting.APIUpdating;

namespace Assets.Scripts.Old
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FreeCamera m_camera;
        [SerializeField] private GameObject m_uiPanel;
        [SerializeField] private CloudController m_cloudController;

        [SerializeField] private KeyCode ChangeButton;
        [SerializeField] private ChangeTool m_changeTool;
        private void Update()
        {
            if (m_uiPanel.activeSelf)
            {
                return;
            }
            m_camera.Move();
            if (Input.GetKey(KeyCode.Space))
            {
                m_cloudController.MoveNext();
            }
            if (Input.GetKey(ChangeButton))
            {
                m_changeTool.ChangeVillagersTool();
            }
        }
    }
}
