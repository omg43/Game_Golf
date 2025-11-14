using System;
using UnityEngine;

public class Stone : MonoBehaviour
{
    
    public event Action<Stone> Hit;
    public event Action<Stone> Missed;
    
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
}
