using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffSet : MonoBehaviour {

    private Renderer renderizadorMalha;
    private Material materialAtual;
    private float offSet;
    public int ordenRenderizacao;
    public float  incrementoOffSet, velocidade;

	// Use this for initialization
	void Start () {
        renderizadorMalha = GetComponent<Renderer>();
        renderizadorMalha.sortingOrder = ordenRenderizacao;
        materialAtual = renderizadorMalha.material;

	}
	
	// Update is called once per frame
	void Update () {

        offSet += incrementoOffSet;
        materialAtual.SetTextureOffset("_MainTex", new Vector2(offSet * velocidade, 0));

	}
}
