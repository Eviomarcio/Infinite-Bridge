using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleJogo : MonoBehaviour {

    [Header("Personagem")]
    public Transform tPlayer;
    public float velocidadePersonagem;

    [Header("Configuração limeite Movimento Personagem")]
    public float limiteYMaximo;
    public float limiteYMinimo;
    public float limiteXMaximo;
    public float limiteXMinimo;

    [Header("Configuração da GamePlay")]
    public float velocidadeObjetos;
    public float intervaloEntreSpawnBarril;
    public int pontosGanhoPorBarril;
    

    [Header("Configuração da Ponte")]
    public GameObject prefabPonte;
    public float tamanhaPrefabPonte;

    [Header("Configuração do Barril")]
    public GameObject prefabBarril;
    public float posicaoXBarril;
    public float[] posicaoYBarril;
    public int[] ordemExicao;

    [Header("HUB")]
    public Text txtPontos;
    private int pontos;

    [Header("FX")]
    public AudioSource Sfx;
    public AudioClip fxPontos;

    public void InstanciarPonte(float posicaoX)
    {
        GameObject tempPonte = Instantiate(prefabPonte);
        tempPonte.transform.position = new Vector3(posicaoX + tamanhaPrefabPonte, tempPonte.transform.position.y, 0);
    }

    private void Start()
    {
        StartCoroutine("spawnBarril");
    }

    IEnumerator spawnBarril()
    {
        yield return new WaitForSeconds(intervaloEntreSpawnBarril);

        GameObject temBarril = Instantiate(prefabBarril);
        int rand = Random.Range(0, 2);
        temBarril.transform.position = new Vector3(posicaoXBarril, posicaoYBarril[rand], 0);
        temBarril.GetComponent<SpriteRenderer>().sortingOrder = ordemExicao[rand];

        StartCoroutine("spawnBarril");

    }

    public void pontuar()
    {
        pontos += pontosGanhoPorBarril;

        txtPontos.text = "PONTOS: " + pontos.ToString();

        Sfx.PlayOneShot(fxPontos, 0.7f);

    }

    public void GameOver()
    {
        SceneManager.LoadScene("gameover");
    }

}
