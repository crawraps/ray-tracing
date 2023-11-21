namespace Engine {
  class Program {
    static void Main(string[] args) {
      Screen screen = new Screen();
      screen = new Screen();

      Overlay Overlay = new Overlay(0, screen.Height - 4, screen.Width, 3);
      screen.InsertLayer(Overlay);

      Loop.Init(30);
      Loop.Add((sender, e) => {
        screen.Draw();
      });

      Input.RegisterKey('q', () => {
        Loop.Stop();
        Input.Interrupt();
        screen.Deconstruct();
      });

      Input.RegisterKey('h', () => {
        Overlay.isVisible = !Overlay.isVisible;
      });

      Input.Listen();
    }
  }
}
