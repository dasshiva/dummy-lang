using System;
using System.IO;

namespace Lang {
    public class Codegen {
        private readonly BinaryWriter writer;
        private readonly string filename;
        private bool ready;
        
        public Codegen(string filename) {
            try {
                this.filename = filename;
                this.writer = new BinaryWriter(File.Open(filename, FileMode.CreateNew));
            }
            catch (Exception e) {
                Program.Exit($"Unable to write to file {filename} : {e.Message}");
            }
        }

        private void Init() {
            writer.Write((ulong) FileConstants.MAGIC);
            writer.Write((ushort) FileConstants.MAJOR_VERSION);
            writer.Write((ushort) FileConstants.MINOR_VERSION);
            ready = true;
        }
        
        public void Write(ParserResult pr) {
            if(!ready)
               Init();
        }

        ~Codegen() {
            writer.Dispose();
        }
    }
}