using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;

public static class LoadLvl
{
    private class LoadMonoBehaviour : MonoBehaviour { }
    private static Action onLoadCallback;
    public static void StartLoad(E_Scenes scenes)
    {
        onLoadCallback = () =>
        {
            SceneManager.LoadSceneAsync(scenes.ToString());
        };

        GameObject loadingGameObject = new GameObject("loading GO");
        loadingGameObject.AddComponent<LoadMonoBehaviour>().StartCoroutine(LoadLvlAsync(E_Scenes.Load));
    }

    private static IEnumerator LoadLvlAsync(E_Scenes scenes)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenes.ToString());
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public static void LoadCallback()
    {
        if (onLoadCallback != null)
        {
            onLoadCallback();
            onLoadCallback = null;
        }
    }
}
