using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public static SceneLoading Instance;
    [SerializeField] public GameObject loadingScreen;
    [SerializeField] public Slider loadingBar;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(string namaScene)
    {
        StartCoroutine(LoadSceneAsynchronously(namaScene));
    }

    IEnumerator LoadSceneAsynchronously(string namaScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(namaScene);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
