using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerB : MonoBehaviour
{
    public static GameManagerB instance;
    public int vidas = 5;
    public int tijolosRestantes;

    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public Transform playerSpawnPoint;
    public Transform ballSpawnPoint;

    public PlayerB playerAtual;
    public BallB ballAtual;

    public TextMeshProUGUI contador;
    public TextMeshProUGUI msgFinal;

    public bool segurando;
    private Vector3 offset;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SpawnarNovoJogador();
        AtualizarContador();

    }

    public void AtualizarContador()
    {
        contador.text = $"Vidas: {vidas} ";

    }

    public void SpawnarNovoJogador()
    {
        GameObject playerObj = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        GameObject ballObj = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);

        playerAtual = playerObj.GetComponent<PlayerB>();
        ballAtual = ballObj.GetComponent<BallB>();

        segurando = true;
        offset = playerAtual.transform.position - ballAtual.transform.position;
    }

   
    void Update()
    {
        if (segurando)
        {
            ballAtual.transform.position = playerAtual.transform.position - offset;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballAtual.DispararBolinha(playerAtual.inputX);
                segurando = false;
            }
        }
    }
}
