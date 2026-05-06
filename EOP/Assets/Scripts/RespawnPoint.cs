using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if(_other.CompareTag("Player"))
        {
            GameManager.Instance.platformingRespawnPoint = transform.position;
        }
    }
} 
