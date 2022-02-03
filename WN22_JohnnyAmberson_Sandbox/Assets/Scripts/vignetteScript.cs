using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using System;

public class vignetteScript : MonoBehaviour
{
    [SerializeField]
    float intensity = 0.75f;
    [SerializeField]
    float duration = 0.5f;
    [SerializeField]
    private Volume Volume;
    Vignette vignette;
    [SerializeField]
    InputActionReference continuousMove;

    private void Awake()
    {
        continuousMove.action.performed += fadeIn;
        continuousMove.action.canceled += fadeOut;

        if (Volume.profile.TryGet(out Vignette vignette))
        {
            this.vignette = vignette;
        }
    }

    private void fadeOut(InputAction.CallbackContext obj)
    {
        StartCoroutine(fade(0, intensity));
    }

    private void fadeIn(InputAction.CallbackContext obj)
    {
        if (obj.ReadValue<Vector2>() != Vector2.zero)
        {
            StartCoroutine(fade(intensity, 0));
        }
    }
    IEnumerator fade(float startValue, float endValue)
    {
        float elapsedTime = 0.0f;
        float blend = elapsedTime / duration;
        float intensity = Mathf.Lerp(startValue, endValue, blend);
        ApplyValue(intensity);
        yield return null;
    }

    private void ApplyValue(float value)
    {
        vignette.intensity.Override(value);
    }
}
