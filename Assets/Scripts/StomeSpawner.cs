using UnityEngine;

public class StomeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] m_prefabs;
    [SerializeField] private Transform m_transform;

    public void Spawn()
    {
        var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
        Instantiate(prefab, m_transform.position,m_transform.rotation);
    }
}
