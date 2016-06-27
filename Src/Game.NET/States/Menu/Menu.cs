using System.Collections.Generic;
using Game.NET.Core;
using Game.NET.Logic;

namespace Game.NET.States
{
    public class Menu : State
    {
        public delegate void EntryAction(MenuEntry entry);
        public delegate void ChangeAction(int option);

        public List<MenuEntry> Entries = new List<MenuEntry>();
        protected int Selection;

        public Menu(Engine engine) : base(engine)
        {

        }

        public void NextEntry()
        {
            if (Selection < Entries.Count - 1) Selection++;
            else Selection = 0;
        }

        public void PreviousEntry()
        {
            if (Selection > 0) Selection--;
            else Selection = Entries.Count - 1;
        }

        public override void Start()
        {
            
        }

        public override void End()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void ProcessInput()
        {
            //if (Input.GetButton(Input.Button.Down).IsDown
            //        || Input.GetButton(Input.Button.AttackDown).IsDown) NextEntry();
            //else if (Input.GetButton(Input.Button.Up).IsDown
            //        || Input.GetButton(Input.Button.AttackUp).IsDown) PreviousEntry();
            //else Entries[Selection].ProcessInput();
        }

        public override void CleanUp()
        {

        }
    }
}
