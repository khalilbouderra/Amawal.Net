using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Amawal
{
    public partial class Form1 : Form
    {
        #region Declaration
        //public Form1()
        //{
        //    InitializeComponent();
        //}

        Chars Validation(string Text)
        {
            foreach (char item in Search_TXT.Text)
                foreach (char tiitem in tifinagh_chars)
                    if (item == tiitem)
                        return Chars.Tifinagh;
                    else
                        foreach (char aritem in arabic_chars)
                            if (item == aritem)
                                return Chars.Arabic;
            return Chars.None;
        }
        enum Chars
        {
            Tifinagh, Arabic, None
        }

        SQLiteConnection cn = new SQLiteConnection(@"Data Source=C:\Users\Khalil Bouderra\Desktop\Dictionary_0.6.1.db;Version=3;New=False;Compress=True;");
        char[] tifinagh_chars = { 'ⴰ', 'ⵣ', 'ⴻ', 'ⵔ', 'ⵜ', 'ⵢ', 'ⵓ', 'ⵉ', 'ⵄ', 'ⵃ', 'ⵇ', 'ⵙ', 'ⴷ', 'ⴼ', 'ⴳ', 'ⵀ', 'ⵊ', 'ⴽ', 'ⵍ', 'ⵎ', 'ⵡ', 'ⵅ', 'ⵛ', 'ⵖ', 'ⴱ', 'ⵏ' };
        char[] arabic_chars = { 'ض', 'ص', 'ث', 'ق', 'ف', 'غ', 'ع', 'ه', 'خ', 'ح', 'ج', 'د', 'ذ', 'ش', 'س', 'ي', 'ب', 'ل', 'ا', 'ت', 'ن', 'م', 'ك', 'ط', 'ئ', 'ء', 'ؤ', 'ر', 'ل', 'ا', 'ى', 'ة', 'و', 'ز', 'ظ', 'أ', 'إ' };
        string arabic, arabic_meaning, tifinagh_in_arabic, tifinagh;
        TextBox t = new TextBox();
        #endregion

        public Form1()
        {
            InitializeComponent();
            /*
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "Select * from words";
            cmd.Connection = cn;
            DataTable dt = new DataTable();
            cn.Open();
            try
            {
                dt.Load(cmd.ExecuteReader());
            }
            catch (SQLiteException ex) { }
            finally
            {
                cn.Close();
            }

            Search_TXT.AutoCompleteMode = AutoCompleteMode.Suggest;
            Search_TXT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i < dt.Rows.Count; i++)
                col.Add(dt.Rows[i]["arabic"].ToString() + " : " + dt.Rows[i]["tifinagh"].ToString());
            Search_TXT.AutoCompleteCustomSource = col;
            #endregion
            t.Font = new System.Drawing.Font("Tifinaghe-Izuren IRCAM", 50);
            t.Multiline = true;
            t.Height = panel1.Height;
            t.Width = panel1.Width;
            t.ReadOnly = true;
            //t.BorderStyle = BorderStyle.None;
            t.ScrollBars = ScrollBars.Vertical;*/
            //t.Font = new System.Drawing.Font("Tifinaghe-Izuren IRCAM", 50);

            text.ReadOnly = true;
            //t.BorderStyle = BorderStyle.None;
            text.ScrollBars = ScrollBars.Vertical;
            ReDraw();
            ReDraw();
        }

        private void Search_TXT_TextChanged(object sender, EventArgs e)
        {
            /*
                        if (Search_TXT.Text.Length > 0)
                        {
                            string Word = string.Empty, table = string.Empty;
                            Chars val = Validation(Search_TXT.Text);
                            foreach (char item in Search_TXT.Text)
                            {
                                if (item == '\'')
                                    Word += "\\'";
                                else
                                    Word += item;
                            }
                            SQLiteCommand cmd = new SQLiteCommand();
                            if (val == Chars.Tifinagh)
                            {
                                table = "tifinagh";
                                arabic = "ⵜⴰⵄⵔⴰⴱⵜ";
                                arabic_meaning = "ⵜⴰⵄⵔⴰⴱⵜ ⵙ ⵉⵎⵃⴰⵙ";
                                tifinagh_in_arabic = "ⵜⴰⵎⴰⵣⵉⵖⵜ ⵙ ⵜⵉⴼⵉⵏⴰⵖ ⵜⴰⵄⵔⴰⴱⵜ";
                                tifinagh = "ⵜⴰⵎⴰⵣⵉⵖⵜ";
                            }
                            else if (val == Chars.Arabic)
                            {
                                table = "_arabic";
                                arabic = "العربية";
                                arabic_meaning = "العربية بالشكل";
                                tifinagh_in_arabic = "الأمازيغية بحروف عربية";
                                tifinagh = "الأمازيغية";
                            }
                            else
                                return;
                            cmd.CommandText = "Select arabic as [" + arabic + "]," +
                                "arabic_meaning as [" + arabic_meaning + "]," +
                                "tifinagh_in_arabic as [" + tifinagh_in_arabic + "]," +
                                "tifinagh as [" + tifinagh + "] from words where " + table + " like '%" + Word + "%'";
                            cmd.Connection = cn;
                            DataTable dt = new DataTable();
                            cn.Open();
                            try { dt.Load(cmd.ExecuteReader()); }
                            catch (SQLiteException ex) { }
                            finally { cn.Close(); }
                            Result.DataSource = dt;
                            cn.Close();
                        }
                        */
        }



        private void Result_DoubleClick(object sender, EventArgs e)
        {
            //text.Text = "";
            text.Text = Result.SelectedRows[0].Cells[0].Value.ToString() + " ( " +
                Result.SelectedRows[0].Cells[1].Value.ToString() + " ) " + Environment.NewLine +
                Result.SelectedRows[0].Cells[2].Value.ToString();
            /*for (int i = 0; i < Result.SelectedRows[0].Cells.Count; i++)
            {
                if (i == 0)
                    text.Text += Result.SelectedRows[0].Cells[i].Value.ToString();
                else
                    text.Text += " ( " + Result.SelectedRows[0].Cells[i].Value.ToString() + " ) ";
            }*/
            /*panel1.Controls.Clear();
            panel1.Controls.Add(t);
            panel1.Refresh();*/
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ReDraw();
        }
        void ReDraw()
        {
            /*t.Width = panel1.Width;
            panel1.Height = this.Height / 3;
            panel1.Location = new Point(panel1.Location.X, (this.Height / 3) * 2);
            Result.Location = new Point(Result.Location.X, Search_TXT.Location.Y + Search_TXT.Size.Height + 10);
            Result.Size = new Size(this.Width - Result.Location.X - 20, this.Height - (Search_TXT.Location.Y + Search_TXT.Size.Height + 10 + panel1.Height) - 10);
            Search_TXT.Location = new Point(10, 10);
            Search_TXT.Size = new Size(this.Width - Search_TXT.Location.X - 20, Search_TXT.Height);
            panel1.Size = new Size(this.Width - panel1.Location.X - 20, this.Height / 3);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }
        void Search()
        {
            if (Search_TXT.Text.Length > 0)
            {
                string Word = string.Empty;
                List<string> Tables = new List<string> { };
                Chars val = Validation(Search_TXT.Text);
                foreach (char item in Search_TXT.Text)
                {
                    if (item == '\'')
                        Word += "\\'";
                    else
                        Word += item;
                }
                SQLiteCommand cmd = new SQLiteCommand();
                if (val == Chars.Tifinagh)
                {
                    //table = "tifinagh";
                    arabic = "ⵜⴰⵄⵔⴰⴱⵜ";
                    arabic_meaning = "ⵜⴰⵄⵔⴰⴱⵜ ⵙ ⵉⵎⵃⴰⵙⵏ";
                    tifinagh_in_arabic = "ⵜⴰⵎⴰⵣⵉⵖⵜ ⵙ ⵜⵉⴼⵉⵏⴰⵖ ⵜⴰⵄⵔⴰⴱⵜ";
                    tifinagh = "ⵜⴰⵎⴰⵣⵉⵖⵜ";
                    Tables.Add("tifinagh");
                }
                else if (val == Chars.Arabic)
                {
                    //table = "_arabic";
                    arabic = "العربية";
                    arabic_meaning = "العربية بالشكل";
                    tifinagh_in_arabic = "الأمازيغية بحروف عربية";
                    tifinagh = "الأمازيغية";
                    Tables.AddRange(new string[] { "_arabic", "_tifinagh_in_arabic", "arabic", "tifinagh_in_arabic" });
                }
                else
                    return;
                string QueryString = "Select tifinagh as [" + tifinagh + "]," +
                    "tifinagh_in_arabic as [" + tifinagh_in_arabic + "], " +
                    "arabic_meaning as [" + arabic_meaning + "] " +
                    "from words where ";
                for (int i = 0; i < Tables.Count; i++)
                {
                    if (i == 0)
                        QueryString += Tables[i] + " like '%" + Word + "%'";
                    else
                        if (Tables.ToArray()[i].Length > 0)
                            QueryString += " or " + Tables[i] + " like '%" + Word + "%'";
                }
                cmd.CommandText = QueryString;
                cmd.Connection = cn;
                DataTable dt = new DataTable();
                cn.Open();
                try { dt.Load(cmd.ExecuteReader()); }
                catch (SQLiteException ex) { }
                finally { cn.Close(); }
                Result.DataSource = dt;
                cn.Close();
            }
        }

        private void bugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Akal.Awal.Afgan.Yaz");
        }
    }
}
