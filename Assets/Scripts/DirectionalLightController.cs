using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightController : MonoBehaviour
{
    [SerializeField]
    private Light _light;
    private float _defaultIntensity = 0.12f;
    private float _timeDelayFlicker;
    private bool isFlickering;

    [Range(0.12f, 2f)] [SerializeField]
    private float _maxIntensity;

    private void Awake()
    {
        if (_light == null) _light = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickeringLight());
        }
    }
    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        _light.intensity = Random.Range(_defaultIntensity + 0.04f, _maxIntensity);
        _timeDelayFlicker = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(_timeDelayFlicker);
        _light.intensity = Random.Range(_defaultIntensity + 0.04f, _maxIntensity);
        _timeDelayFlicker = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(_timeDelayFlicker);
        _light.intensity = _defaultIntensity;
        yield return new WaitForSeconds(Random.Range(1, 3));
        isFlickering = false;
    }
}
