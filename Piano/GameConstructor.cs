namespace Piano.Control
{
    public class
        GameConstructor //более хорошего способа как собрать и форму и контроллер одним вызовом get di я не нашёл тк сейчас для того чтобы собрать контроллер нужно собрать форму => форма не может зависеть от контроллера иначе будет циклическая зависимомть, и от него вообще сейчас кроме этого класса ничего не зависит
    {
        private readonly Controller controller;

        public GameConstructor(GameForm form, Controller controller)
        {
            this.controller = controller;
            Form = form;
        }

        public GameForm Form { get; }
    }
}