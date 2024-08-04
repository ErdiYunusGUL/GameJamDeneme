using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu ile çarpıştığında oyunu yeniden başlat
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
