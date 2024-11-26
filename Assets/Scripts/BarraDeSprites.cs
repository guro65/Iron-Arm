using UnityEngine;
using UnityEngine.UI;

public class BarraComSprites : MonoBehaviour
{
    public Image barra; // A imagem da barra
    public Image spriteAssociado; // A imagem que exibirá os sprites dinâmicos
    public Sprite[] sprites; // Lista de sprites para diferentes estágios
    public float limite = 50f; // Valor máximo da barra

    private float valorAtual; // Valor atual da barra

    void Start()
    {
        // Inicializa a barra na metade do limite
        valorAtual = limite / 2f;
        AtualizarBarra();
        AtualizarSprite();
    }

    void Update()
    {
        // Simula a barra diminuindo e aumentando (pode ser ajustado com teclas no seu jogo principal)
        if (Input.GetKey(KeyCode.Space))
        {
            valorAtual += 2f * Time.deltaTime; // Velocidade de aumento
        }
        else
        {
            valorAtual -= 1f * Time.deltaTime; // Velocidade de diminuição
        }

        // Limita o valor atual entre 0 e o limite
        valorAtual = Mathf.Clamp(valorAtual, 0, limite);

        // Atualiza a barra visual e o sprite
        AtualizarBarra();
        AtualizarSprite();
    }

    void AtualizarBarra()
    {
        if (barra != null)
        {
            barra.fillAmount = valorAtual / limite; // Atualiza o preenchimento da barra
        }
    }

    void AtualizarSprite()
    {
        if (sprites.Length < 5 || spriteAssociado == null)
        {
            Debug.LogWarning("Certifique-se de adicionar pelo menos 5 sprites e vincular a imagem!");
            return;
        }
        
        // Atualiza o sprite baseado no valor atual da barra
        if (valorAtual <= limite * 0.2f) // Perto de 10% (faltando 10 pontos para o limite)
        {
            spriteAssociado.sprite = sprites[4];
        }
        else if (valorAtual <= limite * 0.3f) // Perto de 30% (valor <= 15 para limite de 50)
        {
            spriteAssociado.sprite = sprites[3];
        }
        else if (valorAtual <= limite * 0.5f) // Perto de 50% (valor <= 25 para limite de 50)
        {
            spriteAssociado.sprite = sprites[2];
        }
        else if (valorAtual <= limite * 0.8f) // Perto de 80% (valor <= 40 para limite de 50)
        {
            spriteAssociado.sprite = sprites[1];
        }
        else // Acima de 80%
        {
            spriteAssociado.sprite = sprites[0];
        }
    }
}