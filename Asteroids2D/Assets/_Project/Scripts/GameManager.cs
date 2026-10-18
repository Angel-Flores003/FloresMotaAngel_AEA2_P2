using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game settings")]
    [SerializeField] private int startingLives = 3;

    [Header("UI (Phase 7)")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameOverPanel;

    private int score;
    private int lives;

    // fem això perquè els altres scripts només o puguin llegir però no modificar aquest valor.
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        // TODO: Singleton (igual que amb les pools).
        if (Instance != null && Instance != this)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        // TODO: inicialitza el joc.
        //   score = 0, lives = startingLives, IsGameOver = false
        //   amaga el panell GameOver
        //   Crida UpdateUI().
        score = 0;
        lives = startingLives;
        IsGameOver = false;
        gameOverPanel.SetActive(false);
        UpdateUI();
    }

    // Cridat pel Asteroid quan aquest és destruït.
    public void AddScore(int points)
    {
        // TODO: afegeix punts a la UI i actualitza-la.
        score += points;
        UpdateUI();
    }

    // Cridat pel Asteroid quan impacta amb el player.
    public void LoseLife(int amount)
    {
        // TODO: Resta amount a lives i actualitza la UI.
        //       si lives < 0 GameOver().
        //       Extra: si el joc ja ha terminat no facis res
        lives -= amount;
        UpdateUI();
        
        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // TODO:
        //     IsGameOver = true
        //     Fes aparèixer el panell de GameOver
        //     Congela el joc Time.timeScale = 0
        IsGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Assigna aquest mètode al Restart button: On Click () al Inspector.
    public void RestartGame()
    {
        // TODO:
        //     Time.timeScale = 1   (si no fas això reiniciarà congelat)
        //     fes un reload de l'escena:
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        IsGameOver = false;
        //gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateUI()
    {
        // TODO: escriu les vides i els punts als textos.
        //   Exemple: scoreText.text = "Punts: " + score;
        scoreText.text = "Punts: " + score;
        livesText.text = "Vides: " + lives;
    }
}