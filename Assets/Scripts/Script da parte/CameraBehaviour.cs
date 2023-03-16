using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform player;

    [SerializeField]
    float z_offset = -10f;
    [SerializeField]
    float y_offset = 1f;

    [SerializeField]
    float smooth = 0.3f;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       if(player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y + y_offset, player.position.z + z_offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        }
    }
}
