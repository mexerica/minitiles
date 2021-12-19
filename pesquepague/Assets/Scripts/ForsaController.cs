using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForsaController : MonoBehaviour
{
    [Range(1f, 72f)] public float valor = 1f;

    [SerializeField] float velocidade = 0.5f;

    [SerializeField] int tolerancia = 6;

    private Transform marcador;

    private Transform alvo;

    float valorAlvo;

    bool isSubindo;

    bool acertou;

    float _time;

    public float Retornar() {
        return valor;
    }

    public void ChamarAlvo() {
        valorAlvo = Random.Range(1, 75);

        alvo.localPosition = new Vector3(0, (valorAlvo/200)-0.18f, 0);
        alvo.gameObject.SetActive(true);
    }

    public bool Alvar() {
        alvo.gameObject.SetActive(false);

        return acertou;
    }

    void Marcar() {
        if (valor >= 72f)
            isSubindo = false;
        else if (valor <= 1f)
            isSubindo = true;
        valor += (isSubindo) ? 1f : -1f;
        marcador.localPosition = new Vector3(0, (valor/200)-0.18f, 0);
    }

    void OnEnable()
    {
        _time = 0f;
    }
    void OnDisable() {
        valor = 1f;
        marcador.localPosition = new Vector3(0, (valor/200)-0.18f, 0);
    }

    void Awake()
    {
        marcador = transform.GetChild(1);
        alvo = transform.GetChild(2);
    }

    void Update()
    {
        _time += Time.deltaTime;
        while(_time >= velocidade) {
            Marcar();
            _time -= velocidade;
        }

        if (alvo.gameObject.activeSelf) {
            acertou = valor <= valorAlvo+tolerancia && valor >= valorAlvo-tolerancia;

            if (acertou) {
                alvo.GetComponent<SpriteRenderer>().color =
                    new Color(57f/255f, 181f/255f, 74f/255f);
            }
            else {
                alvo.GetComponent<SpriteRenderer>().color =
                    new Color(1f, 1f, 1f);
            }
        }
    }
}
