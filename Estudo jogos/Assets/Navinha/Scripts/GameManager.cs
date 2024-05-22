using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instancia;

    [Header("Gerador de Alans")]
    public GameObject objetoAlan;
    public Transform[] geradoresAlan;
    public float taxaAlan;

    private void Awake()
    {
        instancia = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GerarAlan());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GerarAlan()
    {
        int rnd = Random.Range(0, geradoresAlan.Length);
        Instantiate(objetoAlan, geradoresAlan[rnd].position, Quaternion.identity);
        yield return new WaitForSeconds(taxaAlan);
        StartCoroutine(GerarAlan());
    }


}
