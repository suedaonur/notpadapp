using NotDefteri.Models;
using NotDefteri.Services;

namespace NotDefteri
{
    public partial class Form1 : Form
    {
        private NotServices notService;

        public Form1()
        {
            InitializeComponent();
            notService = new NotServices();

            SetupListView();
            LoadListView();
        }
        private void SetupListView()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Kategori", 120);
            listView1.Columns.Add("Baþlýk", 150);
            listView1.Columns.Add("Ýçerik", 250);
            listView1.Columns.Add("Oluþturulma", 140);
            listView1.Columns.Add("Güncellenme", 140);
        }

        private void LoadListView()
        {
            listView1.Items.Clear();

           
            foreach (var kategori in notService.GetAllCategories())
            {
                foreach (var not in kategori.Notlar)
                {
                    var item = new ListViewItem(kategori.CategoryName);
                    item.SubItems.Add(not.Header);
                    item.SubItems.Add(not.Content);
                    item.SubItems.Add(not.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(not.LastUpdatedAt.ToString("yyyy-MM-dd HH:mm"));
                    listView1.Items.Add(item);
                }
            }
        }
        private string _originalHeader;
        private string _originalCategory;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var item = listView1.SelectedItems[0];
            _originalCategory = item.SubItems[0].Text;
            _originalHeader = item.SubItems[1].Text;

            textBox1.Text = _originalCategory;
            textBox2.Text = _originalHeader;
            richTextBox1.Text = item.SubItems[2].Text;
        }

        // Ekleme Butonu
        private void button1_Click_1(object sender, EventArgs e)
        {
            var not = new Not
            {
                Header = textBox2.Text.Trim(),
                Content = richTextBox1.Text,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now
            };
            var kategoriName = textBox1.Text.Trim();

            try
            {
                notService.YeniNotOlustur(not, kategoriName);

                LoadListView();
                MessageBox.Show($"\"{not.Header}\" baþlýklý not eklendi.",
                                "Baþarýlý",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message,
                                "Geçersiz Giriþ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Kategoriye göre ara
        private void button3_Click(object sender, EventArgs e)
        {
            var kategoriName = textBox3.Text.Trim();
            if (string.IsNullOrWhiteSpace(kategoriName))
            {
                LoadListView();
                return;
            }

            try
            {
                var notes = notService.Ara(kategoriName);

                listView1.Items.Clear();
                foreach (var not in notes)
                {
                    var item = new ListViewItem(kategoriName);
                    item.SubItems.Add(not.Header);
                    item.SubItems.Add(not.Content);
                    item.SubItems.Add(not.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(not.LastUpdatedAt.ToString("yyyy-MM-dd HH:mm"));
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"\"{kategoriName}\" kategorisi bulunamadý.\nDetay: {ex.Message}",
                    "Uyarý",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        //Basliða göre ara
        private void button4_Click(object sender, EventArgs e)
        {
            var headerName = textBox4.Text.Trim();
            if (string.IsNullOrWhiteSpace(headerName))
            {
                LoadListView();
                return;
            }

            try
            {
                var notes = notService.BasligaGoreAra(headerName);

                listView1.Items.Clear();
                foreach (var not in notes)
                {
                    var item = new ListViewItem(headerName);
                    item.SubItems.Add(not.Header);
                    item.SubItems.Add(not.Content);
                    item.SubItems.Add(not.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(not.LastUpdatedAt.ToString("yyyy-MM-dd HH:mm"));
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"\"{headerName}\" kategorisi bulunamadý.\nDetay: {ex.Message}",
                    "Uyarý",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        //Sil 
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Silmek için bir not seçmelisiniz.", "Uyarý",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var item = listView1.SelectedItems[0];
            var kategoriName = item.Text;                 
            var notHeader = item.SubItems[1].Text;       

            try
            {
                notService.NotSil(notHeader, kategoriName);
                MessageBox.Show($"\"{notHeader}\" baþlýklý not silindi.",
                                "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sýrasýnda bir hata oluþtu:\n{ex.Message}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Guncelle
        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen önce bir not seçin.", "Uyarý",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCategory = textBox1.Text.Trim();
            var newHeader = textBox2.Text.Trim();
            var newContent = richTextBox1.Text;

            try
            {
                notService.GuncelleNot(
                    kategoriName: _originalCategory,
                    originalHeader: _originalHeader,
                    newHeader: newHeader,
                    newContent: newContent
                );

                LoadListView();
                MessageBox.Show("Not baþarýyla güncellendi.", "Baþarýlý",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                _originalCategory = null;
                _originalHeader = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sýrasýnda hata oluþtu:\n{ex.Message}", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
