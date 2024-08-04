using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMainHall : MonoBehaviour
{
    // Her trigger için sahne index'ini belirle
    public int sceneIndex;

    void OnTriggerEnter(Collider other)
    {
        // Eğer oyuncu (veya belirli bir tag'e sahip başka bir nesne) trigger alanına girerse
        if (other.CompareTag("Player"))
        {
            // Belirlenen sahneyi yükle
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
