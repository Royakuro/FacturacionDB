﻿using System;
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
    public partial class Form1 : Form
    {
        int order = 1;
        double total = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                Receipt obj = new Receipt() { Id = order++, Producto = txtProductName.Text, Precio = Convert.ToDouble(txtPrice.Text), Cantidad = Convert.ToInt32(txtQuantity.Text) };
                total += obj.Precio * obj.Cantidad;
                receiptBindingSource.Add(obj);
                receiptBindingSource.MoveLast();
                txtProductName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtTotal.Text = string.Format("{0}$", total);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            receiptBindingSource.DataSource = new List<Receipt>();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Receipt obj = receiptBindingSource.Current as Receipt;
            if (obj != null)
            {
                total -= obj.Precio * obj.Cantidad;
                txtTotal.Text = string.Format("{0}$", total);
            }
            receiptBindingSource.RemoveCurrent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (Print frm = new Print(receiptBindingSource.DataSource as List<Receipt>, string.Format("{0}$", total), string.Format("{0}$", txtCash.Text), string.Format("{0:0.00}$", Convert.ToDouble(txtCash.Text) - total), DateTime.Now.ToString("MM/dd/yyyy")))
            {
                frm.ShowDialog();
            }
        }
    }
}
