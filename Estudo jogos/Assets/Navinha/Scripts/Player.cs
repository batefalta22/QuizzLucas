using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instancia;
    
    [Header("Componentes")]
    public Rigidbody2D corpoPlayer;
    public BoxCollider2D colisorPlayer;
    public Animator animatorPlayer;

    [Header("Movimentação")]
    public float inputX;
    public float inputY;
    public float velocidade;
    public bool podeMoverX;
    public bool podeMoverY;

    [Header("Atirar")]
    public float inputTiro;
    public bool podeAtirar;
    public float taxaTiro;
    public GameObject tiroPlayer;
    public Transform miraPlayer;

    [Header("Power Up")]
    public Transform powerEsquerda;
    public Transform powerDireita;
    public GameObject tiroPowerUp;
    public bool powerUp1Ativo;
    public int powerUp2;
    public float inputPowerUp2;
    public List<Alan> alansAtivos;
    public float taxaPower2;
    public bool podePower2;

    [Header("Vida Player")]
    public int vidaMaxima;
    public int vidaAtual;
    public float taxaInvencivel;


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

        inputPowerUp2 = Input.GetAxis("Fire2");
        if(inputPowerUp2 !=0 && powerUp2>0 && podePower2)
        {
            StartCoroutine("Especial");
        }

        if (podeMoverX)
        {
            inputX = Input.GetAxis("Horizontal");
        }

        if (podeMoverY)
        {
            inputY = Input.GetAxis("Vertical");
        }

        inputTiro = Input.GetAxis("Fire1");
        if(inputTiro != 0)
        {
            Atirar();
        }

        if(inputX != 0)
        {
            animatorPlayer.SetInteger("Player", 1);

            if(inputX > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            animatorPlayer.SetInteger("Player", 0);
        }



    }

    private void FixedUpdate()
    {
        corpoPlayer.velocity = new Vector2(inputX * velocidade, inputY * velocidade);
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
        Instantiate(tiroPlayer,miraPlayer.position,Quaternion.identity);
        if (powerUp1Ativo)
        {
            Instantiate(tiroPowerUp,powerDireita.position,Quaternion.identity);
            Instantiate(tiroPowerUp, powerEsquerda.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(taxaTiro);
        podeAtirar = true;
    }

    IEnumerator Especial()
    {
        podePower2 = false;
        foreach(Alan alan in alansAtivos)
        {
            alan.DroparItem();
            alansAtivos.Remove(alan);
            Destroy(alan);
            GameManager.instancia.score += 10;
        }
        yield return new WaitForSeconds(taxaPower2);
        podePower2 = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alan"))
        {
            powerUp1Ativo = false;
            collision.gameObject.GetComponent<Alan>().DroparItem();
            alansAtivos.Remove(collision.gameObject.GetComponent<Alan>());
            Destroy(collision.gameObject);
            vidaAtual--;
            if(vidaAtual <= 0)
            {
                GameManager.instancia.GameOver();
            }

        }
        if (collision.CompareTag("PowerUp"))
        {
            if(collision.gameObject.GetComponent<PowereUp>().tipo == 0)
            {
                powerUp1Ativo = true;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<PowereUp>().tipo == 1)
            {
                powerUp2++;
                podePower2 = true;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<PowereUp>().tipo == 2)
            {
                vidaMaxima++;
                vidaAtual = vidaMaxima;
                Destroy(collision.gameObject);
            }
        }
    }

}
