using System;

public abstract class EstadoTransformacao // State
{
    protected Context _context;

    public void setContext(Context context)
    {
        _context = context;
    }

    public abstract void Fase1();
    public abstract void Fase2();
    public abstract void fase3();
    
}

public class Context
{
    private EstadoTransformacao _state = null;

    public Context(EstadoTransformacao state)
    {
        this.TransitionTo(state);
    }

    public void TransitionTo(EstadoTransformacao state)
    {
        Console.WriteLine($"Context: Mudando para {state.GetType().Name}.");
        this._state = state;
        this._state.setContext(this);

    }
    public void ChamaFase1()
    {
        this._state.Fase1();
    }

    public void ChamaFase2()
    {
        this._state.Fase2();
    }

    public void ChamaFase3()
    {
        this._state.fase3();
    }
}


public class EstadoSuperSaiajin : EstadoTransformacao
{
    public override void Fase1()
    {
        Console.WriteLine("Forma Base");
    }

    public override void Fase2()
    {
        Console.WriteLine($"Forma base indo para o {nameof(EstadoSuperSaiajin2)}.");
        this._context.TransitionTo(new EstadoSuperSaiajin2());
    }

    public override void fase3()
    {
        Console.WriteLine($"Forma base indo para o {nameof(EstadoSuperSaiajin3)}.");
        this._context.TransitionTo(new EstadoSuperSaiajin3());
    }

}

public class EstadoSuperSaiajin2 : EstadoTransformacao
{
    public override void Fase1()
    {
        Console.WriteLine($"Forma base indo para o {nameof(EstadoSuperSaiajin)}.");
        this._context.TransitionTo(new EstadoSuperSaiajin());
    }

    public override void Fase2()
    {
        Console.WriteLine("Mantendo Fase 2");
    }

    public override void fase3()
    {
        Console.WriteLine($"Forma base indo para o {nameof(EstadoSuperSaiajin3)}.");
        this._context.TransitionTo(new EstadoSuperSaiajin3());
    }
}

public class EstadoSuperSaiajin3 : EstadoTransformacao
{
    public override void Fase1()
    {
        Console.WriteLine($"Forma base indo para o {nameof(EstadoSuperSaiajin)}.");
        this._context.TransitionTo(new EstadoSuperSaiajin());
    }

    public override void Fase2()
    {
        Console.WriteLine($"indo para o {nameof(EstadoSuperSaiajin2)}.");
        this._context.TransitionTo(new EstadoSuperSaiajin2());
    }

    public override void fase3()
    {
        Console.WriteLine("Mantendo Fase 3");
    }
}

class Program
{
    static void Main1(string[] args)
    {
        // The client code.
        var context = new Context(new EstadoSuperSaiajin());
        context.ChamaFase1();
        context.ChamaFase2();
        context.ChamaFase3();
        context.ChamaFase2();
        context.ChamaFase1();
    }
}