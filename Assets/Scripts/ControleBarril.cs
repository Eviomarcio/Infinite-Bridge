﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBarril : MonoBehaviour {

    private ControleJogo controleJogo;
    private Rigidbody2D rBody;
    private bool pontuado;

	// Use this for initialization
	void Start () {

        controleJogo = FindObjectOfType(typeof(ControleJogo)) as ControleJogo;

        rBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        rBody.velocity = new Vector2(controleJogo.velocidadeObjetos, 0);

        if (transform.position.x <= controleJogo.tPlayer.position.x && pontuado == false)
        {
            controleJogo.pontuar();
            pontuado = true;
        }

	}
}
