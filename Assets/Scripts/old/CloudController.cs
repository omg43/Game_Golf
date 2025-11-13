using System.Xml.Schema;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private Transform[] m_people;
    [SerializeField] private float m_speed;
    [SerializeField] private bool isMoved;

    private int m_index = -1;
    private Vector3 m_position;

    private void Start()
    {
        MoveNext();
    }

    public void MoveNext()
    {
        m_index++;
        if(m_index >= m_people.Length) { m_index = 0; }

        m_position =  m_people[m_index].position;
        m_position.y = transform.position.y;

        isMoved = true;
    }

    private void Update()
    {
        if (!isMoved) { return; }
        transform.position = Vector3.Lerp(transform.position, m_position, Time.deltaTime);
        if(Vector3.Distance(transform.position, m_position) < 0.1f)
        {
            isMoved = false;
        }
    }
}
