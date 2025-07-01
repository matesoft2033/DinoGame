using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource dieAudio;

    public float score = 0;
    public bool isGameOver = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1;
    }


    private void Update()
    {
        score += Time.deltaTime;
        int sortedScore = (int)score;
        scoreText.text = sortedScore.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        dieAudio.Play();
        gameOverUI.SetActive(true);
        Time.timeScale = 0;

    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
