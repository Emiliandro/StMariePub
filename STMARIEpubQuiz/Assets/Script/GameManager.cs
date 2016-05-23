using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]private Questions[] Perguntas;
    [SerializeField]private static List<Questions> naoRespondidos;
    [SerializeField]private int optacao;
    [SerializeField]private Questions atualPergunta;

    [SerializeField]private Text factText, alt1, alt2, alt3, alt4;
    [SerializeField]private float delay = 0.5f;
    public Animator clip; 

    void Start()
    {
        if (naoRespondidos == null || naoRespondidos.Count == 0)
        {
            naoRespondidos = Perguntas.ToList<Questions>() ;
        }
        GetQuestions();
    }

 
    void GetQuestions()
    {
        int RandomQuestionsIndex = Random.Range(0, naoRespondidos.Count);
        atualPergunta = naoRespondidos[RandomQuestionsIndex];

        factText.text = atualPergunta.Pergunta;
        alt1.text = atualPergunta.Alternativa1;
        alt2.text = atualPergunta.Alternativa2;
        alt3.text = atualPergunta.Alternativa3;
        alt4.text = atualPergunta.Alternativa4;

    }

    IEnumerator TransitionToNext()
    {
        naoRespondidos.Remove(atualPergunta);

        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Optada1()
    {
        optacao = 1;
        Resposta();
    }
    public void Optada2()
    {
        optacao = 2;
        Resposta();
    }

    public void Optada3()
    {
        optacao = 3;
        Resposta();
    }
    public void Optada4()
    {
        optacao = 4;
        Resposta();
    }


    void Resposta()
    {
        if (optacao == atualPergunta.Resposta)
        {
            if (atualPergunta.Resposta == 1)
            {
                alt1.text = "Acerto!";
                alt2.text = "Acerto!";
                alt3.text = "Acerto!";
                alt4.text = "Acerto!";
            } else if (atualPergunta.Resposta == 2)
            {
                alt1.text = "Acerto!";
                alt2.text = "Acerto!";
                alt3.text = "Acerto!";
                alt4.text = "Acerto!";
            } else if (atualPergunta.Resposta == 3)
            {
                alt1.text = "Acerto!";
                alt2.text = "Acerto!";
                alt3.text = "Acerto!";
                alt4.text = "Acerto!";
            } else if (atualPergunta.Resposta == 4)
            {
                alt1.text = "Acerto!";
                alt2.text = "Acerto!";
                alt3.text = "Acerto!";
                alt4.text = "Acerto!";
            }
            StartCoroutine(TransitionToNext());
            Debug.Log("Acertou");
            clip.speed = 3.0f;
        }
        else
        {
            GameObject.Find("guitarrista").GetComponent<Animator>().Play("03errou", 0, 1f);
            GameObject.Find("vocalista").GetComponent<Animator>().Play("0erro", 0, 1f);
            GameObject.Find("baterista").GetComponent<Animator>().Play("02Errou", 0, 1f);
            GameObject.Find("baixista").GetComponent<Animator>().Play("01errou", 0, 1f);

            alt1.text = "Errou!";
            alt2.text = "Errou!";
            alt3.text = "Errou!";
            alt4.text = "Errou!";
            StartCoroutine(TransitionToNext());
            clip.speed = -1.0f;

        }
    }
	
}
