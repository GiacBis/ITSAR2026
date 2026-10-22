using UnityEngine;

/// <summary>
/// Fa oscillare l'oggetto su e giù lungo l'asse Y globale, sincronizzato con PulseLight.
/// Va messo sullo stesso oggetto di PulseLight.
/// </summary>
[RequireComponent(typeof(PulseLight))]
public class PulseBob : MonoBehaviour
{
    [Tooltip("Spostamento massimo verso l'alto e verso il basso rispetto alla posizione iniziale (unità di Unity).")]
    [SerializeField] private float bobDistance = 0.25f;

    private PulseLight pulseLight;
    private float currentOffset;

    private void Awake()
    {
        pulseLight = GetComponent<PulseLight>();
    }

    private void Update()
    {
        // Stessa fase di PulseLight: il picco di luce coincide con il punto più alto.
        float newOffset = Mathf.Sin(Time.time * pulseLight.PulsesPerSecond * Mathf.PI * 2f) * bobDistance;

        // Applico solo la differenza, così funziona anche se l'oggetto o il suo genitore vengono spostati.
        transform.position += Vector3.up * (newOffset - currentOffset);
        currentOffset = newOffset;
    }
}