using UnityEngine;

public class Bench : MonoBehaviour
{
    public bool interacted;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D _collision)
    {
        if(_collision.CompareTag("Player") && Input.GetButtonDown("Interact"))
        {
            interacted = true; 
        }
    }

}
