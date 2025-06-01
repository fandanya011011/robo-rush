using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    [SerializeField] private TMP_Text addCoinText;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private int maxCoinCost;
    [SerializeField] private int minCoinCost;
    private int coinCost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            FindObjectOfType<Bank>().AddCoins(coinCost);
            if (collectSound)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Destroy(gameObject);
        }
    }
    private void Start()
    {
        coinCost = Random.Range(minCoinCost, maxCoinCost + 1);
        addCoinText.text = coinCost.ToString();
    }
}
