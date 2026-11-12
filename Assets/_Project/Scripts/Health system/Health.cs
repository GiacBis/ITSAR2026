using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f; //vita massima
    float currentHealth; //vita attuale
    public float CurrentHealth => currentHealth; //variabile pubblica che ritorna (=>) la variabile privata
    public bool IsDead { get; private set; }
    public Action<float , float> OnHealthChanged;
    public Action Died;




    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        if (IsDead) return;     //return interrompe l'esecuzione del metodo

        currentHealth -= damage; //operatore matematico (-) seguito da = significa effettuare quell'operazione sulla variabile, cioè currentHealth = currentHealth - damage)
        Debug.Log($"HP: {currentHealth}/{maxHealth}"); //HP: 100/100
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float heal)
    {
        currentHealth += heal;
        Mathf.Clamp(currentHealth, 0f, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        //scrivibile come:
        //if(currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
    }

    public void SetHealth(float _health, float _maxHealth)
    {
        currentHealth = _health;
        maxHealth = _maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    void Die()
    {
        IsDead = true;  
        Died?.Invoke();
        gameObject.SetActive(false);
    }


}
