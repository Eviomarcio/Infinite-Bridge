using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour {

    private ControleJogo controleJogo;
    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {

        controleJogo = FindObjectOfType(typeof(ControleJogo)) as ControleJogo;
        rBody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical");

        //Armazena o valor da velocidade vinda do controle personagem
        float velocidade = controleJogo.velocidadePersonagem;

        rBody.velocity = new Vector2(horizontal * velocidade, vertical * velocidade);


        //Verificar posição Y do personagem e ajustar conforme limite definido
        if (transform.position.y > controleJogo.limiteYMaximo)
        {
            transform.position = new Vector3(transform.position.x, controleJogo.limiteYMaximo, 0);
        }
        else if (transform.position.y < controleJogo.limiteYMinimo)
        {
            transform.position = new Vector3(transform.position.x, controleJogo.limiteYMinimo, 0);
        }

        //Verificar posição X do personagem e ajustar conforme limite definido
        if (transform.position.x > controleJogo.limiteXMaximo)
        {
            transform.position = new Vector3(controleJogo.limiteXMaximo, transform.position.y, 0);
        }
        else if (transform.position.x < controleJogo.limiteXMinimo)
        {
            transform.position = new Vector3(controleJogo.limiteXMinimo, transform.position.y, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controleJogo.GameOver();
    }
}
