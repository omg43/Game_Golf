using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stone : MonoBehaviour
{
    public event Action<Stone> Hit;
    public event Action<Stone> Missed;

    private Rigidbody m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stick>())
        {
            Hit?.Invoke(this);
        }
        else
        {
            Missed?.Invoke(this);
        }
    }
    public void AddForce(Vector3 force)
    {
        m_rb.AddForce(force, ForceMode.Force);
    }
}
