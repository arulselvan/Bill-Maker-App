using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //string DownloadFilePath = @"C:\sudhakar\websites\1.txt";

            ////Code for Print the PDF file
            //Process P = new Process();
            //P.StartInfo.FileName = DownloadFilePath; // FileName(.pdf) to print.
            //P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //Hide the window.                        
            //P.StartInfo.Verb = "Print";
            //PrintDialog pd = new PrintDialog();
            ////PrinterSettings setting = new PrinterSettings();           

            //P.StartInfo.Arguments = pd.PrinterSettings.PrinterName.ToString();
            //pd.PrinterSettings.MaximumPage = 1;
            //P.StartInfo.CreateNoWindow = true; //!! Don't create a Window.    
            //P.Start();
            //P.CloseMainWindow();

            PrintDocument prnDocument;
            string printername;
            //Get the default printer name.
            prnDocument = new PrintDocument();
            PaperSize psize = new PaperSize(PaperKind.Custom.ToString(), 300, 200);
            printername = Convert.ToString(prnDocument.PrinterSettings.PrinterName);

            if (string.IsNullOrEmpty(printername))
                throw new Exception("No default printer is set.Printing failed!");
            prnData = "TEST";
            prnDocument.PrintPage += new PrintPageEventHandler(prnDoc_PrintPage);
            prnDocument.Print();

        }
        static string prnData = string.Empty;

        static void prnDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //StringFormat st = new StringFormat();
            //st.Alignment = StringAlignment.Center;
            Font fnt = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold | FontStyle.Underline);
            e.Graphics.DrawString(prnData, fnt, Brushes.Black, 0, 0);
        }
    }
}
