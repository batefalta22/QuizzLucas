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

    [Header("Drop")]
    public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        Player.instancia.alansAtivos.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        corpoAlan.velocity = new Vector2(0, velocidade);
    }
    public void KillAlan()
    {
        DroparItem();
        Player.instancia.alansAtivos.Remove(this);
        Destroy(gameObject);
    }
    public void DroparItem()
    {
        int rnd = Random.Range(0, 10);

        if(rnd < 4)
        {
            Instantiate(powerUp,transform.position, Quaternion.identity);
        }
    }

}
