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
            listView1.Columns.Add("Ba�l�k", 150);
            listView1.Columns.Add("��erik", 250);
            listView1.Columns.Add("Olu�turulma", 140);
            listView1.Columns.Add("G�ncellenme", 140);
        }

        private void LoadListView()
        {
            listView1.Items.Clear();

            // NotServices �rne�inizi daha �nce olu�turmu�tunuz:
            // private readonly NotServices _notService;
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
        private void button1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Yeni not olu�turma verileri
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
                // E�er ayn� ba�l�k zaten varsa servis bir Exception f�rlatacak
                notService.YeniNotOlustur(not, kategoriName);

                // Ba�ar�l�ysa listeyi yenile ve kullan�c�ya bilgi ver
                LoadListView();
                MessageBox.Show($"\"{not.Header}\" ba�l�kl� not eklendi.",
                                "Ba�ar�l�",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (ArgumentException argEx)
            {
                // Kategori ad� bo� gelirse
                MessageBox.Show(argEx.Message,
                                "Ge�ersiz Giri�",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Duplicate header veya ba�ka bir hata
                MessageBox.Show(ex.Message,
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


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
                // Kategoriye ait notlar� al
                var notes = notService.Ara(kategoriName);

                // ListView'i temizle ve yenilerini ekle
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
                // Kategori bulunamad���nda veya ba�ka bir hatada uyar� ver
                MessageBox.Show(
                    $"\"{kategoriName}\" kategorisi bulunamad�.\nDetay: {ex.Message}",
                    "Uyar�",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

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
                // Kategoriye ait notlar� al
                var notes = notService.BasligaGoreAra(headerName);

                // ListView'i temizle ve yenilerini ekle
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
                // Kategori bulunamad���nda veya ba�ka bir hatada uyar� ver
                MessageBox.Show(
                    $"\"{headerName}\" kategorisi bulunamad�.\nDetay: {ex.Message}",
                    "Uyar�",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            // Se�ili ��e yoksa uyar
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Silmek i�in bir not se�melisiniz.", "Uyar�",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se�ilen ilk ��eyi al
            var item = listView1.SelectedItems[0];
            var kategoriName = item.Text;                  // 1. s�tun = kategori
            var notHeader = item.SubItems[1].Text;       // 2. s�tun = ba�l�k

            // Silme i�lemi
            try
            {
                notService.NotSil(notHeader, kategoriName);
                MessageBox.Show($"\"{notHeader}\" ba�l�kl� not silindi.",
                                "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yeniden y�kle
                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme s�ras�nda bir hata olu�tu:\n{ex.Message}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Se�ili ��e kontrol�
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("L�tfen �nce bir not se�in.", "Uyar�",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni de�erleri al
            var newCategory = textBox1.Text.Trim();
            var newHeader = textBox2.Text.Trim();
            var newContent = richTextBox1.Text;

            try
            {
                // Silme + yeniden ekleme yerine do�rudan g�ncelleme
                notService.GuncelleNot(
                    kategoriName: _originalCategory,
                    originalHeader: _originalHeader,
                    newHeader: newHeader,
                    newContent: newContent
                );

                // G�r�n�m� yenile
                LoadListView();
                MessageBox.Show("Not ba�ar�yla g�ncellendi.", "Ba�ar�l�",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Orijinalleri temizle
                _originalCategory = null;
                _originalHeader = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"G�ncelleme s�ras�nda hata olu�tu:\n{ex.Message}", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
