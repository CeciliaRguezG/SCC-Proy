using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MuestraResultados
/// </summary>
public class MuestraResultados
{
    string[] NomColumnas;// = new string[] { "Pedimento", "Clave", "Fecha", "RFC" };
    string Query;
    string Tabla;

    // string[] nomcolumnasR = new string[] { "Campo", "Pedimento", "Regla", "Resultado" };

    public MuestraResultados()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void setDatos(string[] array, string query)
    {
        this.NomColumnas = array;
        this.Query = query;
    }

    public string ConstruyeListado()
    {

        Tablas generarTabla = new Tablas();
        this.Tabla = generarTabla.contruirTablaGen(this.Query, "ListadoCliente", this.NomColumnas);

        return this.Tabla;
    }

}
