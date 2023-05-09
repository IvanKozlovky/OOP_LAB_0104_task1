using System;

public class Пелюсток
{
    public string Колір { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Пелюсток)obj;
        return Колір == other.Колір;
    }

    public override int GetHashCode()
    {
        return Колір.GetHashCode();
    }

    public override string ToString()
    {
        return $"Пелюсток: колір = {Колір}";
    }
}

public class Бутон : Пелюсток
{
    public void Розквітнути()
    {
        Console.WriteLine("Бутон розквітнув");
    }

    public void Зівяли()
    {
        Console.WriteLine("Бутон зів'яв");
    }

    public void ВивестиКолірБутона()
    {
        Console.WriteLine($"Колір бутона: {Колір}");
    }
}

public class Квітка
{
    public Бутон Бутон { get; set; }
    public Пелюсток[] Пелюстки { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Квітка)obj;
        return Бутон.Equals(other.Бутон) && Пелюстки.Length == other.Пелюстки.Length;
    }

    public override int GetHashCode()
    {
        return Бутон.GetHashCode() * 31 + Пелюстки.Length.GetHashCode();
    }

    public override string ToString()
    {
        return $"Квітка: бутон = {Бутон}, пелюстки = {Пелюстки.Length}";
    }
}

public class КвітковийБукет
{
    public Квітка[] Квітки { get; set; }

    public void ВивестиКольориБутонів()
    {
        Console.WriteLine("Кольори бутонів у квітковому букеті:");
        foreach (var квітка in Квітки)
        {
            квітка.Бутон.ВивестиКолірБутона();
        }
    }

    public void РозквітнутиБукет()
    {
        Console.WriteLine("Розквітання квіткового букета:");
        foreach (var квітка in Квітки)
        {
            квітка.Бутон.Розквітнути();
        }
    }

    public void ЗівятиБукет()
    {
        Console.WriteLine("Зів'яння квіткового букета:");
        foreach (var квітка in Квітки)
        {
            квітка.Бутон.Зівяли();
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (КвітковийБукет)obj;
        return Квітки.Length == other.Квітки.Length;
    }

    public override int GetHashCode()
    {
        return Квітки.Length.GetHashCode();
    }

    public override string ToString()
    {
        return $"КвітковийБукет: кількість квітів = {Квітки.Length}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var пелюсток1 = new Пелюсток { Колір = "Червоний" };
        var пелюсток2 = new Пелюсток { Колір = "Жовтий" };
        var бутон1 = new Бутон { Колір = "Зелений" };
        var бутон2 = new Бутон { Колір = "Синій" };

        var квітка1 = new Квітка { Бутон = бутон1, Пелюстки = new[] { пелюсток1 } };
        var квітка2 = new Квітка { Бутон = бутон2, Пелюстки = new[] { пелюсток2 } };

        var квітковийБукет = new КвітковийБукет { Квітки = new[] { квітка1, квітка2 } };

        квітковийБукет.ВивестиКольориБутонів();
        квітковийБукет.РозквітнутиБукет();
        квітковийБукет.ЗівятиБукет();

        Console.WriteLine(квітковийБукет);

        Console.ReadLine();
    }
}



