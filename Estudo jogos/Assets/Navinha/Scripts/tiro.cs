using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tiro : MonoBehaviour
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
        corpoTiro.velocity = new Vector2(0,velocidade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alan"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }


}
