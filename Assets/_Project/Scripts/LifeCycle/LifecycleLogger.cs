using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    //eseguito solo alla prima attizazione dlell'oggetto
    void Awake()
    {
           Debug.Log($"eseguo Awake {gameObject.name}");
    }

    //eseguito a ogni riattivazoine dell'oggetto
    private void OnEnable()
    {
        Debug.Log($"eseguo OnEnable {gameObject.name}");
    }

 
    // eseguito solo al primo avvio della scena
    void Start()
    {
        Debug.Log($"eseguo Start {gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"eseguo Update {gameObject.name}");
    }
    //chiamato a intervalli fissi mentre l'oggetto è attivo

    void FixedUpdate()
    {
        Debug.Log($"eseguo FixedUpdate {gameObject.name}");
    }

    //chiamato al termine del ciclo Update/FixedUpdate com
    private void LateUpdate()
    {
        Debug.Log($"eseguo LateUpdate {gameObject.name}");
    }

    //chiamato alla disattivazione dell'oggetto
    private void OnDisable()
    {
        Debug.Log($"eseguo OnDisable {gameObject.name}");
    }

    //chiamato alla distruzione dell'oggetto
    private void OnDestroy()
    {
        Debug.Log($"eseguo OnDestroy {gameObject.name}");
    }
}
