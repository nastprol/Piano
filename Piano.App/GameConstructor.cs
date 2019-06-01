namespace Piano
{
    public class GameConstructor
    {
        public GameForm Form { get; }
        public GameConstructor(GameForm form, Controller controller)
        {
            Form = form;
        }
    }
}
