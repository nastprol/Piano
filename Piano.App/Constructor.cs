using Domain;

namespace App
{
    public class Constructor
    {
        public Controller Controller { get; }
        public GameForm GameForm { get; }

        public Constructor(Controller controller, GameForm gameForm)
        {
            Controller = controller;
            GameForm = gameForm;
        }
    }
}