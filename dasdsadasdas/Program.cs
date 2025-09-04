using System;

public abstract class Criatura 
{
    public string nome;
    public int vida;
    public int ataque;
    public int defesa;
   
    public abstract void Atacar(Criatura alvo);
    
    public void ReceberDano(int dano)
    


 public Guerreiro(string nome, int vida, int ataque, int defesa, int EnergiaVigor)
        : base(nome, vida, ataque, defesa)
    {
        EnergiaVigor = energiaVigor;
    }
public override void Defesa(Guerreiro)
    
   
    public override void Atacar(Criatura alvo)
    {
       
        int chanceCritica = random.Next(1, 101);
        int danoFinal;

        if (chanceCritica <= 20)
        {
            
            danoFinal = ataque * 2;
            Console.WriteLine($"O Cavaleiro fez um ataque CRÍTICO em {nome}!");
        }
        else
        {
          
            danoFinal = ataque;
            Console.WriteLine($"O Cavaleiro fez um ataque normal em {nome}.");
        }
        
     
    }
     public Arqueiro(string nome, int vida, int ataque, int defesa, int EnergiaVigor)
        : base(nome, vida, ataque, defesa)
    {
        EnergiaVigor = energiaVigor;
    }
public override void Defesa(Arqueiro)
    
   
    public override void Atacar(Criatura alvo)
    {
       
        int chanceCritica = random.Next(1, 101);
        int danoFinal;

        if (chanceErro <= 30)
        {
            
            danoFinal = ataque = 0;
            Console.WriteLine($" O Arqueiro erro o {nome}!");
        }
        else
        {
          
            danoFinal = ataque;
            Console.WriteLine($"O Arqueiro fez um ataque normal em {nome}.");
        }
        
     
    }
    
}

    

    





