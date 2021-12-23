using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] GameObject aliadosController;
    [SerializeField] GameObject inimigosController;

    [SerializeField] GameObject boxesController;
    // pra não ter q ficar digitando getcomponent
    BoxesController boxesScript;

    //0=opsoes /1=aliados /2=inimigos
    //3=habilidades /4=items /5=descrisao /6=confirmar
    List<int> estagios = new List<int>{0};

    // guarda as opsoes escolhidas pelo jogador
    Habilidade hblt;
    Item itm;
    Personagem alvo;

    // pra onde a gente vai????
    int proximoIndice;

    public void Mover(int axis) {
        Vector3 temp = boxesScript.boxAtivo.GetPosicao(axis);
        transform.position = temp;
    }

    void ResetarEstagios() {
        //desativa as caixas auxiliares
        boxesScript.ResetarBoxes();

        //reseta a lista de estagios do cursor
        estagios = new List<int>{0};
    }

    public void SetEstagioBack() {
        // se dá pra voltar mais
        if (estagios.Count > 1) {
            // desativa a box se precisar
            if (estagios[estagios.Count-1] > 2) {
                boxesScript.boxAtivo.SetInativo();
            }
            estagios.RemoveAt(estagios.Count-1);

            MudarBox(estagios[estagios.Count-1]);
        }
        // se já voltou tudo
        else {
            aliadosController.GetComponent<AliadosController>().SetAntePersonagem();
        }
    }
    public void SetEstagioFwrd() {
        // escolher a habilidade que foi...escolhida
        // ou alvo... ou item
        switch (estagios[estagios.Count-1]) {
            //caixas com habilidades
            case 0:
            case 3:
                hblt = boxesScript.boxAtivo.gameObject.GetComponent<Habilidades>()
                    .habilidades[boxesScript.boxAtivo.indice];
                proximoIndice = hblt.proximoIndice;

                itm = null;
                alvo = new Personagem();
                break;
            //caixa com items
            case 4:
                itm = boxesScript.boxAtivo.gameObject.GetComponent<Items>()
                    .items[boxesScript.boxAtivo.indice];
                proximoIndice = itm.proximoIndice;

                hblt = null;
                alvo = new Personagem();
                break;
            //caixa com aliados
            case 1:
                alvo = aliadosController.GetComponent<AliadosController>().aliados
                    .aliados[boxesScript.boxAtivo.indice].GetComponent<Aliado>()
                    .personagem;
                proximoIndice = 0;
                break;
            //caixa com inimigos
            case 2:
                alvo = inimigosController.GetComponent<InimigosController>().inimigos
                    .inimigos[boxesScript.boxAtivo.indice].GetComponent<Inimigo>()
                    .personagem;
                proximoIndice = 0;
                break;
            //caixa de confirmar escolhas
            case 6:
                proximoIndice = (boxesScript.boxAtivo.indice == 0) ? 0 : 6;
                break;
        }

        // ativar a proxima caixinha
        switch (proximoIndice) {
            // se o char acabou de escolher
            case 0:
                // se todos os chars já escolheram
                if (aliadosController.GetComponent<AliadosController>().atual == 3) {
                    // se ele confirmou as escolhas
                    if (estagios[estagios.Count-1] == 6) {
                        TerminarEscolha();
                    }
                    // vai pra caixa de confirmar escolhas
                    else {
                        estagios.Add(6);
                        MudarBox(estagios[estagios.Count-1]);
                    }
                }
                // se ainda não
                else {
                    TerminarEscolha();
                }
                break;
            // se ainda ta escolhendo
            case 1:
            case 2:
            case 3:
            case 4:
                // vai pra proxima caixa
                estagios.Add(proximoIndice);
                MudarBox(estagios[estagios.Count-1]);
                break;
            // se se arrapendeu das escolhas feitas
            case 6:
            default:
                SetEstagioBack();
                break;
        }
    }

    void TerminarEscolha() {
        // reseta os boxes
        ResetarEstagios();
        MudarBox(estagios[estagios.Count-1]);

        //manda guardar a asao escolhida
        if (hblt != null) {
            aliadosController.GetComponent<AliadosController>()
                .GuardarAsao(hblt, alvo);
        }
        else {
            aliadosController.GetComponent<AliadosController>()
                .GuardarAsao(itm, alvo);
        }
    }

    void MudarBox(int indice) {
        boxesScript.SetBoxAtivo(indice);

        if (estagios[estagios.Count-1] > 2) {
            boxesScript.boxAtivo.SetAtivo();
        }

        Mover(0);
    }

    void Start() {
        boxesScript = boxesController.GetComponent<BoxesController>();

        MudarBox(estagios[estagios.Count-1]);
    }
}
