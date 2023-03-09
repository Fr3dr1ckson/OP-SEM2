using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabOP_2Sem
{
    public static class MainC
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ITask task = new Task3();
            task.Run();
        }
    }
}