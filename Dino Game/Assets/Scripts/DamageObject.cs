using UnityEngine;

public class DamageObject : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 0.5f);
    }
}
