using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTimer;

    private float timeMax = 3;
    private int _counterScore;
    bool isTiming = false;
    bool isTakeIt = false;

    private void Start()
    {
        Instance = this;
        _counterScore = 0;

        _scoreTimer.text = _scoreTimer.ToString();
    }

    private void Update()
    {
        Timer();

        if (timeMax < 0)
        {
            timeMax = 3;

        }
    }

    private void Timer()
    {
        if (isTiming)
        {
            timeMax -= Time.deltaTime;
            _scoreTimer.text = Mathf.Round(timeMax).ToString();
            if(Time.deltaTime <= 0)
                isTiming = false;
            if(Time.deltaTime <= timeMax)
                isTakeIt = false;
        }
    }

    public void AddScore(int countAdd)
    {
        this._counterScore += countAdd;
        _scoreText.text = this._counterScore.ToString();
        isTiming = true;
        isTakeIt = true;
        EnableScore();
        TimerScore();
    }

    private void ClearScore()
    {
        this._counterScore = 0;
        _scoreText.text = this._counterScore.ToString();
    }

    private void EnableScore()
    {
        _scoreText.gameObject.SetActive(true);
        _scoreText.gameObject.transform.parent.gameObject.SetActive(true);
    }

    private void DisableScore()
    {
        _scoreText.gameObject.SetActive(false);
        _scoreText.gameObject.transform.parent.gameObject.SetActive(false);
        ClearScore();
    }

    private void TimerScore()
    {
        
            CancelInvoke();
            Invoke("DisableScore", 3);
        
    }
}
