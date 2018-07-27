using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogo : MonoBehaviour {

    public float velocidadePersonagem;
    [Header("Configuração limeite Movimento Personagem")]
    public float limiteYMaximo;
    public float limiteYMinimo;
    public float limiteXMaximo;
    public float limiteXMinimo;

    [Header("Configuração da GamePlay")]
    public float velocidadeObjetos;
    public float tamanhaPrefabPonte;

    [Header("Configuração dos Prefabs")]
    public GameObject prefabPonte;
    public GameObject prefabBarril;

	public void InstanciarPonte(float posicaoX)
    {
        GameObject tempPonte = Instantiate(prefabPonte);
        tempPonte.transform.position = new Vector3(posicaoX + tamanhaPrefabPonte, tempPonte.transform.position.y, 0);
    }


}
