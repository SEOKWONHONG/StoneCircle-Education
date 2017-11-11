using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4 {
	class Program {
		static void Main (string[] args) {
			EnumTypes types = EnumTypes.SECOND;

			switch (types) {
				case EnumTypes.FIRST:
				case EnumTypes.SECOND:
					Console.WriteLine(EnumTypes.FIRST);
					Console.WriteLine(EnumTypes.SECOND);
					break;
				case EnumTypes.THRID:
					Console.WriteLine(EnumTypes.THRID);
					break;
				default:
					break;
			}

			if(types == EnumTypes.FIRST || types == EnumTypes.SECOND) {

			}
			else if(types == EnumTypes.SECOND) {

			}
			else if(types == EnumTypes.THRID) {

			}
			else {

			}

			//Console.WriteLine((int)EnumTypes.SECOND);
			Console.ReadLine();
		}

		// 열거자 (상수 집합)
		// 승인 형식  byte, sbyte, short, ushort, int, uint, long
		public enum EnumTypes {
			FIRST = 0,
			SECOND = 1,
			THRID = 2
		}
	}
}
