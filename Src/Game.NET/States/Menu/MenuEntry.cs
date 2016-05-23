using OpenTK.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace Game.NET.States
{
    public class MenuEntry
    {
        public string Title;
        public Menu.EntryAction Action;

        public virtual void ProcessInput()
        {
            if (Input.GetButton(Input.Button.Use).IsDown && Action != null)
                Action(this);
        }

        public virtual void Draw(Renderer renderer, Vector2 pos, float size, Color4 color)
        {

        }
    }
}
