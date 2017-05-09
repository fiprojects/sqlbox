using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace sqlbox.Visualization
{
    public class ColumnChart : VisualizationBase
    {
        public ColumnChart(string name)
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

                        "var chart = new google.visualization.ColumnChart(document.getElementById('gchart'));" +
                        "var options = {width: 600, chartArea: { left: 65, width:'80%', height: '70%' }, bar: { groupWidth: '90%' }, legend: { position: 'none' }};" +
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

            var result = transformedData.Take(8)
                .OrderBy(row => row.Item1)
                .ToList();
            result.Add(new Tuple<string, decimal>("Ostatní", transformedData.Skip(8).Sum(row => row.Item2)));

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