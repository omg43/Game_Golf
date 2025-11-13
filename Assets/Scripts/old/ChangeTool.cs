using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTool : MonoBehaviour
{
    [SerializeField] private Mesh[] tools;
    [SerializeField] private KeyCode ChangeButton;
    [SerializeField] private GameObject[] villagers;

    public void ChangeVillagersTool()
    {
        for (int i = 0; i < villagers.Length; i++)
        {
            villagers[i].GetComponent<MeshFilter>().mesh = tools[Random.Range(0, tools.Length)];
        }
    }
}
