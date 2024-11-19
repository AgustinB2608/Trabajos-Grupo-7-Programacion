using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using NEGOCIOS;

namespace VISTAS
{
    public partial class ModificarMedico : System.Web.UI.Page
    {
        NegocioMedico regM = new NegocioMedico();
        Medico reg = new Medico();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            bool cambios = false;

            // Verifica y asigna nuevos valores solo si son distintos al valor actual
            if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && txtNombre.Text.Trim() != reg.getNombre())
            {
                reg.setNombre(txtNombre.Text.Trim());
                cambios = true;
            }

            if (!string.IsNullOrEmpty(txtApellido.Text.Trim()) && txtApellido.Text.Trim() != reg.getApellido())
            {
                reg.setApellido(txtApellido.Text.Trim());
                cambios = true;
            }

            if (!string.IsNullOrEmpty(txtMatricula.Text.Trim()) && txtMatricula.Text.Trim() != reg.getCodMedico())
            {
                reg.setCodMedico(txtMatricula.Text.Trim());
                cambios = true;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && txtEmail.Text.Trim() != reg.getEmail())
            {
                reg.setEmail(txtEmail.Text.Trim());
                cambios = true;
            }

            if (!string.IsNullOrEmpty(txtCelular.Text.Trim()) && txtCelular.Text.Trim() != reg.getCelular())
            {
                reg.setCelular(txtCelular.Text.Trim());
                cambios = true;
            }

            if (!string.IsNullOrEmpty(txtNacionalidad.Text.Trim()) && txtNacionalidad.Text.Trim() != reg.getNacionalidad())
            {
                reg.setNacionalidad(txtNacionalidad.Text.Trim());
                cambios = true;
            }

            if (!string.IsNullOrEmpty(txtDireccion.Text.Trim()) && txtDireccion.Text.Trim() != reg.getDireccion())
            {
                reg.setDireccion(txtDireccion.Text.Trim());
                cambios = true;
            }

            // Verificación de DropDownList y asignación de cambios
            if (!string.IsNullOrEmpty(ddlProvincia.SelectedValue) && ddlProvincia.SelectedValue != reg.getProvincia())
            {
                reg.setProvincia(ddlProvincia.SelectedValue);
                cambios = true;
            }

            if (!string.IsNullOrEmpty(ddlLocalidad.SelectedValue) && ddlLocalidad.SelectedValue != reg.getLocalidad())
            {
                reg.setLocalidad(ddlLocalidad.SelectedValue);
                cambios = true;
            }

            if (!string.IsNullOrEmpty(ddlSexo.SelectedValue) && ddlSexo.SelectedValue != reg.getSexo())
            {
                reg.setSexo(ddlSexo.SelectedValue);
                cambios = true;
            }

            if (!string.IsNullOrEmpty(ddlEspecialidad.SelectedValue) && ddlEspecialidad.SelectedValue != reg.getEspecialidad())
            {
                reg.setEspecialidad(ddlEspecialidad.SelectedValue);
                cambios = true;
            }

            if (!string.IsNullOrEmpty(ddlHorario.SelectedValue) && ddlHorario.SelectedValue != reg.getHorario())
            {
                reg.setHorario(ddlHorario.SelectedValue);
                cambios = true;
            }

            if (!string.IsNullOrEmpty(ddlDiasAtencion.SelectedValue) && ddlDiasAtencion.SelectedValue != reg.getDiasAtencion())
            {
                reg.setDiasAtencion(ddlDiasAtencion.SelectedValue);
                cambios = true;
            }

            // Validación de la fecha de nacimiento
            if (!string.IsNullOrEmpty(ddlDia.SelectedValue) &&
                !string.IsNullOrEmpty(ddlMes.SelectedValue) &&
                !string.IsNullOrEmpty(ddlAño.SelectedValue))
            {
                string fecha = ddlDia.SelectedValue + "/" + ddlMes.SelectedValue + "/" + ddlAño.SelectedValue;

                // Convertir el string 'fecha' a DateTime
                DateTime fechaSeleccionada = DateTime.ParseExact(fecha, "d/M/yyyy", null);

                // Comparar con la fecha de nacimiento del objeto 'reg'
                if (fechaSeleccionada != reg.getFechaNacimiento())
                {
                    reg.setFechaNacimiento(fechaSeleccionada); // Asumimos que setFechaNacimiento acepta DateTime
                    cambios = true;
                }
            }
            else
            {
                lblMensajeFecha.Text = "Por favor, seleccione una fecha completa.";
            }

            // Si hubo cambios, llamamos al metodo de modificacion
            if (cambios)
            {
                
                bool exito = regM.modificarMedico(reg);
                lblMensaje.Text = exito ? "Modificado con éxito." : "Hubo un error al modificar los datos.";
                lblMensaje.ForeColor = exito ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            else
            {
                lblMensaje.Text = "No se realizaron cambios.";
            }
        }


    }
}