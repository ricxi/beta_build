using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int points = 5;
    [SerializeField] private GameObject popupCanvasPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScore player = collision.gameObject.GetComponent<PlayerScore>();
        if (player != null)
        {
            ShowPoints();
            player.UpdateScore(points);
            Destroy(gameObject);
        }
    }

    public void ShowPoints()
    {
        var popup = Instantiate(popupCanvasPrefab, transform.position, Quaternion.identity);
        var popupText = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        popupText.text = "+" + points;
    }
}
