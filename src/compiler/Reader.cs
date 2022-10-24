using System;
using System.IO;
using Lang;

namespace Lang {
  public class Reader {
    private int lineno;
    public int LineNo {
      get => lineno;
    }

    private bool end;
    public bool End {
      get => end;
    }

    public string File {
      get;
      init;
    }

    private StreamReader ? src;

    public Reader(string file) {
      File = file;
      end = false;
      try {
        src = new StreamReader(File);
      } catch (Exception e) {
        Program.Exit($"Failed to open file {File} : {e.Message}");
      }
    }

    public string[] ? ReadLine() {
      try {
        string ? line = src?.ReadLine();
        if (line == null) {
          src?.Close();
          end = false;
          return null;
        }
        lineno++;
        var res = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var ls = new List < string > ();
        for (int i = 0; i < res.Length; i++) {
          switch (res[i]) {
          case ";":
          case ",":
            continue;
          default:
            ls.Add(res[i]);
            break;
          }
        }
        return ls.ToArray();
      } catch (Exception e) {
        /*  We don't change end because the program never returns from here */
        src?.Close();
        Program.Exit($"Failed to read from {File} : {e.Message}");

        /* unreachable but kept to prevent the compiler from complaining */
        return null;
      }
    }
  }
}