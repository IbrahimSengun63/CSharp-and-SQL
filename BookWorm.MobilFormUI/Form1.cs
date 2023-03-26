using BookWorm.Business.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookWorm.Business.DependencyResolvers.Ninject;
using BookWorm.Entities.Concrete;

namespace BookWorm.MobilFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _bookService = InstanceFactory.GetInstance<IBookService>();
            _bookTypeService = InstanceFactory.GetInstance<IBookTypeService>();

        }

        private IBookService _bookService;
        private IBookTypeService _bookTypeService;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();

            LoadBookTypes();
        }

        private void LoadBookTypes()
        {
            
            
            cbxCategoryName.DataSource = _bookTypeService.GetAll();
            cbxCategoryName.DisplayMember = "KategoriTürü";
            cbxCategoryName.ValueMember = "KategoriNumarası";


            cbxCategoryNameAdd.DataSource = _bookTypeService.GetAll();
            cbxCategoryNameAdd.DisplayMember = "KategoriTürü";
            cbxCategoryNameAdd.ValueMember = "KategoriNumarası";

            cbxCategoryUpdate.DataSource = _bookTypeService.GetAll();
            cbxCategoryUpdate.DisplayMember = "KategoriTürü";
            cbxCategoryUpdate.ValueMember = "KategoriNumarası";

        }

        private void LoadBooks()
        {
            dgwBook.DataSource = _bookService.GetAll();
        }

        private void CbxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwBook.DataSource = _bookService.GetBooksByCategory(Convert.ToInt32(cbxCategoryName.SelectedValue));
            }
            catch
            {

            }
        }

        private void TbxBookName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxBookName.Text))
            {
                dgwBook.DataSource = _bookService.GetBooksByBooksName(tbxBookName.Text);
            }
            else
            {
                LoadBooks();
            }

        }

        private void BtnBookAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tbxPublisherAdd.Text))
                {
                    tbxPublisherAdd.Text = "Belirtilmedi";
                }

                if (String.IsNullOrWhiteSpace(tbxAuthorAdd.Text))
                {
                    tbxAuthorAdd.Text = "Belirtilmedi";
                }

                if (String.IsNullOrWhiteSpace(tbxInterpreterAdd.Text))
                {
                    tbxInterpreterAdd.Text = "Belirtilmedi";
                }

                if (String.IsNullOrWhiteSpace(tbxBorrowerAdd.Text))
                {
                    tbxBorrowerAdd.Text = "Yok";
                }

                if (String.IsNullOrWhiteSpace(tbxBookNameAdd.Text))
                {
                    tbxBookNameAdd.Text = "Belirtilmedi";
                }



                _bookService.Add(new Book
                {
                    KategoriNumarası = Convert.ToInt32(cbxCategoryNameAdd.SelectedValue),
                    KitapAdı = tbxBookNameAdd.Text,
                    Yazar = tbxAuthorAdd.Text,
                    BaskıYılı = (short)tbxPrintingYearAdd.TextLength,
                    YayınEvi = tbxPublisherAdd.Text,
                    Çevirmen = tbxInterpreterAdd.Text,
                    ÖdünçDurumu = cbxLoanStatus.Checked,
                    ÖdünçAlanKişi = tbxBorrowerAdd.Text
                });
                MessageBox.Show("Kitap Eklendi!");
                LoadBooks();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtnBookUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _bookService.Update(new Book
                {
                    KitapNumarası = Convert.ToInt32(dgwBook.CurrentRow.Cells[0].Value),
                    KitapAdı = tbxBookNameUpdate.Text,
                    Yazar = tbxAuthorUpdate.Text,
                    KategoriNumarası = Convert.ToInt32(cbxCategoryUpdate.SelectedValue),
                    ÖdünçDurumu = cbxLoanStatusUpdate.Checked,
                    ÖdünçAlanKişi = tbxBorrowerUpdate.Text,
                    Çevirmen = tbxInterpreterUpdate.Text,
                    YayınEvi = tbxPublisherUpdate.Text,
                    BaskıYılı = (short)tbxPrintingYearAdd.TextLength
                });
                MessageBox.Show("Kitap Güncellendi!");
                LoadBooks();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DgwBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var row = dgwBook.CurrentRow;

            tbxBookNameUpdate.Text = row.Cells[2].Value.ToString();
            cbxCategoryUpdate.SelectedValue = row.Cells[1].Value;
            tbxAuthorUpdate.Text = row.Cells[3].Value.ToString();
            tbxInterpreterUpdate.Text = row.Cells[4].Value.ToString();
            tbxPublisherUpdate.Text = row.Cells[5].Value.ToString();
            tbxPrintingYearUpdate.Text = row.Cells[6].Value.ToString();
            cbxLoanStatusUpdate.Checked = row.Cells[7].Selected;
            tbxBorrowerUpdate.Text = row.Cells[8].Value.ToString();

        }

        private void BtnBookRemove_Click(object sender, EventArgs e)
        {

            if (dgwBook.CurrentRow != null)
            {
                try
                {
                    _bookService.Delete(new Book
                    {
                        KitapNumarası = Convert.ToInt32(dgwBook.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Kitap Silindi!");
                    LoadBooks();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void TbxAuthorSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxAuthorSearch.Text))
            {
                dgwBook.DataSource = _bookService.GetBooksByAuthorName(tbxAuthorSearch.Text);
            }
            else
            {
                LoadBooks();
            }
        }

       
    }
}
