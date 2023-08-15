using UnityEngine;

public class SmallCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                ScoreManager.Instance.AddScore(1);
                Destroy(gameObject);
            }
        }
    }
}
