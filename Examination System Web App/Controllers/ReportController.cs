using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace Examination_System_Web_App.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportRepository reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public IActionResult GenTopicsReport(int? crsId)
        {
            if(crsId == null)
            {
                return BadRequest();
            }
            var data = reportRepository.GetTopicsReport(crsId.Value);
            if (data != null) {
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();

                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 25);
                //Draw the text.
                graphics.DrawString("Topics List", font, PdfBrushes.Black, new PointF(graphics.ClientSize.Width /3, 100));
                // Adding ITI Image 
                FileStream imageStream = new FileStream("wwwroot/images/iti.png", FileMode.Open, FileAccess.Read);
                PdfBitmap image = new PdfBitmap(imageStream);
                //Draw the image
                graphics.DrawImage(image, 0, 0,100,100);

                //Add list to IEnumerable.
                IEnumerable<object> dataTable = data;
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Apply built-in table style
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4);
                for (int i = 0; i < pdfGrid.Rows.Count; i++)
                {
                    pdfGrid.Rows[i].Height = 20;
                }
                // Paginate
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                layoutFormat.Break = PdfLayoutBreakType.FitPage;
                layoutFormat.Layout = PdfLayoutType.Paginate;

                // Format 
                PdfStringFormat stringFormat = new PdfStringFormat();
                stringFormat.Alignment = PdfTextAlignment.Center;
                stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                //Apply string formatting for the whole table.
                for (int i = 0; i < pdfGrid.Columns.Count; i++)
                {
                    pdfGrid.Columns[i].Format = stringFormat;
                }

                // Renaming Table Headers 
                PdfGridRow header = pdfGrid.Headers[0];

                header.Cells[0].Value = "Course Name";
                header.Cells[1].Value = "Topic Name";
               
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 200), layoutFormat);
                //Write the PDF document to stream.
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                //If the position is not set to '0' then the PDF will be empty.
                stream.Position = 0;
                //Close the document.
                doc.Close(true);
                //Defining the ContentType for pdf file.
                string contentType = "application/pdf";
                //Define the file name.
                string fileName = "Topics Report.pdf";
                //Creates a FileContentResult object by using the file contents, content type, and file name.
                return File(stream, contentType, fileName);

            }
            else
            {
                return NotFound();  
            }
        }

        public IActionResult GenStudentPerDeptReport(int? deptNo)
        {
            if (deptNo == null)
            {
                return BadRequest();
            }
            var data = reportRepository.GetStudentPerDeptReport(deptNo.Value);
            if (data != null)
            {
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();

                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 25);
                //Draw the text.
                graphics.DrawString("Student List", font, PdfBrushes.Black, new PointF(graphics.ClientSize.Width / 3, 100));
                // Adding ITI Image 
                FileStream imageStream = new FileStream("wwwroot/images/iti.png", FileMode.Open, FileAccess.Read);
                PdfBitmap image = new PdfBitmap(imageStream);
                //Draw the image
                graphics.DrawImage(image, 0, 0, 100, 100);
                //Add list to IEnumerable.
                IEnumerable<object> dataTable = data;
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Apply built-in table style
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent5);
                for (int i = 0; i < pdfGrid.Rows.Count; i++)
                {
                    pdfGrid.Rows[i].Height = 20;
                }
                // Paginate
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                layoutFormat.Break = PdfLayoutBreakType.FitPage;
                layoutFormat.Layout = PdfLayoutType.Paginate;

                // Format 
                PdfStringFormat stringFormat = new PdfStringFormat();
                stringFormat.Alignment = PdfTextAlignment.Center;
                stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                //Apply string formatting for the whole table.
                for (int i = 0; i < pdfGrid.Columns.Count; i++)
                {
                    pdfGrid.Columns[i].Format = stringFormat;
                }
                pdfGrid.Columns[3].Width = 150;
                // Renaming Table Headers 
                PdfGridRow header = pdfGrid.Headers[0];

                header.Cells[0].Value = "ID";
                header.Cells[1].Value = "First Name";
                header.Cells[2].Value = "Last Name";
                header.Cells[3].Value = "Email";
                header.Cells[4].Value = "Age";
                header.Cells[5].Value = "Gender";
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 200), layoutFormat);
                //Write the PDF document to stream.
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                //If the position is not set to '0' then the PDF will be empty.
                stream.Position = 0;
                //Close the document.
                doc.Close(true);
                //Defining the ContentType for pdf file.
                string contentType = "application/pdf";
                //Define the file name.
                string fileName = "Students Report.pdf";
                //Creates a FileContentResult object by using the file contents, content type, and file name.
                return File(stream, contentType, fileName);

            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult GenCoursesReport()
        {
            int InsID = 1;
            var data = reportRepository.GetCoursesReport( InsID );
            if (data != null)
            {
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();

                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 25);
                //Draw the text.
                graphics.DrawString("Courses Info List", font, PdfBrushes.Black, new PointF(graphics.ClientSize.Width / 5, 100));

                // Adding ITI Image 
                FileStream imageStream = new FileStream("wwwroot/images/iti.png", FileMode.Open, FileAccess.Read);
                PdfBitmap image = new PdfBitmap(imageStream);
                //Draw the image
                graphics.DrawImage(image, 0, 0, 100, 100);

                //Add list to IEnumerable.
                IEnumerable<object> dataTable = data;
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Apply built-in table style
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent5);
                for (int i = 0; i < pdfGrid.Rows.Count; i++)
                {
                    pdfGrid.Rows[i].Height = 20;
                }
                // Paginate
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                layoutFormat.Break = PdfLayoutBreakType.FitPage;
                layoutFormat.Layout = PdfLayoutType.Paginate;

                // Format 
                PdfStringFormat stringFormat = new PdfStringFormat();
                stringFormat.Alignment = PdfTextAlignment.Center;
                stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                //Apply string formatting for the whole table.
                for (int i = 0; i < pdfGrid.Columns.Count; i++)
                {
                    pdfGrid.Columns[i].Format = stringFormat;
                }
                // Renaming Table Headers 
                PdfGridRow header = pdfGrid.Headers[0];

                header.Cells[0].Value = "Course Name";
                header.Cells[1].Value = "Dept Name";
                header.Cells[2].Value = "Number Of Students";


                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 200), layoutFormat);
                //Write the PDF document to stream.
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                //If the position is not set to '0' then the PDF will be empty.
                stream.Position = 0;
                //Close the document.
                doc.Close(true);
                //Defining the ContentType for pdf file.
                string contentType = "application/pdf";
                //Define the file name.
                string fileName = "Courses Report.pdf";
                //Creates a FileContentResult object by using the file contents, content type, and file name.
                return File(stream, contentType, fileName);

            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult GenStdGrades(int? stdId)
        {
            if (stdId == null)
            {
                return BadRequest();
            }
            var data = reportRepository.GetStdGrades(stdId.Value);
            if (data != null)
            {
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();

                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 25);
                //Draw the text.
                graphics.DrawString("Grades List", font, PdfBrushes.Black, new PointF(graphics.ClientSize.Width / 3, 100));
                // Adding ITI Image 
                FileStream imageStream = new FileStream("wwwroot/images/iti.png", FileMode.Open, FileAccess.Read);
                PdfBitmap image = new PdfBitmap(imageStream);
                //Draw the image
                graphics.DrawImage(image, 0, 0, 100, 100);
                //Add list to IEnumerable.
                IEnumerable<object> dataTable = data;
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Apply built-in table style
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4);
                for (int i = 0; i < pdfGrid.Rows.Count; i++)
                {
                    pdfGrid.Rows[i].Height = 20;
                }
                // Paginate
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                layoutFormat.Break = PdfLayoutBreakType.FitPage;
                layoutFormat.Layout = PdfLayoutType.Paginate;

                // Format 
                PdfStringFormat stringFormat = new PdfStringFormat();
                stringFormat.Alignment = PdfTextAlignment.Center;
                stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                //Apply string formatting for the whole table.
                for (int i = 0; i < pdfGrid.Columns.Count; i++)
                {
                    pdfGrid.Columns[i].Format = stringFormat;
                }
                
                // Renaming Table Headers 
                PdfGridRow header = pdfGrid.Headers[0];

                header.Cells[0].Value = "Course Name";
                header.Cells[1].Value = "Grade %";
   
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 200), layoutFormat);
                //Write the PDF document to stream.
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                //If the position is not set to '0' then the PDF will be empty.
                stream.Position = 0;
                //Close the document.
                doc.Close(true);
                //Defining the ContentType for pdf file.
                string contentType = "application/pdf";
                //Define the file name.
                string fileName = "Student Grades Report.pdf";
                //Creates a FileContentResult object by using the file contents, content type, and file name.
                return File(stream, contentType, fileName);

            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult GenAsnwerReport(int stdid, int past_id)
        {
            var data = reportRepository.GetAsnwer(stdid, past_id);
            if (data != null)
            {
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();

                PdfGraphics graphics = page.Graphics;
                //Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 25);
                //Draw the text.
                graphics.DrawString("Courses Info List", font, PdfBrushes.Black, new PointF(graphics.ClientSize.Width / 5, 100));

                // Adding ITI Image 
                FileStream imageStream = new FileStream("wwwroot/images/iti.png", FileMode.Open, FileAccess.Read);
                PdfBitmap image = new PdfBitmap(imageStream);
                //Draw the image
                graphics.DrawImage(image, 0, 0, 100, 100);

                //Add list to IEnumerable.
                IEnumerable<object> dataTable = data;
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Apply built-in table style1
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent5);
                for (int i = 0; i < pdfGrid.Rows.Count; i++)
                {
                    pdfGrid.Rows[i].Height = 20;
                }
                // Paginate
                PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
                layoutFormat.Break = PdfLayoutBreakType.FitPage;
                layoutFormat.Layout = PdfLayoutType.Paginate;

                // Format 
                PdfStringFormat stringFormat = new PdfStringFormat();
                stringFormat.Alignment = PdfTextAlignment.Center;
                stringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                //Apply string formatting for the whole table.
                for (int i = 0; i < pdfGrid.Columns.Count; i++)
                {
                    pdfGrid.Columns[i].Format = stringFormat;
                }
                // Renaming Table Headers 
                PdfGridRow header = pdfGrid.Headers[0];

                header.Cells[0].Value = "Question Text";
                header.Cells[1].Value = "Student Answer";
                header.Cells[2].Value = "Model Answer";


                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 200), layoutFormat);
                //Write the PDF document to stream.
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);
                //If the position is not set to '0' then the PDF will be empty.
                stream.Position = 0;
                //Close the document.
                doc.Close(true);
                //Defining the ContentType for pdf file.
                string contentType = "application/pdf";
                //Define the file name.
                string fileName = "Courses Report.pdf";
                //Creates a FileContentResult object by using the file contents, content type, and file name.
                return File(stream, contentType, fileName);

            }
            else
            {
                return NotFound();
            }
        }


    }
}
