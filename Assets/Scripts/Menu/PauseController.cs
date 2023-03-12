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
        AudioManager.Instance.PlaySFX("Klik");
        MouseLook.Instance.ShowCursor();
        Time.timeScale = 0;
        isPaused = true;
        gamePaused.Invoke();
    }

    public void GameResumed()
    {
        AudioManager.Instance.PlaySFX("Klik");
        MouseLook.Instance.HideCursor();
        Time.timeScale = 1;
        isPaused = false;
        gameResumed.Invoke();
    }

    public void GameExit(string namescene)
    {
        SceneLoading.Instance.LoadScene(namescene);
        MouseLook.Instance.ShowCursor();
        Time.timeScale = 1;
        isPaused = false;
        gameResumed.Invoke();
    }
}
