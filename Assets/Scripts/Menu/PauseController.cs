using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public UnityEvent gamePaused;
    public UnityEvent gameResumed;

    public bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                GamePaused();
            }
            else
            {
                GameResumed();
            }
        }
    }

    public void GamePaused()
    {
        Time.timeScale = 0;
        isPaused = true;
        gamePaused.Invoke();
    }

    public void GameResumed()
    {
        Time.timeScale = 1;
        isPaused = false;
        gameResumed.Invoke();
    }

    public void GameExit(string namescene)
    {
        SceneLoading.Instance.LoadScene(namescene);
        Time.timeScale = 1;
        isPaused = false;
        gameResumed.Invoke();
        Debug.Log("Berhasil Pindah Scene " + namescene);
        SceneManager.LoadScene(namescene);
    }
}
