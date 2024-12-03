using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarraDeControle : MonoBehaviour
{
    public Image barra; // Imagem da barra
    public float velocidadeDecremento = 1f; // Velocidade de diminuição
    public float velocidadeIncremento = 2f; // Velocidade de aumento ao segurar "espaço"
    public float limite = 100f; // Valor máximo da barra
    public GameObject painelDerrota; // Painel que aparece ao perder
    public GameObject painelVitoria; // Painel que aparece ao vencer

    private float valorAtual; // Valor atual da barra

    void Start()
    {
        // Inicializa a barra na metade do limite
        valorAtual = limite / 2f;
        AtualizarBarra();
        painelDerrota.SetActive(false);
        painelVitoria.SetActive(false);
    }

    void Update()
    {
        // Verifica se o jogador está pressionando espaço
        if (Input.GetKey(KeyCode.Space))
        {
            valorAtual += velocidadeIncremento * Time.deltaTime;
        }
        else
        {
            valorAtual -= velocidadeDecremento * Time.deltaTime;
        }

        // Limita o valor atual entre 0 e o limite
        valorAtual = Mathf.Clamp(valorAtual, 0, limite);

        // Atualiza a barra visual
        AtualizarBarra();

        // Verifica condições de derrota ou vitória
        if (valorAtual <= 0)
        {
            Derrota();
        }
        else if (valorAtual >= limite)
        {
            Vitoria();
        }
    }

    void AtualizarBarra()
    {
        if (barra != null)
        {
            barra.fillAmount = valorAtual / limite; // Atualiza o preenchimento da barra
        }
    }

    void Derrota()
    {
        painelDerrota.SetActive(true); // Exibe o painel de derrota
        Time.timeScale = 0f; // Pausa o jogo
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void Vitoria()
    {
        painelVitoria.SetActive(true); // Exibe o painel de vitória
        Time.timeScale = 0f; // Pausa o jogo
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}