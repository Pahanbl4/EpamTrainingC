using MVCproject.Controllers;
using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Collections;
using Modell;

namespace MVCproject.Areas.Admin.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: Admin/Statistics
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult ChartColumn()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            var result = (from c in _context.SaleInfo select c);

            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));

            new Chart(width: 600, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart for Growth [column chart]")
                .AddSeries("Default", chartType: "Column", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartBar()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            var result = (from c in _context.SaleInfo select c);

            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));

            new Chart(width: 600, height: 400, theme: ChartTheme.Yellow)
                .AddTitle("Chart for Growth [Bar chart]")
                .AddSeries("Default", chartType: "Bar", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartPie()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            var result = (from c in _context.SaleInfo select c);

            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));

            new Chart(width: 600, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart for Growth [Pie chart]")
                .AddSeries("Default", chartType: "Pie", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartThree()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            var result = (from c in _context.SaleInfo select c);

            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Chart for Growth [Three Line chart]")
                .AddSeries("Default", chartType: "Candlestick", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartBubble()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            var result = (from c in _context.SaleInfo select c);

            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("Chart for Growth [Bubble chart]")
                .AddSeries("Default", chartType: "Bubble", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartDoughnut()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            var result = (from c in _context.SaleInfo select c);

            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)
                .AddTitle("Chart for Growth [Doughnut chart]")
                .AddSeries("Default", chartType: "Doughnut", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }

        public ActionResult ChartRadar()
        {
            var _context = new ModelDataEntities2();
            ArrayList xxx = new ArrayList();
            ArrayList yyy = new ArrayList();
            
            var result = (from c in _context.SaleInfo select c);
            
            result.ToList().ForEach(rs => xxx.Add(rs.Dato));
            result.ToList().ForEach(rs => yyy.Add(rs.Sum));
      

            new Chart(width: 600, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart for Growth [Radar chart]")
                .AddSeries("Default", chartType: "Radar",legend:"Name", xValue: xxx, yValues: yyy)
                .Write("bmp");

            return null;
        }
    }
}