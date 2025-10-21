using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [Header("Audio")] public AudioSource audioSource;
    [Header("Puntuación")] public int puntosPowerUp = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Datos2.Instance.AddPoints(puntosPowerUp);
            Datos2.Instance.MostrarPuntosDinamicos(puntosPowerUp, transform.position);
            puntosPowerUp = 0;
            if(audioSource != null){
                audioSource.Play();
                Destroy(gameObject, audioSource.clip.length/2);
            }
            else{
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
