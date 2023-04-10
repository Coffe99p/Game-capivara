using UnityEngine;

public class GeradorMoita : MonoBehaviour
{
    public GameObject Moita; // Referência ao objeto da moita que será instanciado

    public float MaxSpeed; // Velocidade máxima de geração da moita
    public float CurrentSpeed; // Velocidade atual de geração da moita
    public float MinSpeed; // Velocidade mínima de geração da moita

    public float SpeedMultiplier; // Multiplicador de velocidade para aumentar a velocidade de geração

    void Awake()
    {
        CurrentSpeed = MinSpeed; // Inicializa a velocidade atual com a velocidade mínima
        GerarMoita(); // Chama o método para gerar a primeira moita
    }

    public void GerarProximaCmEspaco()
    {
        float randomWait = Random.Range(0.1f, 1.2f); // Gera um tempo de espera aleatório
        Invoke("GerarMoita", randomWait); // Chama o método de geração da moita após o tempo de espera definido
    }

    void GerarMoita()
    {
        GameObject MoitaIns = Instantiate(Moita, transform.position, transform.rotation); // Instancia o objeto da moita na posição e rotação do gerador

        MoitaIns.GetComponent<MoitaCodigo>().geradorMoita = this; // Define o gerador da moita como sendo esta instância do script

        MoitaIns.tag = "Moita"; // Adiciona a tag "Moita" ao objeto recém-criado para identificação posterior
    }

    void Update()
    {
        if(CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += SpeedMultiplier; // Aumenta a velocidade atual de geração com base no multiplicador de velocidade
        }
    }
}
