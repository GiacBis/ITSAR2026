using UnityEngine;

public class PlayerControlRigidbody : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private GameControls controls;
    private float force = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //prende il primo che trova, altrimenti possiamo usare GetComponentInChildren o GetComponentInParent.
                                        //IMPORTANTE usare sempre nell'awake o solo quando è necessario inizializzare qualcosa, non ogni frame (i GetComponent sono pesanti)
       controls = new GameControls();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
    private void OnDestroy() => controls.Dispose();

    private void Update() //ogni frame leggo:
    {
        input = controls.Player.Move.ReadValue<Vector2>();

    }

    private void FixedUpdate()  // 50 volte al secondo: muovo
    {
        Vector3 input3 = new Vector3(input.x, 0f, input.y);
        Vector3 velocity = input3 * force;

        // dinamico: una spinta (AddForce con rigidbody NON kinematic)
        //rb.AddForce(new Vector3(input.x, 0f, input.y) * force); //per rigidbody non cinematico (disabilitiamo anche la flag kinematic nel component su unity).
        //Scriviamo i valori del vector3 specificando 0f perchè usiamo un Vector2 nell'input 
        //altrimenti scriviamo:
        //rb.AddForce(input3*force);


        // cinematico: decido io dove si trova (come Projectile), MovePosition con rigidbody Kinematic
        // con questo (movePosition) sistema non vengono considerate le collisioni con gli oggetti, andrebbero ricostruiti con altri sistemi
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        //attiviamo anche interpolate
    }






}


