using UnityEngine;

public class MoitaCodigo : MonoBehaviour
{
    public GeradorMoita geradorMoita; // Referência ao objeto do gerador de moitas

    void Update()
    {
        transform.Translate(Vector2.left * geradorMoita.CurrentSpeed * Time.deltaTime); // Move a moita para a esquerda com base na velocidade atual do gerador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextLine")) // Verifica se a colisão ocorreu com um objeto com a tag "NextLine"
        {
            geradorMoita.GerarProximaCmEspaco(); // Chama o método do gerador para gerar a próxima moita com um espaço de tempo aleatório
        }
        if (collision.gameObject.CompareTag("Finish")) // Verifica se a colisão ocorreu com um objeto com a tag "Finish"
        {
            Destroy(this.gameObject); // Destroi a moita atual
        }
    }
}
