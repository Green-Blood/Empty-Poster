using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out EnemyAI enemy)) return;
        gameObject.SetActive(false);
    }
}
