using UnityEngine;

public class BigCoin : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                ScoreManager.Instance.AddScore(2);
                Destroy(gameObject);
            }
        }
    }
}
