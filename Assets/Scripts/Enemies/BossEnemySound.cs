using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    // private Coroutine playAudioAndWaitCoHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayAudioAndWait());
        }
    }


    private IEnumerator PlayAudioAndWait()
    {
        AudioManager.Instance.StopBackgroundMusic();
        audioSource.PlayOneShot(audioClip);

        yield return new WaitForSeconds(audioClip.length);
        AudioManager.Instance.PlayBackgroundMusic();

        Destroy(gameObject);
    }
}
