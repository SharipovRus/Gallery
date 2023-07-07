using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;

    private float fakeLoadingTime = 3f; 

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadWithDelay(sceneIndex, fakeLoadingTime));
    }

    IEnumerator LoadWithDelay(int sceneIndex, float delay)
    {
        
        loadingScreen.SetActive(true);

        
        yield return new WaitForSeconds(delay);

       
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }
    }
}
