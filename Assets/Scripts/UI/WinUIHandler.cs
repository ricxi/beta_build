using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string StartScreenSceneName;
    [SerializeField] private string FirstLevelSceneName;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            foreach (var pgo in GameManager.Instance.PersistentGameObjects)
            {
                if (pgo.name == "Player")
                {
                    PlayerScore ps = pgo.GetComponent<PlayerScore>(); // Maybe perform a null check
                    scoreText.text = "SCORE:\n" + ps.Score;
                    Destroy(pgo);
                }

                if (pgo.name == "PlayerUIManager")
                {
                    Destroy(pgo);
                }

                if (pgo.name == "PlayerUI")
                    Destroy(pgo);
            }
        }
    }

    public void OnRestartButtonClicked()
    {
        GameManager.Instance.DestroyAll();
        SceneManager.LoadScene(FirstLevelSceneName);
    }

    public void OnMainMenuButtonClicked()
    {
        GameManager.Instance.DestroyAll();
        SceneManager.LoadScene(StartScreenSceneName);
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

}
