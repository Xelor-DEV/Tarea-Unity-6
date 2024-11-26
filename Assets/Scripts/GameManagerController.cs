using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    private int puntos;
    public Text puntuacion;
    public Text scoretxt;
    public PlayerController playerController;
    public GameObject gameOverPanel;
    private bool isGameOver = false;
    private bool isPaused = false;

    public UserSessionData userSessionData;
    public DBScoreSender scoreSender;

    public void ReceiveUserId(string userID)
    {
        userSessionData.userId = int.Parse(userID);
        Debug.Log("user id: " + userID);
    }

    void Start()
    {
        isGameOver = false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        UpdatePoints(0);
    }

    public void UpdatePoints(int puntaje_del_enemigo)
    {
        puntos = puntos + puntaje_del_enemigo;
        puntuacion.text = "Score: " + puntos;
    }

    public void RestLives()
    {
        playerController.lives = playerController.lives - 1;
        if (playerController.lives < 0)
        {
            GameOver();
        }
        Debug.Log(playerController.lives);
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        scoretxt.text = "Score: " + puntos;
        gameOverPanel.SetActive(true);
        // Enviar el puntaje a la base de datos
        scoreSender.SendScoreToDatabase(puntos, userSessionData.userId);
    }

    public void RestartGame()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TogglePause()
    {
        if (isGameOver)
        {
            return;
        }

        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
