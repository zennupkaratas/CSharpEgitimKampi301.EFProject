using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

       public void btnAdd_Click(object sender, EventArgs e)
        {

            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarılı bir şekilde eklendi.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            var removeValue = db.Guide.Find(Id);
            db.Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Başarılı bir şekilde silinmiştir.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            var updateValue = db.Guide.Find(Id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            var values = db.Guide.Where(x =>x.GuideId==Id).ToList();
            dataGridView1.DataSource = values;
          
        }
    }
}
