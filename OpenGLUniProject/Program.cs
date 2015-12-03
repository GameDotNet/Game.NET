using System;
using OpenGLUniProject.Core;

namespace OpenGLUniProject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var instance = new Engine(args))
            {
                instance.Run();
            }
        }
    }
}
