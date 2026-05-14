namespace TP03.Models;

public class SugeridorReceta
{
    public string NombreCocinero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string TipoComida { get; set; }
    public double Presupuesto { get; set; }
    public int CantidadPersonas { get; set; }
    public SugeridorReceta()
    {

    }
    public SugeridorReceta(string nombre, DateTime fecha, string tipo, double presupuesto, int personas)
    {
        this.NombreCocinero = nombre;
        this.FechaNacimiento = fecha;
        this.TipoComida = tipo;
        this.Presupuesto = presupuesto;
        this.CantidadPersonas = personas;
    }
    public int CalcularEdad()
    {
        int edad = DateTime.Today.Year - FechaNacimiento.Year;
        if (DateTime.Today.Month < FechaNacimiento.Month || DateTime.Today.Month == FechaNacimiento.Month && DateTime.Today.Day < FechaNacimiento.Day)
        {
            edad--;
        }
        return edad;
    }      
    public string DeterminarPlato()
    {
        if (TipoComida == "Caliente")
        {
            if (Presupuesto < 3000) return "Fideos con manteca";
            if (Presupuesto <= 7000) return "Arroz con verduras salteadas";
            return "Pollo al horno con guarnición";
        }
        else if (TipoComida == "Fría")
        {
            if (Presupuesto < 3000) return "Ensalada simple";
            if (Presupuesto <= 7000) return "Ensalada completa con proteína";
            return "Tabla de fiambres y quesos";
        }
        
        return "Tipo de comida no válido";
    }
    public int CalcularTiempo()
    {
        if (TipoComida == "Caliente")
        {
            if (CantidadPersonas <= 3) return 20;
            if (CantidadPersonas <= 7) return 40; 
            return 80; 
        }
        else if (TipoComida == "Fría")
        {
            if (CantidadPersonas <= 3) return 10;
            if (CantidadPersonas <= 7) return 20; 
            return 40; 
        }
        return 0;
    }
    public string DeterminarDificultad()
    {
        if (Presupuesto < 3000)
        {
            if (CantidadPersonas <= 3) return "Principiante";
            return "Intermedio";
        }
        else if (Presupuesto <= 7000)
        {
            return "Intermedio";
        }
        else
        {
            if (CantidadPersonas <= 7) return "Intermedio";
            return "Avanzado";
        }
    }
}
