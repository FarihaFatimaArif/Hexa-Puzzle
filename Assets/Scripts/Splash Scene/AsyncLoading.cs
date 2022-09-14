using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoading : MonoBehaviour
{
    //[SerializeField] AdSystem AdsSystem;
    [SerializeField] Slider LoadingBar;
    [SerializeField] AdSystem AdSystem;
    [SerializeField] IAPShop IAPShop;
    //int maxScenes = 2; 
   // int sceneNo;
    // Start is called before the first frame update
    void Start()
    {
        AdSystem.InitializingAdSystem();
        IAPShop.Initialize();
        StartCoroutine(LoadScene(1));
    }
    public void LoadNextScene(int scene)
    {
       StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(int index)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        //Don't let the Scene activate until you allow it to
        //asyncOperation.allowSceneActivation = true;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            LoadingBar.value = asyncOperation.progress * 100;
            yield return null;
        }
    }
}
