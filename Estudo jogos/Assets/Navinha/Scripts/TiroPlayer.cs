using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody2D corpoTiro;
    public BoxCollider2D colisorTiro;

    [Header("Movimentação")]
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        corpoTiro.velocity = new Vector2(0, velocidade);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alan"))
        {
            GameManager.instancia.AlterarScore(10);
            Player.instancia.alansAtivos.Remove(collision.gameObject.GetComponent<Alan>());
            collision.gameObject.GetComponent<Alan>().DroparItem();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
