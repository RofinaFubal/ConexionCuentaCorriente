using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionCuentaCorriente.GetOpenItems;
using DataBase;


namespace ConexionCuentaCorriente
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt =  Convert.ToDateTime("2020-03-16", new CultureInfo("en-US"));

            Z_ROL_02_WS_GET_ACC_OPENITEMS openItemsService = new Z_ROL_02_WS_GET_ACC_OPENITEMS();
            string usuario = "ngonzalez";
            string clave = "Rof_qa_0421";
            string url = "http://s4rofciqa.rofina.com.ar:8000/sap/bc/srt/rfc/sap/z_rol_02_ws_get_acc_openitems/400/z_rol_02_ws_get_acc_openitems/z_rol_02_ws_get_acc_openitems";
            System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential(usuario, clave);
            openItemsService.Credentials = credenciales;

            openItemsService.Url = url;
            Z_ROL_02_WS_GET_ACC_OPENITEMS1 openItemsParameters = new Z_ROL_02_WS_GET_ACC_OPENITEMS1();
            openItemsParameters.COMPANYCODE = "1002";

            ZSD02_WS_CLIENTES_RANGES[] customerRange = new ZSD02_WS_CLIENTES_RANGES[1];

            ZSD02_WS_CLIENTES_RANGES Customer = new ZSD02_WS_CLIENTES_RANGES();
            Customer.KUNNR_DESDE = "28142";
            Customer.KUNNR_HASTA = "28142";

            customerRange[0] = Customer;

            openItemsParameters.I_T_CLIENTES_RANGES = customerRange;
            openItemsParameters.KEYDATE = DateTime.Now.AddDays(-300).ToString("yyyy-MM-dd");

            var response =  openItemsService.CallZ_ROL_02_WS_GET_ACC_OPENITEMS(openItemsParameters);

            Helper helper = new Helper();
            helper.InsertarCuentaCorriente(response);

        }
    }
}
