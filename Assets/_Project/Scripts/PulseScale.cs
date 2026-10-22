using UnityEngine;

/// <summary>
/// Fa pulsare la scala dell'oggetto con un'onda sinusoidale, sincronizzata con PulseLight.
/// Va messo sullo stesso oggetto di PulseLight.
/// </summary>
[RequireComponent(typeof(PulseLight))]
public class PulseScale : MonoBehaviour
{
    [SerializeField, Min(0f)] private float minScale = 0.9f; // moltiplicatore della scala iniziale
    [SerializeField, Min(0f)] private float maxScale = 1.1f;

    private PulseLight pulseLight;
    private Vector3 baseScale;

    private void Awake()
    {
        pulseLight = GetComponent<PulseLight>();
        baseScale = transform.localScale;
    }

    private void Update()
    {
        // Stessa formula di PulseLight: luce e scala raggiungono il picco insieme.
        float t = (Mathf.Sin(Time.time * pulseLight.PulsesPerSecond * Mathf.PI * 2f) + 1f) * 0.5f;
        transform.localScale = baseScale * Mathf.Lerp(minScale, maxScale, t);
    }
}