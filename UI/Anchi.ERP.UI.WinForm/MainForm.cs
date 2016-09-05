using Anchi.ERP.UI.WinForm.Customers;
using Anchi.ERP.UI.WinForm.Products;
using Anchi.ERP.UI.WinForm.Purchases;
using Anchi.ERP.UI.WinForm.RepairItems;
using Anchi.ERP.UI.WinForm.Repairs;
using Anchi.ERP.UI.WinForm.Users;
using System;
using System.Windows.Forms;

namespace Anchi.ERP.UI.WinForm
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void menuAddRepair_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(EditRepairForm));
        }

        private void menuRepairList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(RepairListForm));
        }

        private void menuAddPurchase_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(EditPurchaseForm));
        }

        private void menuPurchaseList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(PurchaseListForm));
        }

        private void menuCustomerList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(CustomerListForm));
        }

        private void menuSupplierList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(CustomerListForm));
        }

        private void menuRepairItemList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(CustomerListForm));
        }

        private void menuUserList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(UserListForm));
        }

        private void menuItemList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(ItemListForm));
        }

        private void menuPartList_Click(object sender, EventArgs e)
        {
            ShowSingleWindow(typeof(ProductListForm));
        }

        private void menuAbountMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About");
        }
    }
}
