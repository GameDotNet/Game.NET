using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace Game.NET
{
    public class ShaderFactory
    {
        public ShaderProgram CreateProgramFromFiles(string name, ICollection<ShaderFileInfo> shaders)
        {
            try
            {
                List<Shader> compiledShaders = shaders.Select(shader => CreateShaderFromFile(shader.Type, shader.Name, shader.Filename)).ToList();

                ShaderProgram program = new ShaderProgram();
                program.Compile(compiledShaders);

                ResourceManager.Insert(name, program);

                return program;
            }
            catch (System.Exception e)
            {
                ResourceManager.CleanAll();
                throw new ShaderCompilationErrorException(e);
            }
        }

        private Shader CreateShaderFromSource(ShaderType type, string name, string source)
        {
            Shader shader = new Shader(type, "");

            shader.Source = source;
            shader.Compile();

            ResourceManager.Insert(name, shader);

            return shader;
        }

        private Shader CreateShaderFromFile(ShaderType type, string name, string filename)
        {
            Shader shader = new Shader(type, filename);

            shader.Source = File.ReadAllText(filename);
            shader.Compile();
            
            ResourceManager.Insert(name, shader);

            return shader;
        }
    }
}
