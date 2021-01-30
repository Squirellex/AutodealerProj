using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TemplateEngine.Docx;
using System.Diagnostics;
using System.Windows.Forms;

namespace Autodealer.Classes
{
    public class Documents
    {
        static public void createСonsentProcessingOfPersonalData()
        {
            Form1 form = new Form1();
            List<AOToWorkers> orders = SQLiteDataAccess.loadOrders(form.staffId);
            TableContent tableEvent = new TableContent("ordersTable");

            string currentDate = DateTime.Now.Date.ToString("dd.MM.yyyy");

            int length = orders.Count;
            int sumWhole = 0;

            foreach (AOToWorkers order in orders)
            {
                sumWhole += order.carPrice;
                tableEvent.AddRow(
                    new FieldContent("carMark", order.carMark),
                    new FieldContent("carModel", order.carModel),
                    new FieldContent("carReleaseDate", order.carReleaseDate.ToString()),
                    new FieldContent("carColor", order.carColor),
                    new FieldContent("carPrice", order.carPrice.ToString()),
                    new FieldContent("clientName", order.clientName),
                    new FieldContent("clientSurname", order.clientSurname),
                    new FieldContent("clientMobile", order.clientMobileNumber)
                );
            }

            var valuesToFill = new Content(
                tableEvent,
                new FieldContent("sumWhole", sumWhole.ToString()),
                new FieldContent("Report date", currentDate)
             );

            string destinationFolderPath = @"..\..\Отчеты о заказах";
            string templatePath = @"..\..\Отчеты о заказах\Шаблон\Отчеты о заказах.docx";
            string newFilePath = @"..\..\Отчеты о заказах\Отчеты о заказах\Отчет о заказах " + currentDate + ".docx";

            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }
            if(Process.GetProcessesByName("WINWORD").Length > 0)
            {
                MessageBox.Show("Завершите все процессы MS Word");
            }
            else {
                File.Delete(newFilePath);
                File.Copy(templatePath, newFilePath);
                using (var outputDocument = new TemplateProcessor(newFilePath)
                .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
                Process.Start(newFilePath);
            }
        }
    }
}
