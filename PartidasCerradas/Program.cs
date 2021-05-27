using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartidasCerradas.PartidasCerradas;

namespace PartidasCerradas
{
    class Program
    {
        static void Main(string[] args)
        {
                      
            Z_ROL_02_WS_GET_ACC_STATEMENT closeItemsService = new Z_ROL_02_WS_GET_ACC_STATEMENT();
            string usuario = "ngonzalez";
            string clave = "Rof_qa_0521";
            string url = "http://s4rofciqa.rofina.com.ar:8000/sap/bc/srt/rfc/sap/z_rol_02_ws_get_acc_statement/400/z_rol_02_ws_get_acc_statement/z_rol_02_ws_get_acc_statement";
            System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential(usuario, clave);
            closeItemsService.Credentials = credenciales;

            int customerDesde = 10000;
            int customerHasta = 20000;
            var response = new Z_ROL_02_WS_GET_ACC_STATEMENTResponse();



            for (; customerHasta <= 70000;)
            {



                closeItemsService.Url = url;
                Z_ROL_02_WS_GET_ACC_STATEMENT1 openItemsParameters = new Z_ROL_02_WS_GET_ACC_STATEMENT1();
                openItemsParameters.COMPANYCODE = "1002";

                ZSD02_WS_CLIENTES_RANGES[] customerRange = new ZSD02_WS_CLIENTES_RANGES[1];

                ZSD02_WS_CLIENTES_RANGES Customer = new ZSD02_WS_CLIENTES_RANGES();
                Customer.KUNNR_DESDE = customerDesde.ToString();
                Customer.KUNNR_HASTA = customerHasta.ToString();

                customerRange[0] = Customer;

                openItemsParameters.I_T_CLIENTES_RANGES = customerRange;
                openItemsParameters.DATE_FROM = DateTime.Now.AddDays(-148).ToString("yyyy-MM-dd");
                openItemsParameters.DATE_TO = DateTime.Now.AddDays(-148).ToString("yyyy-MM-dd");
                

                try
                {
                    response = closeItemsService.CallZ_ROL_02_WS_GET_ACC_STATEMENT(openItemsParameters);
                }
                catch (Exception ex)
                {
                    //if (response.E_T_PARTIDAS.Count() > 0)
                    //{
                    //    Helper help = new Helper();
                    //    help.InsertarCuentaCorriente(response);
                    //    customerDesde = customerDesde + 10000;
                    //    customerHasta = customerHasta + 10000;
                    //}
                }

                //Helper helper = new Helper();
                //helper.InsertarCuentaCorriente(response);
                //customerDesde = customerDesde + 10000;
                //customerHasta = customerHasta + 10000;


            }





        }
    }
}
