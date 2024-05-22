using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instancia;

    [Header("Componentes")]
    public Rigidbody2D corpoPlayer;
    public BoxCollider2D colisorPlayer;


    [Header("Movimentação")]
    public float inputx;
    public float inputy;
    public float velocidade;
    public bool podeMoverX;
    public bool podeMoverY;

    [Header("Atirar")]
    public float inputTiro;
    public bool podeAtirar;
    public float taxaTiro;
    public Transform miraPlayer; 
    public GameObject tiroPlayer;


    private void Awake()
    {
        instancia = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMoverX)
        {
            inputx = Input.GetAxis("Horizontal");
        }
        if (podeMoverY)
        {
            inputy = Input.GetAxis("Vertical");
        }
        inputTiro = Input.GetAxis("Fire1");
        if(inputTiro != 0)
        {
            Atirar();
        }
    }

    private void FixedUpdate()
    {
        corpoPlayer.velocity = new Vector2 (inputx*velocidade, inputy * velocidade);

    }

    public void Atirar()
    {
        if (podeAtirar)
        {
            StartCoroutine(AtirarCleber());

        }
    }

    IEnumerator AtirarCleber()
    {
        podeAtirar = false;
        Instantiate(tiroPlayer, miraPlayer.position, Quaternion.identity);
        yield return new WaitForSeconds(taxaTiro);
        podeAtirar = true;

    }

}
