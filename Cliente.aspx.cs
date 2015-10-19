using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Cliente_Cliente : System.Web.UI.Page
{
    //Validaciones
    private static String CADENA_VACIA = "";
    private String regexpNom = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpApp = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpApm = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpFecNa = @"^[a-záéíóúñ]*$";
    private String regexpNumIFE = @"^[1-9]{13}$";
    private String regexpDom = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpNumDom = @"^[1-9]{4}[a-zA-ZÁÉÍÓÚÑ]{1}$";
    private String regexpSenPar = @"^[a-zA-ZÁÉÍÓÚÑ][a-záéíóúñ]*$";
    private String regexpTel = @"^[1-9]{10}$";
    private String regexpTela = @"^[1-9]{10}$";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //***************************** MÉTODO INSERTAR ******************************

    protected void btn_Agregar_Click(object sender, EventArgs e)
    {
        DataClassesDataContext scc = new DataClassesDataContext();

        Cliente obj_Cliente = new Cliente();

        try
        {
            //Validacion
            cleanMsgTxt();

            if (validaForm() == 0)
            {
                obj_Cliente.nomCliente = txt_name.Text.Trim();
                obj_Cliente.apCliente = txt_app.Text.Trim();
                obj_Cliente.amCliente = txt_apm.Text.Trim();
                obj_Cliente.idSexo = Convert.ToByte(txt_sexo.SelectedValue);
                obj_Cliente.fechaNac = txt_fn.Text.Trim();
                obj_Cliente.numIFE = txt_IFE.Text.Trim();
                obj_Cliente.domicilio = txt_Dom.Text.Trim();
                obj_Cliente.num = txt_Num.Text.Trim();
                obj_Cliente.descripCasa = txt_casa.Text.Trim();
                obj_Cliente.telefono = txt_tel.Text.Trim();
                obj_Cliente.telefonoAlt = txt_tela.Text.Trim();

                scc.Cliente.InsertOnSubmit(obj_Cliente); //uso del metodo

                scc.SubmitChanges(); //cambioss

                lbl_Mensaje.Text = "Cliente Agregado";
                
            }

        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();

        }
    }
   
    

    //***************************** MÉTODO MODIFICAR******************************

    protected void btn_Modificar_Click(object sender, EventArgs e)
    {
        DataClassesDataContext scc = new DataClassesDataContext();


        try
        {
            //Validacion
            

            if (validaForm() == 0)
            {
                Cliente obj_Cliente = (
                                      from a in scc.Cliente
                                      where a.nomCliente == txt_name.Text.Trim()
                                      select a
                                     ).Single();//solo un dato

                obj_Cliente.nomCliente = txt_name.Text.Trim();
                obj_Cliente.apCliente = txt_app.Text.Trim();
                obj_Cliente.amCliente = txt_apm.Text.Trim();
                obj_Cliente.idSexo = Convert.ToByte(txt_sexo.Text.Trim()); // como en la base es tiyint y se toma de una caja de txt se debe de convertir el dato
                obj_Cliente.fechaNac = txt_fn.Text.Trim();
                obj_Cliente.numIFE = txt_IFE.Text.Trim();
                obj_Cliente.domicilio = txt_Dom.Text.Trim();
                obj_Cliente.num = txt_Num.Text.Trim();
                obj_Cliente.descripCasa = txt_casa.Text.Trim();
                obj_Cliente.telefono = txt_tel.Text.Trim();
                obj_Cliente.telefonoAlt = txt_tela.Text.Trim();

                scc.SubmitChanges(); //Hace cambios

                lbl_Mensaje.Text = "El cliente se modificó correctamente";
            }
        }
        catch (Exception ex)
        {
            lbl_Mensaje.Text = "ERROR - " + ex.Message.ToString();
        }
        
        txt_name.Text = "";
        txt_app.Text = "";
        txt_apm.Text = "";
        txt_fn.Text = "";
        txt_IFE.Text = "";
        txt_Dom.Text = "";
        txt_Num.Text = "";
        txt_casa.Text = "";
        txt_tel.Text = "";
        txt_tela.Text = "";
    }
   

    //Validacion

    private void cleanMsgTxt()
    {
        lblNom.Text = CADENA_VACIA;
        lblApp.Text = CADENA_VACIA;
        lblApm.Text = CADENA_VACIA;
        lblSexo.Text = CADENA_VACIA;
        lblFn.Text = CADENA_VACIA;
        lblIFE.Text = CADENA_VACIA;
        lblDom.Text = CADENA_VACIA;
        lblNum.Text = CADENA_VACIA;
        lblCasa.Text = CADENA_VACIA;
        lblTel.Text = CADENA_VACIA;
        lblTela.Text = CADENA_VACIA;

    }
    private int validaForm()
    {
        int result = 0;
        result += valdidaRegxp(regexpNom, lblNom, "El nombre no puede ir vacio y debe comenzar con mayúscula", txt_name.Text);

        result += valdidaRegxp(regexpApp, lblApp, "El apellido paterno no puede ir vacio y debe comenzar con mayúscula", txt_app.Text);

        result += valdidaRegxp(regexpApm, lblApm, "El apellido materno no puede ir vacio y debe comenzar con mayúscula", txt_apm.Text);

        result += valdidaRegxp(regexpNumIFE, lblIFE, "El numero de IFE no puede ir vacio y contiene 13 dígitos", txt_IFE.Text);

        result += valdidaRegxp(regexpDom, lblDom, "El domicilio no puede ir vacio y debe comenzar con mayúscula", txt_Dom.Text);

        result += valdidaRegxp(regexpNumDom, lblNum, "El numero de domicilio no puede ir vacio, máximo 4 dígitos", txt_Num.Text);

        result += valdidaRegxp(regexpSenPar, lblCasa, "Las señas particulares de la casa no pueden ir vacio", txt_casa.Text);
       
        result += valdidaRegxp(regexpTel, lblTel, "El numero de teléfono no puede ir vacio y contiene 10 dígitos", txt_tel.Text);

        result += valdidaRegxp(regexpTela, lblTela, "Debes ingresar un numero adicional no puede ir vacio y contiene 10 dígitos", txt_tela.Text);
                                

        return result;
    }

    private int valdidaRegxp(String regexp, Label lbl, String msg, String val)
    {
        Regex reg = new Regex(regexp);
        Match match = reg.Match(val);
        if (!match.Success)
        {
            lbl.Text = msg;
            return 1;
        }
        lbl.Text = CADENA_VACIA;
        return 0;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cliente.aspx");
    }
    protected void txt_name_TextChanged(object sender, EventArgs e)
    {

    }
}
