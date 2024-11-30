using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace HuskyBrowser.WorkingWithBrowserProperties.BookMarksManager
{
    public partial class BookMarkForm : MaterialForm
    {
        public MaterialTabControl _tabControl { set; get; }
        static Color Page_BackColor { get; set; } = MainForm._BackColor;
        private MainForm _form;
        public BookMarkForm(MainForm form)
        {
            InitializeComponent();

            dataGridView1.BackgroundColor = Page_BackColor;    
            ForeColor = MainForm._ForeColor;

            var _fM = new FileManager();
            string path = _fM._GetPathToFile("bookmarks.json", "bookmarks");

            Dictionary<string, BookMarksManager.BookMark> bookMarks_Dict = new Dictionary<string, BookMarksManager.BookMark>();
            string json = _fM._ReadFileText(path);

            if (!string.IsNullOrEmpty(json))
            {
                bookMarks_Dict = JsonSerializer.Deserialize<Dictionary<string, BookMarksManager.BookMark>>(json);
            }

            foreach(var bookmarkey in bookMarks_Dict.Keys) 
            {
                dataGridView1.Rows.Add($"{bookMarks_Dict[bookmarkey].Title}", $"{bookMarks_Dict[bookmarkey].URL}");
            }
            _form = form;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                     
            var url = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            var title = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString();                       
                        
            if (url.StartsWith("https://") || url.StartsWith("http://"))
            {
                var _fM = new FileManager();
                string path = _fM._GetPathToFile("bookmarks.json", "bookmarks");
                string json = _fM._ReadFileText(path);
                Dictionary<string, BookMarksManager.BookMark> bookMarks_Dict = JsonSerializer.Deserialize<Dictionary<string, BookMarksManager.BookMark>>(json);

                List<Image> icons = new List<Image>();
                for (short i = 0; i < imageList1.Images.Count; i++)
                {
                   icons.Add(imageList1.Images[i]);
                }
                List<Image> markbutton_icons = new List<Image>();
                for (short i = 0; i < imageList2.Images.Count; i++)
                {
                   markbutton_icons.Add(imageList2.Images[i]);
                }
                PagePattern.SimplePagePattern simplePagePattern = new PagePattern.SimplePagePattern(icons, markbutton_icons, _tabControl, url, title);
                _form.Text = title;
            }
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }        
    }
}
