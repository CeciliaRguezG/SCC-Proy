using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de Tablas
/// </summary>
public class Tablas
{
    private string Table;
    private string Thead;
    private string Theadd;
    private string Th;
    private string Td;
    private string Ctd;
    private string Cth;
    private string Cthead;
    private string Tbody;
    private string Tr;
    private string Ctr;
    private string Ctbody;
    private string Ctable;
    private string A;
    private string Ca;
    private string Input;
    private string InputText;
    private string Pinput;
    private string Tabla;
    private string Tfoot;
    private string Cfoot;

    private storedProcedure sp;
    //private Util utileria;
    private List<string> resultado;
    private int TotalTuplas;
    public Tablas()
    {
        this.Table = "<table class='display' id=' align='center' ";
        this.Thead = "<thead>";
        this.Theadd = "<thead style=' background-color:#ffcc66;font-style:italic;font-weight:bolder;font-size:large;text-align:center;'>";
        this.Th = "<th width='200px'>";
        this.Cth = "</th>";
        this.Tr = "<tr>";
        this.Ctr = "</tr>";
        this.Cthead = "</thead>";
        this.Tbody = "<tbody>";
        this.Ctbody = "</tbody>";
        this.Td = "<td>";
        this.Ctd = "</td>";
        this.Ctable = "</table>";
        this.A = "<a href='javascript:";
        this.Ca = "</a>";
        this.Input = "<input type='checkbox' name='selNP' class='nc' onclick='javascript:habilitarC(this);'  value='";
        this.Pinput = "<input type='checkbox' id='all' onclick='javascript:seleccionarTodos();' />";
        this.InputText = "<input type='text' name='comentario' id='";

        this.Tfoot = "<tfoot>";
        this.Cfoot = "</tfoot>";


        this.Tabla = "";
        sp = new storedProcedure("sccConnectionString");
        // utileria = new Util();
        resultado = new List<string>();
    }

    public string CTfood { get; set; }

    /**
     * Tablas genéricas: 
     * Acciones: Eliminar, Editar, Configurar, Redireccionar etc.
     * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas,
        string[] nombreAccion, string[] Accion)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length - nombreAccion.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < columnasDat)
                        Tabla += this.Td + resultado[i + (a + 1)] + this.Ctd;
                    else
                    {
                        Tabla += this.Td + this.A + Accion[contador] + "(" + resultado[i] + ");'>" + nombreAccion[contador] + this.Ca + this.Ctd;
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }
    /**
     * Tablas genéricas: 
     * Acciones: Eliminar, Editar, Configurar, Redireccionar etc.
     * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas,
        string[] nombreAccion, string[] Accion, int x)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length - nombreAccion.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < columnasDat)
                        Tabla += this.Td + resultado[i + (a + 1)] + this.Ctd;
                    else
                    {
                        if (resultado[i] != "")
                        {

                            Tabla += this.Td + "<a href='..\\EvidenciasAdjuntas\\" + resultado[i] + "' target='_blank'>" + nombreAccion[contador] + this.Ca + this.Ctd;
                        }
                        else
                        {
                            Tabla += this.Td + this.A + Accion[contador] + "'>" + this.Ca + this.Ctd;
                        }
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }
    /**
     * Tablas genéricas: 
     * Acciones: Eliminar, Editar, Configurar, Redireccionar etc.
     * Abre una ventana emergente con thickbox
     * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas,
        string[] nombreAccion, string[] Accion, bool url)
    {
        int contador = 0;
        if (url)
        {
            this.TotalTuplas = nombreColumnas.Length + 3;
        }
        else
        {
            this.TotalTuplas = nombreColumnas.Length;
        }

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length - nombreAccion.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < columnasDat)
                        if (url)
                        {
                            if (a == 1)
                            {
                                Tabla += this.Td + "<a href='consultaControl.aspx?idControl=" + resultado[i + 1]
                                    + "&idActividadCtrl=" + resultado[i] + "&idSubProc=" + resultado[i + 2] +
                                    "&Carpeta=" + resultado[i + 3] + "&TB_iframe=true&height=540&width=960&modal=true' class='thickbox'>"
                                    + resultado[i + (a + 4)] + "</a>" + this.Ctd;
                            }
                            else
                            {
                                Tabla += this.Td + resultado[i + (a + 4)] + this.Ctd;
                            }
                        }
                        else
                        {
                            Tabla += this.Td + resultado[i + (a + 4)] + this.Ctd;
                        }
                    else
                    {
                        Tabla += this.Td + this.A + Accion[contador] + "(" + resultado[i] + ");'>" + nombreAccion[contador] + this.Ca + this.Ctd;
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }

    /**
             * Tablas genéricas: 
             * Acciones: Eliminar, Editar, Configurar, Redireccionar etc.
             * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas,
        string nombreAccion, string Accion)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < (columnasDat - 1))
                        Tabla += this.Td + resultado[i + (a + 1)] + this.Ctd;
                    else
                    {
                        Tabla += this.Td + this.A + Accion + "(" + resultado[i] + ");'>" + nombreAccion + this.Ca + this.Ctd;
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }



    /**
    * Tablas genéricas: 
    * Acciones: Eliminar, Editar, Configurar.
     * Checkbox
    * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas,
        string[] nombreAccion, string[] Accion, string nombreCheck)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length - nombreAccion.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        //        utileria.recupera(query, resultado);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            //Al primer resultado le ponemos un Checkbox
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            Tabla += this.Th + this.Pinput + nombreColumnas[0] + this.Cth;

            if (nombreColumnas.Length > 0)
                for (int i = 1; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si es la primer columna de la tupla
                    if (a == 0)
                        Tabla += this.Tr + this.Td + this.Input + resultado[i] + "'/>" + this.Ctd;

                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < columnasDat)
                        Tabla += this.Td + resultado[i + a] + this.Ctd;
                    else
                    {
                        Tabla += this.Td + this.A + Accion[contador] + "(" + resultado[i] + ");'>" + nombreAccion[contador] + this.Ca + this.Ctd;
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }


    /**
    * Tablas genéricas: 
    * Checkbox
    * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas, string nombreCheck)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            //Al primer resultado le ponemos un Checkbox
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            Tabla += this.Th + this.Pinput + nombreColumnas[0] + this.Cth;

            if (nombreColumnas.Length > 0)
                for (int i = 1; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            //se añadio un contador auxiliar
            int aux = 0;
            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si es la primer columna de la tupla
                    //Agregamos el check
                    if (a == 0)
                    {
                        Tabla += this.Tr + this.Td + this.Input + resultado[aux + 4] + "'/>" + this.Ctd;
                        //Tabla += this.Td + resultado[aux] + this.Ctd;
                        // aux++;
                    }
                    else
                    {
                        //Construimos filas y columnas
                        Tabla += this.Td + resultado[aux] + this.Ctd;
                        aux++;
                    }

                    contador++;
                }
                aux++;
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }

    /**
    * Tablas genéricas: 
    * Checkbox
    * Con un link en donde especifique el usuarios 
    * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas, string nombreCheck, int col)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);
        this.Tabla = "";
        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            //Al primer resultado le ponemos un Checkbox
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;


            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    if (i == 5)
                    {
                        Tabla += this.Th + this.Pinput + nombreColumnas[i] + this.Cth;
                    }
                    else
                    {
                        Tabla += this.Th + nombreColumnas[i] + this.Cth;
                    }
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si es la primer columna de la tupla
                    //Agregamos el check

                    if (col == a)
                    {
                        Tabla += this.Td + "<a href='" + resultado[i + a] + "'>Ver mas</a>" + this.Ctd;
                    }
                    else if (a == 5)
                    {
                        Tabla += this.Td + this.Input + resultado[i + (a + 1)] + "' id='cbx" + resultado[i + (a + 1)] + "' onclick='javascript:habilitarC(this)' />" + this.Ctd;
                    }
                    else
                    {
                        if ((this.TotalTuplas - 1) == a)
                        {
                            Tabla += this.Td + this.InputText + resultado[i + 6] + "' disabled/>" + this.Ctd;

                        }
                        else
                        {
                            //Construimos filas y columnas
                            Tabla += this.Td + resultado[i + a] + this.Ctd;
                        }

                    }
                    contador++;
                }

                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        else
        {

            Tabla = "";
        }
        return this.Tabla;
    }

    /**
    * Tablas genéricas: 
    * 
    * **/
    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas)
    {
        this.Table = "<table class='display ' id=" + idTabla + "> ";
        this.TotalTuplas = nombreColumnas.Length;
        this.Tabla = "";

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            Tabla = this.Table + this.Thead + this.Tr;

            for (int i = 0; i < nombreColumnas.Length; i++)
            {
                Tabla += this.Th + nombreColumnas[i] + this.Cth;
            }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Construimos filas y columnas
                    Tabla += this.Td + resultado[i + a] + this.Ctd;

                }
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }

    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas, int border)
    {
        this.Table = "<table style='border-color:#CED8F6;' border='" + border + "' width='900px' id=" + idTabla + "> ";
        this.TotalTuplas = nombreColumnas.Length;
        this.Tabla = "";

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            Tabla = this.Table + this.Theadd + this.Tr;

            for (int i = 0; i < nombreColumnas.Length; i++)
            {
                Tabla += this.Th + nombreColumnas[i] + this.Cth;
            }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Construimos filas y columnas
                    Tabla += this.Td + resultado[i + a] + this.Ctd;

                }
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }

    public string contruirTablaConf(string query, string idTabla, string[] nombreColumnas)
    {
        this.Table = "<table class='display ' id=" + idTabla + "> ";
        this.TotalTuplas = nombreColumnas.Length;
        this.Tabla = "";

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            Tabla = this.Table + this.Thead + this.Tr;

            for (int i = 0; i < nombreColumnas.Length; i++)
            {
                Tabla += this.Th + nombreColumnas[i] + this.Cth;
            }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Construimos filas y columnas

                    if (resultado[i + a].Equals("1753-01-01") || resultado[i + a].Equals("9999-12-31"))
                    {
                        Tabla += this.Td + "" + this.Ctd;
                    }
                    else
                    {
                        Tabla += this.Td + resultado[i + a] + this.Ctd;
                    }

                }
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }

    /*TABLA CON ID CONCATENADO CON UNA COMA*/

    public string contruirTablaGenC(string query, string idTabla, string[] nombreColumnas,
        string[] nombreAccion, string[] Accion)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length - nombreAccion.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < columnasDat)
                        Tabla += this.Td + resultado[i + (a + 1)] + this.Ctd;
                    else
                    {
                        Tabla += this.Td + this.A + Accion[contador] + "(\"" + resultado[i] + "\");'>" + nombreAccion[contador] + this.Ca + this.Ctd;
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }

    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas, int columnaInp, string idioma)
    {
        this.Table = "<table id='" + idTabla + "' class='display'> ";
        this.InputText = "<input type='text' name='txtIdNC' class='idNc' value='";
        this.TotalTuplas = nombreColumnas.Length;

        string tipoMay = "";
        string tipoMen = "";
        string clasMay = "";
        string clasMen = "";
        if (idioma.Equals("Auto"))
        {
            tipoMay = "Mayor";
            tipoMen = "Menor";
            clasMay = "Preventiva";
            clasMen = "Correctiva";
        }
        else
        {
            tipoMay = "Higher";
            tipoMen = "Less";
            clasMay = "Preventive";
            clasMen = "Corrective";
        }

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            //Al primer resultado le ponemos un Checkbox
            Tabla = this.Table + this.Thead + this.Tr;

            for (int i = 0; i < nombreColumnas.Length; i++)
            {
                Tabla += this.Th + nombreColumnas[i] + this.Cth;
            }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    if (a == (columnaInp - 1))
                    {
                        Tabla += this.Td + "<input type='text' name='txtComentario' class='comentario' value='" + resultado[i + a] + "' />" + this.Ctd;
                    }
                    else if (a == (columnaInp + 1))
                    {
                        Tabla += this.Td + "<input type='text' name='txtFechaCompromiso' class='fechCom' />" + this.Ctd;
                    }
                    else if (a == (columnaInp + 2))
                    {
                        Tabla += this.Td + "<input type='radio' name='Tipo" + i + "' value='1," + resultado[i + (a - 2)] + "' class='tipo' />" + tipoMay + "&nbsp;&nbsp;&nbsp;&nbsp;<input type='radio' name='Tipo" + i + "' value='2," + resultado[i + (a - 2)] + "' class='tipo' />" + tipoMen + "" + this.Ctd;
                    }
                    else if (a == (columnaInp + 3))
                    {
                        Tabla += this.Td + "<input type='radio' name='Clasificacion" + i + "' value='1," + resultado[i + (a - 3)] + "' class='clasi' />" + clasMay + "&nbsp;&nbsp;&nbsp;&nbsp;<input type='radio' name='Clasificacion" + i + "' value='2," + resultado[i + (a - 3)] + "' class='clasi' />" + clasMen + "" + this.Ctd;
                    }
                    else
                    {
                        //Construimos filas y columnas
                        Tabla += this.Td + resultado[i + a] + this.Ctd;
                    }

                }
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }
    /*METODO PARA CONSTRUIR TABLA CON CHECKBOX SIN LA OPCION TODOS*/
    public string contruirTablaGenSC(string query, string idTabla, string[] nombreColumnas, string nombreCheck)
    {
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            //Al primer resultado le ponemos un Checkbox
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            Tabla += this.Th + nombreColumnas[0] + this.Cth;

            if (nombreColumnas.Length > 0)
                for (int i = 1; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si es la primer columna de la tupla
                    //Agregamos el check
                    if (a == 0)
                        Tabla += this.Tr + this.Td + this.Input + resultado[i] + "'/>" + this.Ctd;
                    else
                    {
                        //Construimos filas y columnas
                        Tabla += this.Td + resultado[i + a] + this.Ctd;
                    }

                    contador++;
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }
    public string contruirTablaPublicados(string query, string idTabla, string[] nombreColumnas,
    string nombreAccion, string Accion, string[] width)
    {
        this.Th = "<th style='width:";
        int contador = 0;
        this.TotalTuplas = nombreColumnas.Length;

        //Restamos el total de columnas menos el número de acciones
        int columnasDat = nombreColumnas.Length;

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            //Construimos los encabezados de la tabla
            Tabla = this.Table + idTabla + "' >" + this.Thead + this.Tr;
            if (nombreColumnas.Length > 0)
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + width[i] + "'>" + nombreColumnas[i] + this.Cth;
                }

            //Construimos el cuerpo de la tabla
            Tabla += this.Ctr + this.Cthead + this.Tbody;
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Si la columna no es la de Accion, agregamos las filas y columnas
                    //Si es la de accion, agregamos los link's
                    if (a < (columnasDat - 1))
                        Tabla += this.Td + resultado[i + (a)] + this.Ctd;
                    else
                    {
                        Tabla += this.Td + this.A + Accion + "(" + resultado[i + a] + ");'>" + nombreAccion + this.Ca + this.Ctd;
                        contador++;
                    }
                }
                contador = 0;
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }



    public string contruirMenuVertical(string query, string idTabla)
    {
        this.Table = "<table  id=" + idTabla + "> ";
        this.Tabla = "<div class='Col2'>" + Table;


        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {

            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += 3)
            {
                Tabla += this.Tr;
                for (int a = 0; a < 2; a = a + 3)
                {
                    //Construimos filas y columnas
                    Tabla += this.Td + this.A + "getVista(" + resultado[i + a] + ");' class='boton'>" + resultado[i + 1] +
                        "<input ID='txtResportes" + resultado[i + a] + "'type='text' class='hide'value='" + resultado[i + 2] + "'/>" +
                        Ca + this.Ctd;
                    Tabla += this.Ctr;

                }

            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable + "</div>";
        }
        return this.Tabla;
    }

    public string contruirTablaGen(string query, string idTabla, string[] nombreColumnas, bool tfoot)
    {
        this.Table = "<table class='display ' id=" + idTabla + "> ";
        this.TotalTuplas = nombreColumnas.Length;
        this.Tabla = "";

        //Ejecutamos la consulta para inicializar la lista resultados
        resultado = sp.recuperaRegistros(query);

        //Si la lista no es vacía o nula, comenzamos a contruir
        if (resultado != null && resultado.Count > 0)
        {
            Tabla = this.Table + this.Thead + this.Tr;

            for (int i = 0; i < nombreColumnas.Length; i++)
            {
                Tabla += this.Th + nombreColumnas[i] + this.Cth;
            }

            if (tfoot)
            {
                Tabla += this.Ctr + this.Cthead;

                Tabla += this.Tfoot + this.Tr;
                for (int i = 0; i < nombreColumnas.Length; i++)
                {
                    Tabla += this.Th + "<input type='text' name='txt_" + nombreColumnas[i] + "' />" + this.Cth;

                }

                Tabla += this.Ctr + this.CTfood + this.Tbody;
            }
            else
            {
                Tabla += this.Ctr + this.Cthead + this.Tbody;
            }
            //Recorremos los resultados
            for (int i = 0; i < resultado.Count; i += this.TotalTuplas)
            {
                Tabla += this.Tr;
                for (int a = 0; a < nombreColumnas.Length; a++)
                {
                    //Construimos filas y columnas
                    Tabla += this.Td + resultado[i + a] + this.Ctd;

                }
                Tabla += this.Ctr;
            }
            //Terminamos de construir la tabla
            Tabla += this.Ctbody + this.Ctable;
        }
        return this.Tabla;
    }


}


