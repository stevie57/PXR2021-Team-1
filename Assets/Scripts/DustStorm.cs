using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStorm : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        _particleSystem.Play();
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        _particleSystem.Stop();
    }
}
