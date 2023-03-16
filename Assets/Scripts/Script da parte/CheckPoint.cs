using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Transform currentCheckPoint;
    private Health playerHealt;
    

    private void Awake()
    {
        playerHealt = GetComponent<Health>();
        
    }

    public void CheckRespawn()
    {
        if (currentCheckPoint == null)
        {
            

            return;
        }
        transform.position = currentCheckPoint.position;
        playerHealt.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckPoint = collision.transform;
            collision.GetComponent<Collider>().enabled = false;
        }
    }

}
