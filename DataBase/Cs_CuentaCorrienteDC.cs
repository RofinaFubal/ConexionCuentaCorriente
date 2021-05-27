using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.GetOpenItems;


namespace DataBase
{
    public class Cs_CuentaCorrienteDC
    {
       
        public void InsertarCuentaCorriente(List<CuentaCorriente_Descarga> list)
        {
            try
            {
                var context = new Rofina_biEntities1();
                context.CuentaCorriente_Descarga.AddRange(list);
                context.CuentaCorriente_Descarga();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    
}
