using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alan : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody2D corpoAlan;
    public BoxCollider2D colisorAlan;



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
        corpoAlan.velocity = new Vector2(0, velocidade);
    }
}