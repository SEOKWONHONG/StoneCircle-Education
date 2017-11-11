using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3 {
	class Program {
		static void Main (string[] args) {
			//고정길이 배열
			int[,] fixedArray2D = new int[3, 3] {
				{ 1, 2, 3},
				{ 4, 5, 6},
				{ 7, 8, 9},
			};

			fixedArray2D[0, 1] = 1;

			foreach (var item1 in fixedArray2D) {
				Console.Write(item1);
				Console.Write(" ");
			}

			Console.WriteLine("");

			for (int i=0; i<3; i++) {
				for(int j=0; j<3; j++) {
					Console.Write(fixedArray2D[i, j]);
					Console.Write(" ");
				}
			}

			Console.WriteLine("");

			//가변길이 배열
			int[][] dynamicArray2D = new int[3][];
			dynamicArray2D[0] = new int[3] { 1, 2, 3 };
			dynamicArray2D[1] = new int[3] { 4, 5, 6 };
			dynamicArray2D[2] = new int[3] { 7, 8, 9 };

			foreach(var item1 in dynamicArray2D) {
				foreach(var item2 in item1) {
					Console.Write(item2);
					Console.Write(" ");
				}
			}

			Console.WriteLine("");

			for (int i = 0; i < dynamicArray2D.Length; i++) {
				for (int j = 0; j < dynamicArray2D[i].Length; j++) {
					dynamicArray2D[i][j] = dynamicArray2D[i][j] * 2;
					Console.Write(dynamicArray2D[i][j]);
					Console.Write(" ");
				}
				Console.WriteLine("");
			}

			//가변길이 2차원배열에서 string선언하고 루프를 통해서 초기화.
			string str = " Hello World! ";
			string[] strArray = str.Split(new string[] { " " }, StringSplitOptions.None);
			
			char[] ch = new char[12];
			ch[0] = 'H'; ch[1] = 'e'; ch[2] = 'l'; ch[3] = 'l'; ch[4] = 'o';
			ch[5] = ' ';
			ch[6] = 'W'; ch[7] = 'o'; ch[8] = 'r'; ch[9] = 'l'; ch[10] = 'd';
			ch[11] = '!';
			
			Console.WriteLine(str.TrimEnd());

			Console.WriteLine(ch);

			Console.WriteLine("");

			

			Console.ReadLine();
		}
	}
}
