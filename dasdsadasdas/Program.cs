using System;
using System.Collections.Generic;

public abstract class Criatura
{
    public string nome;
    public int vida;
    public int ataque;
    public int defesa;

    public Criatura(string nome, int vida, int ataque, int defesa)
    {
        this.nome = nome;
        this.vida = vida;
        this.ataque = ataque;
        this.defesa = defesa;
    }

    public bool estaVivo()
    {
        return vida > 0;
    }

    public void receberDano(int dano)
    {
        int danoFinal = dano - defesa;
        if (danoFinal < 0)
            danoFinal = 0;

        vida -= danoFinal;
        Console.WriteLine($"{nome} tomou {danoFinal} de dano. Vida agora: {vida}");
    }

    public abstract void atacar(Criatura alvo);
}

public class Guerreiro : Criatura
{
    Random rand = new Random();

    public Guerreiro(string nome, int vida, int ataque, int defesa) : base(nome, vida, ataque, defesa)
    {
    }

    public override void atacar(Criatura alvo)
    {
        int chance = rand.Next(1, 101);
        int dano = ataque;

        if (chance <= 20)
        {
            dano = dano * 2;
            Console.WriteLine($"{nome} deu um ataque critico em {alvo.nome}!");
        }
        else
        {
            Console.WriteLine($"{nome} atacou {alvo.nome} normal mesmo.");
        }

        alvo.receberDano(dano);
    }
}

public class Mago : Criatura
{
    public int mana;
    public int custoMana;

    public Mago(string nome, int vida, int ataque, int defesa, int mana, int custoMana) : base(nome, vida, ataque, defesa)
    {
        this.mana = mana;
        this.custoMana = custoMana;
    }

    public override void atacar(Criatura alvo)
    {
        if (mana >= custoMana)
        {
            Console.WriteLine($"{nome} jogou um feitiço em {alvo.nome} que ignora a defesa!");
            alvo.vida -= ataque; // ignora defesa
            mana -= custoMana;
            Console.WriteLine($"{alvo.nome} perdeu {ataque} de vida. Vida dele: {alvo.vida}");
            Console.WriteLine($"{nome} gastou {custoMana} de mana. Mana que sobra: {mana}");
        }
        else
        {
            Console.WriteLine($"{nome} tentou atacar, mas não tem mana suficiente...");
        }
    }
}

public class Arqueiro : Criatura
{
    Random rand = new Random();

    public Arqueiro(string nome, int vida, int ataque, int defesa) : base(nome, vida, ataque, defesa)
    {
    }

    public override void atacar(Criatura alvo)
    {
        int chance = rand.Next(1, 101);

        if (chance <= 30)
        {
            Console.WriteLine($"{nome} errou o ataque em {alvo.nome}... que azar!");
        }
        else
        {
            Console.WriteLine($"{nome} atirou uma flecha em {alvo.nome}.");
            alvo.receberDano(ataque);
        }
    }
}

public class Batalha
{
    Criatura c1;
    Criatura c2;

    public Batalha(Criatura c1, Criatura c2)
    {
        this.c1 = c1;
        this.c2 = c2;
    }

    public Criatura executar()
    {
        Console.WriteLine($"\nComeçando a batalha: {c1.nome} x {c2.nome}\n");

        while (c1.estaVivo() && c2.estaVivo())
        {
            c1.atacar(c2);
            if (!c2.estaVivo())
                break;

            c2.atacar(c1);
        }

        Criatura vencedor = c1.estaVivo() ? c1 : c2;
        Console.WriteLine($"\n{vencedor.nome} ganhou a batalha!\n");
        Console.WriteLine("-------------------------------");
        return vencedor;
    }
}

public class Torneio
{
    List<Criatura> criaturas;

    public Torneio(List<Criatura> criaturas)
    {
        if (criaturas.Count < 2)
            throw new Exception("Tem que ter pelo menos 2 criaturas pra começar o torneio!");

        this.criaturas = criaturas;
    }

    public void iniciar()
    {
        Console.WriteLine("=== Torneio começando! ===");

        int rodada = 1;
        while (criaturas.Count > 1)
        {
            Console.WriteLine($"\nRodada {rodada}:");
            List<Criatura> vencedores = new List<Criatura>();

            for (int i = 0; i < criaturas.Count; i += 2)
            {
                if (i + 1 < criaturas.Count)
                {
                    Criatura a = criaturas[i];
                    Criatura b = criaturas[i + 1];

                    Batalha batalha = new Batalha(a, b);
                    var vencedor = batalha.executar();
                    vencedores.Add(vencedor);
                }
                else
                {
                    Console.WriteLine($"{criaturas[i].nome} passou direto pra próxima fase.");
                    vencedores.Add(criaturas[i]);
                }
            }

            criaturas = vencedores;
            rodada++;
        }

        Console.WriteLine($"\n O campeão do torneio é: {criaturas[0].nome}!!!");
    }
}

public class Program
{
    public static void Main()
    {
        var guerreiro1 = new Guerreiro("Aragorn, o Herdeiro de Isildur", 100, 30, 10);
        var guerreiro2 = new Guerreiro("Gimli, o Anão Imbatível", 100, 28, 12);
        var mago = new Mago("Gandalf, o Cinzento", 80, 35, 5, 100, 20);
        var arqueiro = new Arqueiro("Legolas, o Mestre das Flechas", 90, 25, 8);

        var criaturas = new List<Criatura> { guerreiro1, guerreiro2, mago, arqueiro };

        var torneio = new Torneio(criaturas);
        torneio.iniciar();
    }
}
