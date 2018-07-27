using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePonte : MonoBehaviour {

    private ControleJogo controleJogo;
    private Rigidbody2D rBody;

    private bool instanciado;

	// Use this for initialization
	void Start () {

        controleJogo = FindObjectOfType(typeof(ControleJogo)) as ControleJogo;

        rBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        rBody.velocity = new Vector2(controleJogo.velocidadeObjetos, 0);

        if (transform.position.x <= 0 && instanciado == false)
        {
            instanciado = true;
            controleJogo.InstanciarPonte(transform.position.x);
        }

        if (transform.position.x <= -8)
        {
            Destroy(this.gameObject);
        }

	}
}
