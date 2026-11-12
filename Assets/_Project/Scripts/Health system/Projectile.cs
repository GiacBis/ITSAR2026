using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float speed = 15f;
    



    // Projectile: il proiettile (trigger) entra in qualcosa
    private void OnTriggerEnter(Collider other) //si usa OnTriggerEnter pechè il collider è un trigger (dipende da come il component collider è impostato)
                                                //Collider other ritorna l'informazione del collider con cui stiamo collidendo (non il projectile)
    {
        // Dobbiamo verificare che l'oggetto other con cui stiamo collidendo, abbia un component Health
        if(other.gameObject.TryGetComponent(out Health _health)) //mi dice se hai un component Health e richiama il valore _health
        {
            _health.TakeDamage(damage);
        }
        Destroy(this.gameObject);   //destroy sul proiettile

        //Health health = other.GetComponentInParent<Health>();
        //if (health != null && !health.IsDead)  
            //health.TakeDamage(damage);

        //Destroy(gameObject);   // si ferma su qualunque cosa
    }

    // AreaEffect: chi esce dalla zona
    //private void OnTriggerExit(Collider other)
    //{
     //   Health health = other.GetComponentInParent<Health>();
     //   if (health != null) inside.Remove(health);
   // }







}
