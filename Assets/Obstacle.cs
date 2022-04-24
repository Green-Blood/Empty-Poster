using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ParticleSystem destory;
    private bool IsHidden = false;
    public GameObject gameObject1;

    public void Start()
    {
        destory = GetComponent<ParticleSystem>();
        // gameObject1 = GetComponentInChildren<GameObject>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out EnemyAI enemy)) return;
        Hide();
    }

    public void Hide()
    {
        if (!IsHidden)
        {
            IsHidden = true;
            destory.Play();
            gameObject1.SetActive(false);
        }
    }

    public void Show()
    {
        IsHidden = false;
        gameObject1.SetActive(true);
    }


}
