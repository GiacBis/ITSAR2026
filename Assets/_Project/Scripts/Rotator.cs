using UnityEngine;

/// <summary>
/// Fa ruotare l'oggetto sull'asse Y globale a velocità e direzione regolabili.
/// </summary>
public class Rotator : MonoBehaviour
{
    private enum RotationDirection
    {
        Clockwise,
        CounterClockwise
    }

    [SerializeField] private float rotationSpeed = 45f; // gradi al secondo
    [Tooltip("Senso di rotazione visto dall'alto.")]
    [SerializeField] private RotationDirection direction = RotationDirection.Clockwise;

    private void Update()
    {
        float sign = direction == RotationDirection.Clockwise ? 1f : -1f;
        transform.Rotate(0f, sign * rotationSpeed * Time.deltaTime, 0f, Space.World);
    }
}