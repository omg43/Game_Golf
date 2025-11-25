using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StomeSpawner : MonoBehaviour
{
    [SerializeField] private List<Stone> m_prefabs;
    [SerializeField] private Stone[] m_bomusPrefabs;
    [SerializeField] private Transform m_transform;

    public void SetPrefsList(List<Stone> m_prefabsNew)
    {
        m_prefabs = m_prefabsNew;
    }

    public Stone Spawn()
    {
        if (Random.Range(0, 100) <= 85)
        {
            var prefab = m_prefabs[Random.Range(0, m_prefabs.Count)];
            return Instantiate(prefab, m_transform.position, m_transform.rotation);
        }
        else
        {
            var prefab = m_bomusPrefabs[Random.Range(0, m_bomusPrefabs.Length)];
            return Instantiate(prefab, m_transform.position, m_transform.rotation);
        }
    }
}
