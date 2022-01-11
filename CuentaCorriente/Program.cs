using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;
using CuentaCorriente.OpenItems;
using System.Configuration;

namespace CuentaCorriente
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Z_ROL_02_WS_GET_ACC_OPENITEMS openItemsService = new Z_ROL_02_WS_GET_ACC_OPENITEMS();
            
            string usuario = ConfigurationSettings.AppSettings["Usuario"];
            string clave = ConfigurationSettings.AppSettings["Clave"];
            //string url = "http://s4rofciqa.rofina.com.ar:8000/sap/bc/srt/rfc/sap/z_rol_02_ws_get_acc_openitems/400/z_rol_02_ws_get_acc_openitems/z_rol_02_ws_get_acc_openitems";
            string url = ConfigurationSettings.AppSettings["UrlPartidasAbiertas"];
            //url = "http://s4rofciqa.rofina.com.ar:8000/sap/bc/srt/rfc/sap/z_rol_02_ws_get_acc_openitems/400/z_rol_02_ws_get_acc_openitems/z_rol_02_ws_get_acc_openitems";
            System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential(usuario, clave);
            openItemsService.Credentials = credenciales;

            int customerDesde = Convert.ToInt32(ConfigurationSettings.AppSettings["CustomerFrom"]);
            int customerHasta = Convert.ToInt32(ConfigurationSettings.AppSettings["CustomerFrom"]) + 10000; 
            var response = new Z_ROL_02_WS_GET_ACC_OPENITEMSResponse();

            for (; customerHasta <= Convert.ToInt32(ConfigurationSettings.AppSettings["CustomerTo"]); )
            {



                openItemsService.Url = url;
                Z_ROL_02_WS_GET_ACC_OPENITEMS1 openItemsParameters = new Z_ROL_02_WS_GET_ACC_OPENITEMS1();
                openItemsParameters.COMPANYCODE = "1002";

                ZSD02_WS_CLIENTES_RANGES[] customerRange = new ZSD02_WS_CLIENTES_RANGES[1];

                ZSD02_WS_CLIENTES_RANGES Customer = new ZSD02_WS_CLIENTES_RANGES();
                Customer.KUNNR_DESDE = customerDesde.ToString();
                Customer.KUNNR_HASTA = customerHasta.ToString();

                customerRange[0] = Customer;

                openItemsParameters.I_T_CLIENTES_RANGES = customerRange;
                openItemsParameters.KEYDATE = DateTime.Now.AddDays(-200).ToString("yyyy-MM-dd");

                try { 
                response = openItemsService.CallZ_ROL_02_WS_GET_ACC_OPENITEMS(openItemsParameters);
                }
                catch(Exception ex)
                {
                    if (response.E_T_PARTIDAS.Count() > 0)
                    {
                        Helper help = new Helper();
                        help.InsertarCuentaCorriente(response);
                        customerDesde = customerDesde + 10000;
                        customerHasta = customerHasta + 10000;
                    }
                }

                Helper helper = new Helper();
                helper.InsertarCuentaCorriente(response);
                customerDesde = customerDesde + 10000;
                customerHasta = customerHasta + 10000;


            }
        }
    }
}
