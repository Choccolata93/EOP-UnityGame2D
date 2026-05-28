using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyInMainMenu : MonoBehaviour
{
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }
}
