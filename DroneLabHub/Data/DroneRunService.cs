using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace DroneLabHub.Data
{
    public class DroneRunService
    {
        public List<DroneRun> GetDroneRuns()
        {
            List<DroneRun> runList = new List<DroneRun>();
            //IEnumerable<DroneRun> runEnumberable;

            using (var reader = new StreamReader("/app/dronelab/meta_run.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<DroneRun>();
                foreach (var record in records)
                {
                    if (record != null)
                    {
                        runList.Add(record);
                    }
                }
            }
            return runList;
        }

        public void HoughTransform()
        {

            ScriptEngine engine = Python.CreateEngine();

            // Print the default search paths
            System.Console.Out.WriteLine("Search paths:");
            ICollection<string> searchPaths = engine.GetSearchPaths();
            foreach (string path in searchPaths)
            {
                Console.WriteLine(path);
            }
            System.Console.Out.WriteLine();

            // Now modify the search paths to include the directory
            // where the standard library has been installed
            searchPaths.Add("/dronelab/python/lib");
            engine.SetSearchPaths(searchPaths);

            var x = engine.ExecuteFile(@"/app/dronelab/python/test.py");
            Console.WriteLine("Executed Python Script");

            //ScriptEngine m_engine = Python.CreateEngine();
            //ScriptScope m_scope = m_engine.CreateScope();
            //String code = @"file = open('TEST.txt', 'w+')";
            //ScriptSource source = m_engine.CreateScriptSourceFromString(code, SourceCodeKind.SingleStatement);
            //source.Execute(m_scope);
        }
    }



}
