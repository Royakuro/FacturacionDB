using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionFerreteria
{
    public partial class Print : Form
    {
        List<Receipt> _list;
        string _total, _pago, _cambio, _date;
        public Print(List<Receipt> dataSource, string total, string pago, string cambio, string date)
        {
            InitializeComponent();
            _list = dataSource;
            _total = total;
            _pago = pago;
            _cambio = cambio;
            _date = date;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            receiptBindingSource.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal",_total),
                new Microsoft.Reporting.WinForms.ReportParameter("pPago",_pago),
                new Microsoft.Reporting.WinForms.ReportParameter("pCambio",_cambio),
                new Microsoft.Reporting.WinForms.ReportParameter("pDate",_date)
            };
            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
