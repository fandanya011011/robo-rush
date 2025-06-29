using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePicker : MonoBehaviour
{
    private ScoreCounter score;

    private void Awake()
    {
        score = FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            score.LoosePoints(5);
            Destroy(other.gameObject);
            // special effects
        }
    }
}
