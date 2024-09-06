// SAMUEL ESTEBAN GUEVARA CARDENAS - 1001016737 

public interface InterfazJugador
{
    string BuscarNom();
    string BuscarPos();
    int BuscarRen();
}

public class Jugador : InterfazJugador
{
    private string nombre;
    private string posicion;
    private int rendimiento;

    public Jugador(string nombre, string posicion, int rendimiento)
    {
        this.nombre = nombre;
        this.posicion = posicion;
        this.rendimiento = rendimiento;
    }

    public string BuscarNom()
    {
        return nombre;
    }

    public string BuscarPos()
    {
        return posicion;
    }

    public int BuscarRen()
    {
        return rendimiento;
    }
}


public class Equipo
{
    private List<InterfazJugador> jugadores;

    public Equipo()
    {
        jugadores = new List<InterfazJugador>();
    }

    public void AgregarJugador(InterfazJugador jugador)
    {
        if (jugadores.Count < 3)
        {
            jugadores.Add(jugador);
        }
        else
        {
            Console.WriteLine("El equipo ya esta compleot");
        }
    }

    public int PuntajeFinal()
    {
        return jugadores.Sum(j => j.BuscarRen());
    }

    public void MostrarEquipo()
    {
        foreach (var jugador in jugadores)
        {
            Console.WriteLine("Nombre: " + jugador.BuscarNom() + ", Posición: " + jugador.BuscarPos() + ", Rendimiento: " + jugador.BuscarRen());
        }
    }
}


public class PartidoBasket
{
    private List<InterfazJugador> jugadoresDisponibles;
    private Equipo equipo1;
    private Equipo equipo2;
    private Random random;

    public PartidoBasket(List<InterfazJugador> jugadores)
    {
        jugadoresDisponibles = jugadores;
        equipo1 = new Equipo();
        equipo2 = new Equipo();
        random = new Random();
    }

    public void EscogerJugadores()
    {
        List<InterfazJugador> jugadoresSeleccionados = new List<InterfazJugador>();

        for (int i = 0; i < 6; i++)
        {
            InterfazJugador jugadorSeleccionado;


            do
            {
                jugadorSeleccionado = jugadoresDisponibles[random.Next(jugadoresDisponibles.Count)];
            } while (jugadoresSeleccionados.Contains(jugadorSeleccionado));

            jugadoresSeleccionados.Add(jugadorSeleccionado);4


            if (i % 2 == 0)
                equipo1.AgregarJugador(jugadorSeleccionado);
            else
                equipo2.AgregarJugador(jugadorSeleccionado);
        }
    }

    public void ComienzaElJogo()
    {
        Console.WriteLine("Equipo 1:");
        equipo1.MostrarEquipo();
        Console.WriteLine("El equipo 1 ha hecho estos puntos ----> " + equipo1.PuntajeFinal());

        Console.WriteLine();

        Console.WriteLine("Equipo 2:");
        equipo2.MostrarEquipo();
        Console.WriteLine("El equipo 2 ha hecho estos puntos ----> " + equipo2.PuntajeFinal());

        Console.WriteLine();

        if (equipo1.PuntajeFinal() > equipo2.PuntajeFinal())
        {
            Console.WriteLine("El equipo 1 ha ganado el partido");
        }
        else if (equipo1.PuntajeFinal() < equipo2.PuntajeFinal())
        {
            Console.WriteLine("El equipo 2 ha ganado el partido");
        }
        else
        {
            Console.WriteLine("El partido ha quedado en empate.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<InterfazJugador> jugadores = new List<InterfazJugador>
        {
            new Jugador("Samuel Guevara", "Lanzador", 9),
            new Jugador("Camilo Bravo", "Lanzador", 8),
            new Jugador("Mateo Gil", "Asistidor", 7),
            new Jugador("Jesus Villamizar", "Asistidor", 6),
            new Jugador("Alejandro Hincapie", "Defensa", 5),
            new Jugador("Santiago Ramirez", "Defensa", 4)
        };

        PartidoBasket partido = new PartidoBasket(jugadores);
        partido.EscogerJugadores();
        partido.ComienzaElJogo();
    }
}
