namespace NotDefteri
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            btnEkle = new Button();
            textBox2 = new TextBox();
            listView1 = new ListView();
            btnSil = new Button();
            btnKategoriyeGoreAra = new Button();
            textBox3 = new TextBox();
            btnBasligaGoreAra = new Button();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnGuncelle = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 50);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(790, 337);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(305, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 23);
            textBox1.TabIndex = 4;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.Green;
            btnEkle.ForeColor = SystemColors.ControlText;
            btnEkle.Location = new Point(487, 2);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(176, 42);
            btnEkle.TabIndex = 5;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += button1_Click_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(82, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(147, 23);
            textBox2.TabIndex = 6;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 393);
            listView1.Name = "listView1";
            listView1.Size = new Size(790, 240);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Red;
            btnSil.Location = new Point(808, 578);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(181, 55);
            btnSil.TabIndex = 8;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += button2_Click_1;
            // 
            // btnKategoriyeGoreAra
            // 
            btnKategoriyeGoreAra.Location = new Point(808, 422);
            btnKategoriyeGoreAra.Name = "btnKategoriyeGoreAra";
            btnKategoriyeGoreAra.Size = new Size(181, 23);
            btnKategoriyeGoreAra.TabIndex = 9;
            btnKategoriyeGoreAra.Text = "Kategoriye Göre Ara";
            btnKategoriyeGoreAra.UseVisualStyleBackColor = true;
            btnKategoriyeGoreAra.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(808, 393);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(181, 23);
            textBox3.TabIndex = 10;
            // 
            // btnBasligaGoreAra
            // 
            btnBasligaGoreAra.Location = new Point(808, 529);
            btnBasligaGoreAra.Name = "btnBasligaGoreAra";
            btnBasligaGoreAra.Size = new Size(181, 23);
            btnBasligaGoreAra.TabIndex = 11;
            btnBasligaGoreAra.Text = "Başlığa Göre Ara";
            btnBasligaGoreAra.UseVisualStyleBackColor = true;
            btnBasligaGoreAra.Click += button4_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(808, 500);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(181, 23);
            textBox4.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 13;
            label1.Text = "Not Başlığı";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(248, 15);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 14;
            label2.Text = "Kategori";
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Green;
            btnGuncelle.ForeColor = SystemColors.ControlText;
            btnGuncelle.Location = new Point(669, 2);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(176, 42);
            btnGuncelle.TabIndex = 15;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 645);
            Controls.Add(btnGuncelle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(btnBasligaGoreAra);
            Controls.Add(textBox3);
            Controls.Add(btnKategoriyeGoreAra);
            Controls.Add(btnSil);
            Controls.Add(listView1);
            Controls.Add(textBox2);
            Controls.Add(btnEkle);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button btnEkle;
        private TextBox textBox2;
        private ListView listView1;
        private Button btnSil;
        private Button btnKategoriyeGoreAra;
        private TextBox textBox3;
        private Button btnBasligaGoreAra;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Button btnGuncelle;
    }
}
