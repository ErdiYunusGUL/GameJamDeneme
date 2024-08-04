using UnityEngine;

public class PathVisibility : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // SpriteRenderer bileşenini al ve başta görünmez yap
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu ile çarpıştığında SpriteRenderer'ı aktif et
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }
}
