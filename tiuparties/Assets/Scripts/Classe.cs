using System;

[Serializable]
public class Classe
{
    public string nome { get; set;}

    public Classe (int i) {
        switch(i) {
            case 0:
                nome = "tanker";
                break;
            case 1:
                nome = "cavaleiro";
                break;
            case 2:
                nome = "atirador";
                break;
            case 3:
                nome = "assassino";
                break;
            case 4:
                nome = "mago";
                break;
        }
    }
}
