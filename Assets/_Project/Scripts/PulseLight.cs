using UnityEngine;

/// <summary>
/// Fa pulsare l'emission del materiale URP Lit con un'onda sinusoidale.
/// Da assegnare all'oggetto che ha il Renderer del cristallo (o a un suo genitore).
/// </summary>
public class PulseLight : MonoBehaviour
{
    [SerializeField, ColorUsage(false, false)] private Color emissionColor = Color.cyan;
    [SerializeField, Min(0f)] private float minIntensity = 0.5f;
    [SerializeField, Min(0f)] private float maxIntensity = 3f;
    [SerializeField, Min(0f)] private float pulsesPerSecond = 0.5f;

    public float PulsesPerSecond => pulsesPerSecond;

    private static readonly int EmissionColorId = Shader.PropertyToID("_EmissionColor");

    private Material material;

    private void Awake()
    {
        // .material crea un'istanza: il materiale condiviso su disco non viene modificato.
        material = GetComponentInChildren<Renderer>().material;
        material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        float t = (Mathf.Sin(Time.time * pulsesPerSecond * Mathf.PI * 2f) + 1f) * 0.5f;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
        material.SetColor(EmissionColorId, emissionColor.linear * intensity);
    }

    private void OnDestroy()
    {
        if (material != null) Destroy(material);
    }
}
