using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Syncfusion.Grouping;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.XlsIO;
using Syncfusion.Pdf;


namespace DangNhap
{
    internal class Export
    {
        public void ToExcel(DataTable dataTable, string sheetName, string title)
        {
            // Create Excel object
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            // Create new Excel WorkBook
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            // Create title
            string headerRange = "A1:" + Convert.ToChar(65 + dataTable.Columns.Count - 1) + "1";
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range(headerRange);
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Create column name
            string[] headers = dataTable.Columns.Cast<DataColumn>().Select(col => col.ColumnName).ToArray();
            for (int i = 0; i < headers.Length; i++)
            {
                Microsoft.Office.Interop.Excel.Range cl = oSheet.Cells[3, i + 1];
                cl.Value2 = headers[i];
                cl.Font.Bold = true;
                cl.Font.Name = "Times New Roman";
                cl.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }

            // Setting background color, draw border for column names
            string rowRange = "A3:" + Convert.ToChar(65 + dataTable.Columns.Count - 1) + "3";
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range(rowRange);
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Transfer data from DataTable to object array
            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            // Setting field fills in data
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int columnEnd = dataTable.Columns.Count;

            // the begin cell to fill with data
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // the end cell to fill with data
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Get the data fill area
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            // Fill in the data in the established area
            range.Value2 = arr;

            // Draw border for data cells, center the table and auto fit columns
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.Columns.AutoFit();
        }
        public void ToPDF(DataTable dataTable, string path, string title)
        {
            // Create a document with landscape orientation
            Document document = new Document(PageSize.A4.Rotate());

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();

            // Create font
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont);

            // Create a font for the title (larger size and bold)
            Font titleFont = new Font(baseFont, 20, Font.BOLD);

            // Create a paragraph with the title
            Paragraph titleParagraph = new Paragraph(title, titleFont)
            {
                // Set alignment to center
                Alignment = iTextSharp.text.Element.ALIGN_CENTER,

                // Add some space between title and table
                SpacingAfter = 10f
            };

            // Add the paragraph to the document
            document.Add(titleParagraph);

            // Create table
            PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);

            // Add headers
            foreach (DataColumn column in dataTable.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, font));
                pdfTable.AddCell(cell);
            }

            // Add data rows
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (object cellValue in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(cellValue.ToString(), font));
                    pdfTable.AddCell(cell);
                }
            }

            document.Add(pdfTable);
            document.Close();
        }
    }
}