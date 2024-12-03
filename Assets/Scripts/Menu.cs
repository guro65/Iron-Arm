using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Jogo");
        }
    }
    public void Jogar()
   {
        SceneManager.LoadScene("Jogo");
   }

   public void Credito()
    {
        SceneManager.LoadScene("creditos");
    }
}
