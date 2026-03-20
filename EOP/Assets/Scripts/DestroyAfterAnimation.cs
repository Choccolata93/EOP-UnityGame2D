using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{   
    void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
