using Unity.VisualScripting;
using UnityEngine;

public class AutoTargeter : MonoBehaviour
{
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] float eyeHeight = 1.7f;
    [SerializeField] float range;

    private void FixedUpdate()
    {
        
    }

    public Health FindNearest()
    {
        Vector3 eye = transform.position + Vector3.up * eyeHeight;  //trabdorm.position è posizione del giocatore ai piedi, viene sommata per l'alteza degli occhi con vettore up

        // sfera: tutti i bersagli entro range
        Collider[] hits = Physics.OverlapSphere(            //Ritorna il collider di tutti gli oggetti che si trovano all'interno di una sfera di raggio range centrata sul player hits è un array  (insieme di elementi finiti)
            transform.position, range, targetMask);

        Health currentElegibleEnemy = null;

        foreach (Collider hit in hits)          //itera per ogni collider nell'array
        {
            Health health = hit.GetComponentInParent<Health>();
            if(!health) continue;

            Vector3 point = health.transform.position
                          + Vector3.up * eyeHeight;

            // linea: c'è un ostacolo tra me e lui? Traccia una linea dai tuoi occhi al nemico. Se incontra qualcosa nei layer di obstacleMask restituisce true: c’è un ostacolo in mezzo, quindi il nemico viene scartato.
            if (Physics.Linecast(eye, point, obstacleMask))
                continue;                                        //si passa al collder successivo nell'array (contnua quindi il ciclo foreach)

            if(currentElegibleEnemy == null)    //se ancora non c'è uncurrentelegiblEnemy...
                currentElegibleEnemy=health;    //assegniamo health a questo candidato

            else
            {
                //Altrimenti calcola la distanza dal giocatore sia del candidato attuale sia del nuovo nemico.
                float currentEnemyDistance = Vector3.Distance(currentElegibleEnemy.transform.position, transform.position);
                float newEnemyDistance = Vector3.Distance(health.transform.position, transform.position);

                //Se il nuovo è più vicino, sostituisce il candidato.
                if (newEnemyDistance < currentEnemyDistance)
                    currentElegibleEnemy = health;
            }
        }

        Debug.Log(currentElegibleEnemy ? currentElegibleEnemy.gameObject.name : "nothing" + "found as target");
        return currentElegibleEnemy;
    }







}
