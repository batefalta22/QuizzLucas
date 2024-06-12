using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D powerBody;
    BoxCollider2D powerColider;

    SpriteRenderer powerSprite;

    public Sprite[] spritesPower;

     public float velocidade;

    public int tipo;

    // Start is called before the first frame update
    void Start()
    {
        powerBody = GetComponent<Rigidbody2D>();
        powerColider = GetComponent<BoxCollider2D>();
        powerSprite = GetComponent<SpriteRenderer>();
        tipo = Random.Range(0, 3);
        powerSprite.sprite = spritesPower[tipo];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        powerBody.velocity = new Vector2(0, -velocidade);  
    }

    public void Coletado()
    {

    }

       
}
