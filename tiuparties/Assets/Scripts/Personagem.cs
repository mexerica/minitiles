using System;

[Serializable]
public class Personagem
{
    public string nome;
    public int hp;
    public int hpMax;
    Classe classe;

    public void setClasse(int i) {
        this.classe = new Classe(i);
    }
}
