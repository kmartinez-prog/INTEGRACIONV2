﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace Contasis.Clase
{
    class ruc
    {
        public string Insertar(Clase.rucpropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string query0 = "select ccodrucemisor as  ruc  from cg_empemisor  where ccodrucemisor='" + Objet.ruc + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, cone);
                cone.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                { }
                else
                    {

                        string query = "Insert into cg_empemisor(ccodrucemisor,cdesrucemisor,flgactivo,nventaflg,ncompraflg,ncobranzaflg,npagoflg) values(" +
                            "'" + Objet.ruc + "', " +
                            "'" + Objet.empresa + "', " +
                            "'" + Objet.estado + "',"+ Objet.checkventas+","+ Objet.checkcompras+","+ Objet.checkcobranzas+","+ Objet.checkpagos+")";
                        cone = ConexionSql.Instancial().establecerconexion();
                        SqlCommand commando1 = new SqlCommand(query, cone);
                        cone.Open();
                        cadena = commando1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";
                    }
                

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }
            return cadena;
        }
        public string Actualizar(Clase.rucpropiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  cg_empemisor SET cdesrucemisor='" + Objet.empresa + "'," +
                "flgactivo='" + Objet.estado + "',nventaflg=" + Objet.checkventas + ",ncompraflg=" + Objet.checkcompras+ ", ncobranzaflg="+Objet.checkcobranzas+ ", npagoflg="+Objet.checkpagos+ " where ccodrucemisor='" + Objet.ruc + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                cadena = commando1.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }
            return cadena;
        }
        public string Eliminar(Clase.rucpropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            string query0 = "select cg_empresa.NOMEMPRESA as Empresa From cg_empemisor inner join cg_empresa on cg_empemisor.ccodrucemisor=CG_EMPRESA.ccodrucemisor "+
                            " where  cg_empemisor.ccodrucemisor='" + Objet.ruc + "'";
            cone = ConexionSql.Instancial().establecerconexion();
            SqlCommand commando = new SqlCommand(query0, cone);
            cone.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter(commando);
            data.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("No puede eliminar este ruc esta activo con esta empresa : "+dt.Rows[0]["Empresa"].ToString()  ,"Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {

                try
                {
                    string cadena1 = "Delete from cg_empemisor  where ccodrucemisor='" + Objet.ruc + "'";
                    cone = ConexionSql.Instancial().establecerconexion();
                    SqlCommand commando1 = new SqlCommand(cadena1, cone);
                    cone.Open();
                    cadena = commando1.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());
                    cadena = ex1.Message;
                }
                finally
                {
                    if (cone.State == ConnectionState.Open)
                    {
                        cone.Close();
                    }

                }
                
            }
            return cadena;
        }
    }
}
