using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionCuentaCorriente.GetOpenItems;


namespace DataBase
{
    public class Helper
    {
        public bool InsertarCuentaCorriente( Z_ROL_02_WS_GET_ACC_OPENITEMSResponse response)
        {
            try
            {
                int cantRegistrostotal = response.E_T_PARTIDAS.Count();
                int cantRegistrosParcial = 0;
                int cantidadRegistrosInsertar = 200000;

                if (cantRegistrostotal > 20000)
                {
                    cantidadRegistrosInsertar = 20000;
                }
                else
                    cantidadRegistrosInsertar = cantRegistrostotal;


                List<DataBase.CuentaCorriente_Descarga> lista = new List<CuentaCorriente_Descarga>();
                int count = 0;
                Cs_CuentaCorrienteDC csCuentaCorrienteDc = new Cs_CuentaCorrienteDC();

                CuentaCorriente_Descarga cuentaCorrienteDescarga = new CuentaCorriente_Descarga();
                foreach (var resp in response.E_T_PARTIDAS)
                {
                    cuentaCorrienteDescarga = new CuentaCorriente_Descarga();
                    if (cantRegistrosParcial == 0)
                        cantRegistrosParcial = cantRegistrostotal;
                    cuentaCorrienteDescarga.Alloc_Nmbr = resp.ALLOC_NMBR;
                    cuentaCorrienteDescarga.Amount = resp.AMOUNT;
                    cuentaCorrienteDescarga.Amount_Long = resp.AMOUNT_LONG;
                    cuentaCorrienteDescarga.Amt_Doccur = resp.AMT_DOCCUR;
                    cuentaCorrienteDescarga.Amt_Doccur_Long = resp.AMT_DOCCUR_LONG;
                    cuentaCorrienteDescarga.Bill_Doc = resp.BILL_DOC;
                    cuentaCorrienteDescarga.Bline_Date = Convert.ToDateTime(resp.BLINE_DATE, new CultureInfo("en-US"));
                    cuentaCorrienteDescarga.Bus_Area = resp.BUS_AREA;
                    cuentaCorrienteDescarga.Clr_Doc_No = resp.CLR_DOC_NO;
                    cuentaCorrienteDescarga.Comp_Code = resp.COMP_CODE;
                    cuentaCorrienteDescarga.Currency = resp.CURRENCY;
                    cuentaCorrienteDescarga.Customer = resp.CUSTOMER;
                    cuentaCorrienteDescarga.Db_Cr_Ind = resp.DB_CR_IND;
                    cuentaCorrienteDescarga.Doc_Date = Convert.ToDateTime(resp.DOC_DATE, new CultureInfo("en-US"));
                    cuentaCorrienteDescarga.Doc_Type = resp.DOC_TYPE;
                    cuentaCorrienteDescarga.Dsct_Days1 = resp.DSCT_DAYS1;
                    cuentaCorrienteDescarga.Dsct_Days2 = resp.DSCT_DAYS2;
                    cuentaCorrienteDescarga.Fisc_Year = resp.FISC_YEAR;
                    cuentaCorrienteDescarga.Fis_Period = resp.FIS_PERIOD;
                    cuentaCorrienteDescarga.Inv_Item = resp.INV_ITEM;
                    cuentaCorrienteDescarga.Inv_Ref = resp.INV_REF;
                    cuentaCorrienteDescarga.Inv_Year = resp.INV_YEAR;
                    cuentaCorrienteDescarga.Item_Text = resp.ITEM_TEXT;
                    cuentaCorrienteDescarga.Lc_Amount = resp.LC_AMOUNT;
                    cuentaCorrienteDescarga.Lc_Amount_long = resp.LC_AMOUNT_LONG;
                    cuentaCorrienteDescarga.Loc_Currcy = resp.LOC_CURRCY;
                    cuentaCorrienteDescarga.Netterms = resp.NETTERMS;
                    cuentaCorrienteDescarga.Net_Amount = resp.NET_AMOUNT;
                    cuentaCorrienteDescarga.Net_Amount_Long = resp.NET_AMOUNT_LONG;
                    cuentaCorrienteDescarga.Pmnttrms = resp.PMNTTRMS;
                    cuentaCorrienteDescarga.Pstng_Date = Convert.ToDateTime(resp.PSTNG_DATE, new CultureInfo("en-US"));
                    cuentaCorrienteDescarga.Ref_Doc = resp.REF_DOC;
                    cuentaCorrienteDescarga.Ref_Doc_No = resp.REF_DOC_NO;
                    cuentaCorrienteDescarga.Ref_Doc_No_Long = resp.REF_DOC_NO_LONG;
                    cuentaCorrienteDescarga.Ref_Key_2 = resp.REF_KEY_2;
                    cuentaCorrienteDescarga.Sp_Gl_Ind = resp.SP_GL_IND;
                    cuentaCorrienteDescarga.Tax_Code = resp.TAX_CODE;
                    cuentaCorrienteDescarga.T_Currency = resp.T_CURRENCY;

                    lista.Add(cuentaCorrienteDescarga);
                    count++;
                    if (count == cantidadRegistrosInsertar || cantRegistrosParcial < cantidadRegistrosInsertar)
                    {
                        if (cantRegistrosParcial < cantidadRegistrosInsertar)
                        {
                            cantidadRegistrosInsertar = cantRegistrosParcial;

                        }
                        else
                        {

                            cantRegistrosParcial = cantRegistrosParcial - cantidadRegistrosInsertar;
                            count = 0;
                            csCuentaCorrienteDc.InsertarCuentaCorriente(lista);
                            lista = new List<CuentaCorriente_Descarga>();
                        }

                    }


                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
