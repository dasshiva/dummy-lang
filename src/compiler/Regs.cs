using System;

namespace Lang {
	public static class Regs {
		private static long[] regs = new long[12];
		public static long GetRegValue(int idx) => regs[idx];
		public static void SetRegValue(int idx, long val) {
			regs[idx] = val;
		}
	}
}
