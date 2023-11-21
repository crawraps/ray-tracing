namespace Engine {
  class KeyInfo {
    public char key;
    public Action callback;

    public KeyInfo(char key, Action callback) {
      this.key = key;
      this.callback = callback;
    }
  }

  class Input {
    private static List<KeyInfo> registeredKeys = new List<KeyInfo>();
    private static bool interrupted = false;

    public static void RegisterKey(char targetKey, Action callback) {
      registeredKeys.Add(new KeyInfo(targetKey, callback));
    }

    public static void Interrupt() {
      interrupted = true;
    }

    public static void Listen() {
      char? key = Console.ReadKey(true).KeyChar;

      Input.registeredKeys.ForEach((keyInfo) => {
        if (key == keyInfo.key) {
          keyInfo.callback();
        }
      });

      if (!interrupted) {
        Listen();
      }
    }
  }
}
