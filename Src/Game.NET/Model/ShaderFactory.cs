using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace Game.NET
{
    public class ShaderFactory
    {
        private readonly IResourceManager _resourceManager;

        public ShaderFactory() : this(new ResourceManager())
        {
            
        }

        internal ShaderFactory(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public ShaderProgram CreateProgramFromFiles(string name, ICollection<ShaderFileInfo> shaders)
        {
            try
            {
                Shader[] compiledShaders = shaders.Select(shader => CreateShaderFromFile(shader.Type, shader.Name, shader.Filename)).ToArray();

                ShaderProgram program = new ShaderProgram();
                program.Compile(compiledShaders);

                _resourceManager.Insert(name, program);

                return program;
            }
            catch (System.Exception e)
            {
                _resourceManager.CleanAll();
                throw new ShaderCompilationErrorException(e);
            }
        }

        private Shader CreateShaderFromSource(ShaderType type, string name, string source)
        {
            Shader shader = new Shader(type, "");

            shader.Source = source;
            shader.Compile();

            _resourceManager.Insert(name, shader);

            return shader;
        }

        private Shader CreateShaderFromFile(ShaderType type, string name, string filename)
        {
            Shader shader = new Shader(type, filename);

            shader.Source = File.ReadAllText(filename);
            shader.Compile();

            _resourceManager.Insert(name, shader);

            return shader;
        }
    }
}
