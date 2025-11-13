using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CollisionWithGround();
        }

        if (collision.gameObject.CompareTag("Club"))
        {
            CollisionWithClub();
        }
    }
   
    private void CollisionWithGround()
    {
        Debug.Log("Камень упал на землю");
        Destroy(gameObject, 3f);
    }

    private void CollisionWithClub()
    {
        Debug.Log("По камню ударили клюшкой");
    }
}
