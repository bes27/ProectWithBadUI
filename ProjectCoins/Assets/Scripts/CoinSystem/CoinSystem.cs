using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public GameObject BigCoin;
    public GameObject SmallCoin;

    private const string bigCoin = "BigCoin";
    private const string smallCoin = "SmallCoin";

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(bigCoin))
        {
            if (Input.GetKey(KeyCode.E))
            {
                ScoreManager.Instance.AddScore(2);
                Destroy(BigCoin);
            }
        }
        else if (collider.gameObject.CompareTag(smallCoin))
        {
            ScoreManager.Instance.AddScore(1);
            Destroy(SmallCoin);
        }
    }
}