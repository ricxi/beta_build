using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuHandler : MonoBehaviour
{
    [SerializeField] private string FirstLevelSceneName;
    [SerializeField] private string InstructionsSceneName;

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(FirstLevelSceneName);
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

    public void OnInstructionsButtonClicked()
    {
        Debug.Log("Instructions Scene to be created");
    }
}
