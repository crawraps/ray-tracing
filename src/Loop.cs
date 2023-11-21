namespace Engine {
  class Loop {
    private static System.Timers.Timer? timer;
    public static event EventHandler? OnStop;

    public static void Init(int fps = 60) {
      timer = new System.Timers.Timer(1000 / fps);
      timer.AutoReset = true;
      timer.Enabled = true;
    }

    public static void Stop() {
      if (timer == null) {
        throw new Exception("Main loop is not initialized");
      }

      EventHandler? handler = OnStop;
      if (handler != null) {
        handler(null, EventArgs.Empty);
      }

      timer.Stop();
      timer.Dispose();
    }

    public static void Add(System.Timers.ElapsedEventHandler ev) {
      if (timer == null) {
        throw new Exception("Main loop is not initialized");
      }

      timer.Elapsed += ev;
    }
  }
}
