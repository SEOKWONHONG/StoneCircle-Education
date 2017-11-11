using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2 {
	class Program {
		static void Main (string[] args) {
			args = new string[] {
				"1", "2", "3", "4"
			};

			int[] iArray = new int[4] { 1, 2, 3, 4};

			/*for(int i=0; i < iArray.Length; i++) {
				if (iArray[i] == 2) {
					iArray[i] = 5;
				}
				else if(iArray[i] == 1) {
					iArray[i] = iArray[i] * 2;
				}

				Console.WriteLine("Index : {0}, Value : {1}", i, iArray[i]);
			}*/

			/*string[,] names = new string[5, 4];

			names[0, 0] = "1";
			names[0, 1] = "2";*/

			/*int length = args.Length;

			//property로 접근하는게 이익이다.
			Console.WriteLine("property : {0}, method : {1}", args.Length, args.GetLength(0));

			for(int i = 0; i<length; i++) {
				if(args[i] == "2") {
					args[i] = "5";
				}

				Console.WriteLine("Index : {0}, Value : {1}", i, args[i]);
			}*/

			foreach (var item in iArray) {
				Console.WriteLine("Value : {0}", item);
			}

			int index = 0;

			while (index < iArray.Length) {
				Console.WriteLine("Index : {0}, Value : {1}", index, iArray[index]);
				index++;
			}

			index = 0;

			while (true) {
				Console.WriteLine("Index : {0}, Value : {1}", index, iArray[index]);
				index++;
				if (index >= iArray.Length) break;
			}

			index = 0;

			do {
				Console.WriteLine("Index : {0}, Value : {1}", index, iArray[index]);
				index++;
			} while (index < iArray.Length);


			Console.ReadLine();
		}
	}
}
 