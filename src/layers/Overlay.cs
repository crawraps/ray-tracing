namespace Engine {
  class Overlay : Layer {
    public Overlay(int x, int y, int width, int height) : base(x, y, width, height) {
      this.name = "Overlay";
    }

    protected override void DrawSelf() {
      DrawBorder();
      AddString("q - quit  |  h - show/hide ui", 2, 2);
    }

    private void DrawBorder() {
      AddString(String.Concat(Enumerable.Repeat('-', width)));
    }
  }
}
