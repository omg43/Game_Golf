using UnityEngine;

public class StomeSpawner : MonoBehaviour
{
    [SerializeField] private Stone[] m_prefabs;
    [SerializeField] private Transform m_transform;

    public Stone Spawn()
    {
        var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
        return Instantiate(prefab, m_transform.position, m_transform.rotation);
    }
}
