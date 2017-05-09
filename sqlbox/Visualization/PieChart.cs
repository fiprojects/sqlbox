using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace sqlbox.Visualization
{
    public class PieChart : VisualizationBase
    {
        public PieChart(string name)
        {
            Name = name;
        }

        public override string GetHtml(List<List<object>> data)
        {
            var rows = GetRows(TransformData(data));

            return
                "<script type=\"text/javascript\">" +
                    "google.charts.load('current', { packages: ['corechart']});" +
                    "google.charts.setOnLoadCallback(drawChart);" +

                    "function drawChart() {" +
                        "var data = new google.visualization.DataTable();" +
                        "data.addColumn('string', 'Element');" +
                        "data.addColumn('number', 'Počet');" +
                        "data.addRows([" + rows + "]);" +

                        "var chart = new google.visualization.PieChart(document.getElementById('gchart'));" +
                        "var options = {width: 500, chartArea: { width:'90%', height: '90%' }};" +
                        "chart.draw(data, options);" +
                    "}" +
                "</script>" +
                "<div id=\"gchart\" />";
        }

        protected List<Tuple<string, decimal>> TransformData(List<List<object>> data)
        {
            var transformedData = data
                .Select(row => new Tuple<string, decimal>(row[0].ToString(), decimal.Parse(row[1].ToString())))
                .OrderByDescending(row => row.Item2)
                .ToList();

            var result = transformedData.Take(5)
                .OrderBy(row => row.Item1)
                .ToList();
            result.Add(new Tuple<string, decimal>("Ostatní", transformedData.Skip(5).Sum(row => row.Item2)));

            return result;
        }

        protected string GetRows(List<Tuple<string, decimal>> data)
        {
            var stringBuilder = new StringBuilder();
            foreach (var row in data)
            {
                stringBuilder.AppendLine($"['{row.Item1}', {Math.Round(row.Item2, 2).ToString(CultureInfo.InvariantCulture)}],");
            }
            return stringBuilder.ToString();
        }
    }
}