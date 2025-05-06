using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace Contasis
{
    class ruc_postgres
    {
        public string Insertar(Clase.rucpropiedades Objet)
        {
            string cadena = "";

            DataTable tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string query0 = "select ccodrucemisor as  ruc  from cg_empemisor where ccodrucemisor='"+ Objet.ruc + "'";
                NpgsqlCommand cmdp = new NpgsqlCommand(query0, conexion);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                { }
                else
                {
                    string query = "Insert into cg_empemisor(ccodrucemisor,cdesrucemisor,flgactivo,nventaflg,ncompraflg,ncobranzaflg,npagoflg,ncomfondom,ncobranzacomercial,ncomproductoflg) values(" +
                                  "'" + Objet.ruc + "', " +
                                  "'" + Objet.empresa + "', " +
                                  "'" + Objet.estado + "'," + Objet.checkventas + "," + Objet.checkcompras + "," + 
                                  Objet.checkcobranzas + "," + Objet.checkpagos + "," + Objet.nfondoM + "," + Objet.check_cobranzacomercial + "," + Objet.ncomproductoflg+ ")";
                    NpgsqlCommand command3 = new NpgsqlCommand(query, conexion);
                    cadena = command3.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";
                    
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }
        public string Actualizar(Clase.rucpropiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
               string query = "update  cg_empemisor SET cdesrucemisor='" + Objet.empresa + "'," +
               "flgactivo='" + Objet.estado + "',nventaflg=" + Objet.checkventas + ",ncompraflg=" + Objet.checkcompras +
               ", ncobranzaflg=" + Objet.checkcobranzas + ", npagoflg=" + Objet.checkpagos + ", ncomfondom=" + Objet.nfondoM +
               ", ncomproductoflg=" + Objet.ncomproductoflg +
               ", ncomventaflg=" + Objet.ncomventaflg +
               ", ncomcompraflg=" + Objet.ncomcompraflg +
               ", ncobranzacomercial=" + Objet.check_cobranzacomercial +
               " where ccodrucemisor='" + Objet.ruc + "'";
                NpgsqlCommand command3 = new NpgsqlCommand(query, conexion);
                cadena = command3.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";
                
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }
        public string Eliminar(Clase.rucpropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            string query0 = "select cg_empresa.NOMEMPRESA as Empresa From cg_empemisor inner join cg_empresa on cg_empemisor.ccodrucemisor=CG_EMPRESA.ccodrucemisor " +
                            " where  cg_empemisor.ccodrucemisor='" + Objet.ruc + "'";
            NpgsqlCommand cmdp = new NpgsqlCommand(query0, conexion);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
            data.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("No puede eliminar este ruc esta activo con esta empresa : " + dt.Rows[0]["Empresa"].ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    string cadena1 = "Delete from cg_empemisor  where ccodrucemisor='" + Objet.ruc + "'";
                    NpgsqlCommand command3 = new NpgsqlCommand(cadena1, conexion);
                    cadena = command3.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                    cadena = ex1.Message;
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }

            }
            return cadena;
        }
    }
}
