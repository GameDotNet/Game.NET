using System;

namespace Game.NET.Model
{
    class Material : Resource
    {
        private bool _isDisposed;

        public override void Dispose()
        {
            CleanUp();
            GC.SuppressFinalize(this);
        }

        private void CleanUp()
        {
            if (_isDisposed)
                return;

            // do clean up

            _isDisposed = true;
        }

        ~Material()
        {
            CleanUp();
        }
    }
}
