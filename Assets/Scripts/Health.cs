using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealt;
    public float currentHealth { get; private set; }
    private bool dead;

    private void Awake()
    {
        {
         
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealt);

        if (currentHealth > 0)
        {
            if (!dead)
            {
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    public void Respawn()
    {
        dead = false;
        
    }

}
