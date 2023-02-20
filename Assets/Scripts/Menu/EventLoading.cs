using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventLoading : MonoBehaviour
{
    [SerializeField] public GameObject loadingScreen, rawVideo;
    [SerializeField] public Slider loadingBar;
    [SerializeField] private float delayBeforeLoading; // Untuk menunggu delay 10 detik
    [SerializeField] public string namaScene;
    private float timeElapsed = -1f; // Untuk waktu yang telah berlalu
    

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)
        {
            rawVideo.SetActive(false);
            loadingScreen.SetActive(true);
            StartCoroutine(LoadSceneAsynchronously(namaScene));
        }
    }

    private IEnumerator LoadSceneAsynchronously(string namaScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(namaScene);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }

}
