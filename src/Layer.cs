using Mindmagma.Curses;

namespace Engine {
  class Layer {
    public bool isVisible = true;
    protected string name = "";
    protected int width;
    protected int height;
    private int x;
    private int y;

    public Layer(int x, int y, int width, int height) {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
    }

    public void Draw() {
      if (!isVisible) {
        return;
      }

      Clear();
      DrawSelf();
    }

    public string Name => name;

    virtual protected void DrawSelf() {}

    protected void Clear() {
      for (int y = 0; y < this.height; y++) {
        for (int x = 0; x < this.width; x++) {
          AddChar(' ', x, y);
        }
      }
    }

    protected void Move(int x, int y) {
      if (x < 0 || x > this.width) {
        Console.WriteLine("Invalid x");
        throw new Exception("Invalid x");
      }
      if (y < 0 || y > this.height) {
        Console.WriteLine("Invalid y");
        throw new Exception("Invalid y");
      }

      NCurses.Move(this.y + y, this.x + x);
    }

    protected void AddChar(char c, int x = 0, int y = 0) {
      Move(x, y);
      NCurses.AddChar(c);
    }

    protected void AddString(string str, int x = 0, int y = 0) {
      Move(x, y);
      NCurses.AddString(str);
    }
  }
}
