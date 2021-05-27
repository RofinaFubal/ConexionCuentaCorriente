using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;


namespace BaseDatos
{
    public class Cs_CuentaCorrienteDC
    {
                
        public void InsertarCuentaCorriente(List<CuentaCorriente_Descarga> list)
        {
            try
            {
                var context = new Rofina_biEntities1();
                context.CuentaCorriente_Descarga.AddRange(list);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
