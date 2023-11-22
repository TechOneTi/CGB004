using System.Text;

namespace CGB004.Data.Code.Business.SAFX
{
    public class SAFXDALSQL
    {
        //public static string GetNFMasterSAF()
        //{
        //    StringBuilder sql = new();

        //    sql.AppendLine(@"
        //       SELECT DISTINCT 
        //                     RFE.ORG_ID,
        //                     ENT.ORGANIZATION_ID,
        //                     ENT.LOCATION_ID,
        //                     ENT.GL_DATE,
        //                     INV.ENTITY_ID,
        //                     INV.INVOICE_NUM,
        //                     INV.INVOICE_DATE,
        //                     INV.INVOICE_ID,
        //                     INV.INVOICE_TYPE_ID,
        //                     INV.TERMS_ID,
        //                     INV.TERMS_DATE,
        //                     INV.GROSS_TOTAL_AMOUNT,
        //                     INV.ICMS_AMOUNT,
        //                     INV.ICMS_TAX,
        //                     INV.ICMS_BASE,
        //                     INV.IPI_AMOUNT,
        //                     INV.ICMS_ST_AMOUNT,
        //                     INV.ICMS_ST_BASE,
        //                     INV.ISS_AMOUNT,
        //                     INV.ISS_TAX,
        //                     INV.ISS_BASE,
        //                     INV.IR_AMOUNT,
        //                     INV.IR_TAX,
        //                     INV.IR_BASE,
        //                     INV.INSS_AMOUNT,
        //                     INV.INSS_TAX,
        //                     INV.INSS_BASE,
        //                     INV.CREATED_BY,
        //                     INV.INVOICE_AMOUNT,
        //                     INV.ATTRIBUTE9 AS CHAVE_NFE,
        //                     INV.ATTRIBUTE12,
        //                      DBMS_LOB.SUBSTR(INV.COMMENTS, 300) AS NUM_TICKET,
        //                     CFST.SERVICE_TYPE_CODE  AS TIPO_SERVICO,    -- TECH ONE - WILLIAN
        //                     --
        //                     -- Projeto REINF
        //                     -- Inicio - Wellington Silva - TRI-CS - SR 14253
        //                     -- cnpjPrestador
        //                     (select cffea.document_number 
        //                        from cll_f189_invoices cfi
        //                            ,cll_f189_fiscal_entities_all cffea
        //                       where cfi.operation_id = ENT.operation_id
        //                         and cfi.organization_id = ent.organization_id
        //                         and cfi.entity_id = cffea.entity_id
        //                         and cffea.document_type = 'CNPJ') NUMCGCSVCCOSCVL,    -- cnpjPrestador / TRI-CS - SR 14253
        //                     -- tpInscEstab
        //                     NVL2(INV.CNO_ID, 4, 1) AS INDINSNAC,                      -- tpInscEstab / TRI-CS - SR 14253
        //                     -- nrInscEstab
        //                     (select xr.registration_number 
        //                        from cll_f189_invoices cfi 
        //                            ,cll_f189_fiscal_entities_all cffea
        //                            ,xle_registrations xr
        //                       where cfi.operation_id = ENT.operation_id
        //                         and cfi.organization_id = ent.organization_id
        //                         and cfi.cno_id is null
        //                         and cfi.location_id = cffea.location_id
        //                         and cffea.document_number = xr.registration_number
        //                         and xr.source_table = 'XLE_ETB_PROFILES'
        //                        --
        //                       UNION
        //                        --
        //                      select cfcp.cno_number
        //                        from cll_f189_invoices cfi
        //                            ,cll_f407_cno_profiles cfcp
        //                       where cfi.operation_id = ENT.operation_id
        //                         and cfi.organization_id = ent.organization_id
        //                         and cfi.cno_id = cfcp.cno_id) NUMINSNAC,              -- nrInscEstab / TRI-CS - SR 14253
        //                     -- indObra
        //                     NVL2(INV.CNO_ID
        //                         ,TO_NUMBER(CFCP.CONSTRUCTION_TYPE)
        //                         ,0) AS INDSVCCOSCVL,                                  -- indObra / TRI-CS - SR 14253
        //                     -- Total Linhas
        //                     (SELECT COUNT(1) 
        //                        FROM APPS.CLL_F189_INVOICE_LINES CFIL
        //                       WHERE CFIL.INVOICE_ID = INV.INVOICE_ID ) AS TOT_LINHAS  -- Total Linhas / TRI-CS - SR 14253
        //                FROM CLL_F189_ENTRY_OPERATIONS    ENT,
        //                     CLL_F189_INVOICES            INV,
        //                     CLL_F189_INVOICE_TYPES       TIP,
        //                     CLL_F189_FISCAL_ENTITIES_ALL RFE,
        //                     AP_SUPPLIER_SITES_ALL        PVS,
        //                     XLE_REGISTRATIONS            XR,   -- TRI-CS - SR 14253
        //                     CLL_F407_CNO_PROFILES        CFCP, -- TRI-CS - SR 14253
        //                     CLL_F189_CITY_SRV_TYPE_RELS CFCS,  -- TECH ONE - WILLIAN
        //                     CLL_F189_SERVICE_TYPES CFST        -- TECH ONE - WILLIAN
        //            WHERE  
        //              ENT.ORGANIZATION_ID  = INV.ORGANIZATION_ID
        //              AND    ENT.OPERATION_ID     = INV.OPERATION_ID
        //              AND    ENT.STATUS           = 'COMPLETE'
        //              AND    INV.ATTRIBUTE1      IS NULL  
        //              AND    INV.INVOICE_TYPE_ID  = TIP.INVOICE_TYPE_ID
        //              AND    TIP.OPERATION_TYPE   = 'E'
        //              AND    INV.ENTITY_ID        = RFE.ENTITY_ID
        //              AND    RFE.VENDOR_SITE_ID   = PVS.VENDOR_SITE_ID
        //              AND    RFE.ORG_ID           = PVS.ORG_ID
        //              AND    PVS.VENDOR_SITE_ID   = RFE.VENDOR_SITE_ID
        //              AND    RFE.DOCUMENT_NUMBER  = XR.REGISTRATION_NUMBER(+) -- TRI-CS - SR 14253
        //              AND    XR.SOURCE_TABLE(+)   = 'XLE_ETB_PROFILES'        -- TRI-CS - SR 14253
        //              AND    INV.CNO_ID           = CFCP.CNO_ID(+)            -- TRI-CS - SR 14253          
        //              AND    TIP.INVOICE_TYPE_CODE NOT IN ('1')              -- TRI-CS - SR 14253
        //              AND    TIP.INVOICE_TYPE_CODE NOT IN ('1','2','3','4','5','6','7','8','9','10','11','12','15','16','17','18','22',
        //        '23','25','26','27','28','29','30','31','43','44','52','53')      -- TRI-CS - SR 14253
        //              AND    INV.ISS_CITY_ID  = CFCS.CITY_ID (+)                                     -- TECH ONE - WILLIAN
        //              AND    CFCS.MUNICIPAL_SERVICE_TYPE_ID = CFST.SERVICE_TYPE_ID (+)               -- TECH ONE - WILLIAN
        //              AND    INV.DFLT_CITY_SERVICE_TYPE_REL_ID = CFCS.CITY_SERVICE_TYPE_REL_ID (+)   -- TECH ONE - WILLIAN
        //              AND    RFE.ORG_ID NOT IN (416, 457, 417, 1466, 1826, 1926, 2307, 2586)
        //        ORDER BY 1, 2, 3, 4, 5 ");
            

        //    return sql.ToString();
        //}

        
        public static string InserirSAFX01()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"
               insert into MSAF.SAFX01 (COD_EMPRESA, COD_ESTAB, DATA_OPERACAO, CONTA_DEB_CRED, IND_DEB_CRE, ARQUIVAMENTO, VLR_LANCTO, CONTRA_PART, CENTRO_CUSTO, CENTRO_DESPESA, HISTPADRAO, COD_OPERACAO, HISTCOMPL, COD_INDICE_CONV, VLR_OPER_IND, DAT_GRAVACAO, NUM_LANCAMENTO, TIPO_LANCTO, IND_PFJ_EMPRESA, COD_PFJ_EMPRESA, COD_SERVICO, IDENTIF_LANC_RES, COD_SISTEMA_ORIG, IDENTIF_SALDO, DSC_RESERVADO1, DSC_RESERVADO2, DSC_RESERVADO3, DSC_RESERVADO4, DSC_RESERVADO5, DSC_RESERVADO6, DSC_RESERVADO7, DSC_RESERVADO8, NUM_PROCESSO, DAT_LANCTO_EXTEMP, PST_ID, COD_EVENTO_DESIF, COD_ESTADO_ORIG, COD_MUNIC_ORIG, NUM_LOTE) 
               values(:COD_EMPRESA, :COD_ESTAB, :DATA_OPERACAO, :CONTA_DEB_CRED, :IND_DEB_CRE, :ARQUIVAMENTO, :VLR_LANCTO, :CONTRA_PART, :CENTRO_CUSTO, :CENTRO_DESPESA, :HISTPADRAO, :COD_OPERACAO, :HISTCOMPL, :COD_INDICE_CONV, :VLR_OPER_IND, :DAT_GRAVACAO, :NUM_LANCAMENTO, :TIPO_LANCTO, :IND_PFJ_EMPRESA, :COD_PFJ_EMPRESA, :COD_SERVICO, :IDENTIF_LANC_RES, :COD_SISTEMA_ORIG, :IDENTIF_SALDO, :DSC_RESERVADO1, :DSC_RESERVADO2, :DSC_RESERVADO3, :DSC_RESERVADO4, :DSC_RESERVADO5, :DSC_RESERVADO6, :DSC_RESERVADO7, :DSC_RESERVADO8, :NUM_PROCESSO, :DAT_LANCTO_EXTEMP, :PST_ID, :COD_EVENTO_DESIF, :COD_ESTADO_ORIG, :COD_MUNIC_ORIG, :NUM_LOTE);

             ");
            return sql.ToString();
        }

        public static string InserirSAFX02()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"
               insert into MSAF.SAFX02 (COD_EMPRESA, COD_ESTAB, COD_CONTA, DATA_SALDO, VLR_SALDO_INI, IND_SALDO_INI, VLR_SALDO_FIM, IND_SALDO_FIM, VLR_TOT_CRE, VLR_TOT_DEB, DAT_GRAVACAO, IDENTIF_SALDO, COD_SISTEMA_ORIG, PST_ID, NUM_LOTE)
               values (:COD_EMPRESA, :COD_ESTAB, :COD_CONTA, :DATA_SALDO, :VLR_SALDO_INI, :IND_SALDO_INI, :VLR_SALDO_FIM, :IND_SALDO_FIM, :VLR_TOT_CRE, :VLR_TOT_DEB, :DAT_GRAVACAO, :IDENTIF_SALDO, :COD_SISTEMA_ORIG, :PST_ID, :NUM_LOTE); 
             ");
            
            return sql.ToString();
        }

        public static string InserirSAFX80()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"
               insert into MSAF.SAFX2001 (COD_EMPRESA, COD_ESTAB, DAT_SALDO, COD_CONTA, COD_CUSTO, VLR_SALDO_CONT_ANT, IND_DEB_CRED_ANT, VLR_TOT_DEB, VLR_TOT_CRED, VLR_SALDO_CONT_ATU, IND_DEB_CRED_ATU, DAT_GRAVACAO, IDENTIF_SALDO, COD_SISTEMA_ORIG, PST_ID, NUM_LOTE)
               values (:COD_EMPRESA, :COD_ESTAB, :DAT_SALDO, :COD_CONTA, :COD_CUSTO, :VLR_SALDO_CONT_ANT, :IND_DEB_CRED_ANT, :VLR_TOT_DEB, :VLR_TOT_CRED, :VLR_SALDO_CONT_ATU, :IND_DEB_CRED_ATU, :DAT_GRAVACAO, :IDENTIF_SALDO, :COD_SISTEMA_ORIG, :PST_ID, :NUM_LOTE);
             ");

            return sql.ToString();
        }

        public static string InserirSAFX2001()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"
               insert into MSAF.SAFX2001 (COD_OPERACAO, DATA_X2001, DESCRICAO, DAT_GRAVACAO, IND_TP_OP, PST_ID, MASC_ARQUIVO, NUM_LOTE)
               values (:COD_OPERACAO, :DATA_X2001, :DESCRICAO, :DAT_GRAVACAO, :IND_TP_OP, :PST_ID, :MASC_ARQUIVO, :NUM_LOTE);
             ");

            return sql.ToString();
        }

        public static string InserirSAFX2002()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"               
                 insert into MSAF.SAFX2002 (COD_CONTA, DATA_X2002, DESCRICAO, IND_CONTA, COD_CONTA_REDUZ, DAT_GRAVACAO, COD_CONTA_SINT, IND_NATUREZA, NIVEL, IND_LANCTO_GLOBAL, SEQ_ARQ, COD_CONTA_ANL_TOT, COD_CONTA_PADRAO, IND_ATO_COTEPE, COD_CUSTO, IND_SITUACAO, IND_CONTA_CONSOLID, PST_ID, DESC_DETALHADA, MASC_ARQUIVO, NUM_LOTE)
                 values (:COD_CONTA, :DATA_X2002, :DESCRICAO, :IND_CONTA, :COD_CONTA_REDUZ, :DAT_GRAVACAO, :COD_CONTA_SINT, :IND_NATUREZA, :NIVEL, :IND_LANCTO_GLOBAL, :SEQ_ARQ, :COD_CONTA_ANL_TOT, :COD_CONTA_PADRAO, :IND_ATO_COTEPE, :COD_CUSTO, IND_SITUACAO, :IND_CONTA_CONSOLID, :PST_ID, :DESC_DETALHADA, :MASC_ARQUIVO, :NUM_LOTE);
             ");

            return sql.ToString();
        }

        public static string InserirSAFX2003()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"
               insert into MSAF.SAFX2001 (COD_CUSTO, DATA_X2003, DESCRICAO, IND_CTRL_INVEST, DAT_GRAVACAO, COD_CUSTO_SPED, PST_ID, MASC_ARQUIVO, NUM_LOTE)
               values (:COD_CUSTO, :DATA_X2003, :DESCRICAO, :IND_CTRL_INVEST, :DAT_GRAVACAO, :COD_CUSTO_SPED, :PST_ID, :MASC_ARQUIVO, :NUM_LOTE);
             ");
            return sql.ToString();
        }

    }
}
