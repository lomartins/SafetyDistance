using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvisoDistancia : MonoBehaviour
{
    public Text guiDistancia;
    public Text guiAvisoCuidado;
    public Text guiTempoColisao;

    public GameManager GameManager;
    private Rigidbody2D rb;
    private float distancia;
    private float distanciaAnterior = 0.0f;
    private float distanciaVariation;
    private float framesPerSecond;
    private float velocidadeMediaEscalar;
    private float previousPosition;

    private int frameCount = 0;

    private float constanteDeConversao = (4.0f / 10.5f);

    Transform frontCar;
    void Start() {
        guiDistancia.enabled = false;
        guiAvisoCuidado.enabled = false;
        guiTempoColisao.enabled = false;

        rb = GetComponent<Rigidbody2D>();
        frontCar = null;
    }

    // Update is called once per frame
    void Update() {
        
        framesPerSecond = 1.0f / Time.deltaTime;
        if(frontCar != null){
            if(frameCount == 0) {
                distancia = ((frontCar.position.y-0.4f) - (rb.position.y+0.4f)) * constanteDeConversao * 10;
            }
            frameCount++;
            
            guiDistancia.enabled = true;
            guiDistancia.text = "Distância: " + distancia.ToString();
            

            distanciaVariation = distancia - distanciaAnterior;
            velocidadeMediaEscalar = distanciaVariation / 12.0f;
            guiTempoColisao.text = "Tempo de colisão:\n" + ((distancia/(velocidadeMediaEscalar* 5 )*-0.1f)).ToString();

            if(distancia <= 13) {
                guiAvisoCuidado.enabled = true;
                guiTempoColisao.enabled = true;
                GameManager.PlayCoffinSong(1 - (distancia / 13.0f));
            }
            else{
                guiAvisoCuidado.enabled = false;
                guiTempoColisao.enabled = false;
                GameManager.StopCoffinSong();
            }

            if(frameCount >= 12) {
                distanciaAnterior = distancia;
                frameCount = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(!col.isTrigger)
            frontCar = col.transform;
    }

	void OnTriggerExit2D(Collider2D col) { 
        if(!col.isTrigger) {
            frontCar = null;
            guiDistancia.enabled = false;
            guiAvisoCuidado.enabled = false;
            guiTempoColisao.enabled = false;
            GameManager.StopCoffinSong();
        }
    }
}
