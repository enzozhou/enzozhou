using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Electric
{
    public partial class frm_RecoveryContract_DetailView : Form
    {
        public frm_RecoveryContract_DetailView()
        {
            InitializeComponent();
        }
        private int _id = 0;
        public int ID
        {
            set
            {
                _id = value;
                showUpdate();
            }
        }

        private void showUpdate()
        {
            //Head
            Electric.Model.BS_RecoveryContract_Details _model = new Electric.BLL.BS_RecoveryContract_Details().GetModel(_id);
            txtModel .Text = _model.Model.ToString();
            txtQty.Text = _model.Qty.ToString();
            txtPowerRating.Text = _model.PowerRating.ToString();
            txtUnitPrice.Text = _model.UnitPrice.ToString();
            txtPrice.Text = _model.Price.ToString();
            txtBuyPower.Text = _model.BuyPower.ToString();
            txtSubsidy.Text = _model.Subsidy.ToString();
            txtSumPrice.Text = _model.SumPrice.ToString();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
