using System;
using System.IO;
using System.Collections.Generic;

namespace Lang {
  public class Codegen {
    private readonly BinaryWriter writer;
    private readonly string filename;
    private bool ready;

    public Codegen(string filename) {
      try {
        this.filename = filename;
        this.writer = new BinaryWriter(File.Open(filename, FileMode.Create));
      } catch (Exception e) {
        Program.Exit($"Unable to write to file {filename} : {e.Message}");
      }
    }

    private void Init() {
      writer.Write((ulong) FileConstants.MAGIC);
      writer.Write((ushort) FileConstants.MAJOR_VERSION);
      writer.Write((ushort) FileConstants.MINOR_VERSION);
      ready = true;
    }

    private void WriteRegister(object arg) {
      byte r = (byte) arg;
      writer.Write(r);
    }

    private void WriteInt64(object arg) => writer.Write((Int64) arg);
    private void WriteUInt64(object arg) => writer.Write((UInt64) arg);
    private void SmartWrite(object arg) {
      if (arg is Registers)
        WriteRegister(arg);
      else {
        if (arg is Int64)
          WriteInt64(arg);
        else
          WriteUInt64(arg);
      }
    }

    private void WriteString(string str) {
      writer.Write((ushort) str.Length);
      foreach (char c in str) {
        writer.Write((byte) c);
      }
    }

    public void Write(List < ParserResult > list) {
        if (!ready)
          Init();
        writer.Write((ushort) list.Count);
        foreach(ParserResult pr in list) {
          WriteString(pr.functionName);
          writer.Write((ushort) pr.impl.Count);
          foreach(Insn ins in pr.impl) {
            // Write the instruction code
            writer.Write((ushort) ins.insn);
            // The first argument to any instruction is the destination register
            WriteRegister(ins.args[0]);

            // The second and third argument to any instruction may be an immediate value or register
            SmartWrite(ins.args[1]);
            SmartWrite(ins.args[2]);
          }
          writer.Write((ushort) 0xED);
        }
        writer.Flush();
      }

      ~Codegen() {
        writer.Dispose();
      }

    // callled in case an error happens and output file
    // needs to be deleted
    public void ForceClose() {
      File.Delete(filename);
    }
  }
}