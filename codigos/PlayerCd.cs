using UnityEngine;
using UnityEngine.UI;

public class PlayerCd : MonoBehaviour
{
    public float ForcaPulo; // Força do pulo do jogador
    float Metros; // Medida de distância percorrida pelo jogador

    [SerializeField]
    bool NoChao = false; // Indica se o jogador está no chão
    bool isAlive = true; // Indica se o jogador está vivo

    Rigidbody2D RB; // Componente Rigidbody2D do jogador

    public Text MetrosTxt; // Referência ao Text que exibe a quantidade de metros percorridos

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D do jogador
        Metros = 0; // Inicializa a variável de distância percorrida
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (NoChao == true) // Verifica se o jogador está no chão antes de permitir o pulo
            {
                RB.AddForce(Vector2.up * ForcaPulo); // Aplica a força de pulo para cima
                NoChao = false; // Marca que o jogador não está mais no chão
            }
        }

        if (isAlive) // Verifica se o jogador está vivo antes de atualizar a distância percorrida
        {
            Metros += Time.deltaTime * 4; // Atualiza a distância percorrida com base no tempo
            MetrosTxt.text = Metros.ToString("F") + "Metros"; // Atualiza o Text com a quantidade de metros percorridos formatada em string
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao")) // Verifica se houve colisão com um objeto com a tag "chao"
        {
            if (NoChao == false) // Marca que o jogador está no chão apenas se ele não estava no chão previamente
            {
                NoChao = true; // Marca que o jogador está no chão
            }
        }

        if (collision.gameObject.CompareTag("Moita")) // Verifica se houve colisão com um objeto com a tag "Moita"
        {
            isAlive = false; // Marca que o jogador não está mais vivo
            Time.timeScale = 0; // Pausa o tempo de jogo
        }
    }
}
