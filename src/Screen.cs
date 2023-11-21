using Mindmagma.Curses;

namespace Engine {
  class Screen {
    private nint screen;
    private int width;
    private int height;
    private List<Layer> layers;

    public Screen() {
      screen = NCurses.InitScreen();
      NCurses.NoDelay(screen, true);
      NCurses.Raw();
      NCurses.NoEcho();
      NCurses.GetMaxYX(screen, out height, out width);

      layers = new List<Layer>();
    }

    public int Width => width;
    public int Height => height;

    public void Deconstruct() {
      NCurses.EndWin();
    }

    ~Screen() {
      Deconstruct();
    }

    public void Draw() {
      NCurses.Clear();

      layers.ForEach(layer => {
        layer.Draw();
      });

      NCurses.Move(height - 1, width - 1);
      NCurses.Refresh();
    }

    public void InsertLayer(Layer layer, int index) {
      layers.Insert(layers.Count, layer);
    }
    public void InsertLayer(Layer layer) {
      layers.Add(layer);
    }
  }
}
