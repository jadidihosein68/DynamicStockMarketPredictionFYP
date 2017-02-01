using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel ;
namespace WindowsFormsApplication1
{
    class Export
    {
        public string ExportTweetDB (List<Tweet_Frame> tweets , string address )
        {  
            string message = "" ;    
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            // Create empty workbook
            excel.Workbooks.Add();
            // Create Worksheet from active sheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet = excel.ActiveSheet;
            // I created Application and Worksheet objects before try/catch,
            // so that i can close them in finnaly block.
            // It's IMPORTANT to release these COM objects!!
            try
    {
        // ------------------------------------------------
        // Creation of header cells
        // ------------------------------------------------
        workSheet.Cells[1, "A"] = "Screen Name";
        workSheet.Cells[1, "B"] = "Tweet ID";
        workSheet.Cells[1, "C"] = "Dates";
        workSheet.Cells[1, "D"] = "Tweets";
        // ------------------------------------------------
        // Populate sheet with some real data from "cars" list
        // ------------------------------------------------
        int row = 2; // start row (in row 1 are header cells)
        foreach (Tweet_Frame tweet in tweets)
        {
            workSheet.Cells[row, "A"] = tweet.getScreenName();
            workSheet.Cells[row, "B"] = tweet.getTweetID();
            workSheet.Cells[row, "C"] = tweet.getDate().ToShortDateString();
            workSheet.Cells[row, "D"] = tweet.getTweets(); 
            row++;
        }
        // Apply some predefined styles for data to look nicely :)
        workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);
        // Define filename
        string fileName = @address;
 
        // Save this data as a file
        workSheet.SaveAs(fileName);
 
        // Display SUCCESS message
        message =  string.Format("The file '{0}' is saved successfully!", fileName);
    }
    catch (Exception exception)
    {
        message =  "There was a PROBLEM saving Excel file!\n" ;
    }
    finally
    {
        // Quit Excel application
        excel.Quit();
 
        // Release COM objects (very important!)
        if (excel != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                 
        if (workSheet != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                 
        // Empty variables
        excel = null;
        workSheet = null;
 
        // Force garbage collector cleaning
        GC.Collect();
            }
     return message; 
}

        /*
        public void ReformData(List<Tweet_Frame> temps)
        {
            
            
            for (int i = 0; i < temps.Count; i++)
            {
                string mt = temps[i].getTweets();
                //if (mt[0].Equals('\"'))
                    temps[i].setTweets("Tweet = "+mt );
                    
            }
             
        
        }

        */
    }



    }

